using Backend.DTOS.Arrests;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class ArrestController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IArrestService arrestService;

        public ArrestController(DatabaseContext databaseContext, IArrestService arrestService)
        {
            this.databaseContext = databaseContext;
            this.arrestService = arrestService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetArrest()
        {
            var arrests = (await arrestService.FindAll()).Select(ArrestResponse.FormArrest);
            return Ok(arrests);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetArrestById(int id)
        {
            var data = await arrestService.FindByArrestId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Arrest>> CreateArrest([FromForm] ArrestCreate arrestCreate, int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Arrest).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var newarrest = new Arrest
            {
                Arrest_date = arrestCreate.Arrest_date,
                Arrest_crimescene = arrestCreate.Arrest_crimescene,
                Arrest_plaint = arrestCreate.Arrest_plaint,
                Arrest_outcomeofthecase = arrestCreate.Arrest_outcomeofthecase,
                Createdate = DateTime.Now,
            };

            user.Arrest.Add(newarrest);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "OK", user });
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Arrest>> DeleteArrest( int id)
        {
            var arrest = await arrestService.FindByArrestId(id);
            if (arrest == null) return NotFound();
            await arrestService.Delete(arrest);
            return NoContent();
        }

        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Arrest>> FindByUserId(int userid, [FromQuery]string? search = "")
        {
            var user = await databaseContext.Users.Include(x => x.Arrest).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var arrest = user.Arrest.Where(x =>
            x.Arrest_plaint.Contains(search) ||
            x.Arrest_date.Year.ToString().Contains(search) ||
            x.Arrest_crimescene.Contains(search) 
            );

            return Ok(arrest);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateArrest([FromForm] ArrestUpdate data,int id)
        {
            try
            {
                return Ok(await arrestService.Update(data, id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });

            }
        }
    }
}
