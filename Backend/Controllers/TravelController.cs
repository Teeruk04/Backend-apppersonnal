using Backend.DTOS.Travels;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class TravelController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly ITravelService travelService;

        public TravelController(DatabaseContext databaseContext, ITravelService travelService)
        {
            this.databaseContext = databaseContext;
            this.travelService = travelService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTravel()
        {
            var travels = (await travelService.FindAll()).Select(TravelResponse.FromTravel );
            return Ok(travels);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTravelById(int id)
        {
            var data = await travelService.FindByTravelId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Travel>> CreateTravel([FromForm] TravelCreate travelCreate, int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Travels).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newTravel = new Travel
            {
                travel_startdate = travelCreate.travel_startdate,
                travel_enddate = travelCreate.travel_enddate,
                travel_city = travelCreate.travel_city,
                travel_county = travelCreate.travel_county,
                travel_purpose = travelCreate.travel_purpose,
                travel_capital = travelCreate.travel_capital,
                Cratedate = DateTime.Now,
            };
            user.Travels.Add(newTravel);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "Ok", user });
        }


        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Travel>> DeleteTravel( int id)
        {
            var travel = await travelService.FindByTravelId(id);
            if (travel == null) return NotFound();

            await travelService.Delete(travel);
            return NoContent();
        }
        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Travel>> FindByUserId(int userid,[FromQuery]string? search = "")
        {
            var user = await databaseContext.Users.Include(x => x.Travels).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var travels = user.Travels.Where(x=>
            x.travel_startdate.Year.ToString().Contains(search) ||
            x.travel_enddate.Year.ToString().Contains(search) ||
            x.travel_county.Contains(search) ||
            x.travel_city.Contains(search) 
            );

            return Ok(travels);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateTravel ([FromForm] TravelUpdate data,int id)
        {
            try
            {
                return Ok(await travelService.Update(data, id));
            }catch(Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }
    }
}
