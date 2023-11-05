using Backend.DTOS.Marriages;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class MarriagesController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IMarriagesService marriagesService;

        public MarriagesController(DatabaseContext databaseContext, IMarriagesService marriagesService)
        {
            this.databaseContext = databaseContext;
            this.marriagesService = marriagesService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetMarriages()
        {
            var marriages = (await marriagesService.FindAll()).Select(MarriagesResponse.FormMarriage);
            return Ok(marriages);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetMarriagesById(int id)
        {
            var data = await marriagesService.FindByMarraigeId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Marriage>> CreateMarriage ([FromForm] MarriagesCreate marriagesCreate,int userid)
        {
            var user = await databaseContext.Users.Include(x=>x.Marriage).FirstOrDefaultAsync(x=>x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newMarriages = new Marriage
            {
                id_title = marriagesCreate.id_title,
                marria_name = marriagesCreate.marriage_name,
                marria_lastname = marriagesCreate.marriage_lastname,
                marria_birdate = marriagesCreate.marria_birdate,
                marria_race = marriagesCreate.marria_race,
                marria_religion = marriagesCreate.marria_religion,
                marria_nationality = marriagesCreate.marria_nationality,
                marria_occupation = marriagesCreate.marria_occupation,
                marria_position = marriagesCreate.marria_position,
                marria_workplace = marriagesCreate.marria_workplace,
                marria_WPphone = marriagesCreate.marria_WPphone,
                marriia_weddingday = marriagesCreate.marriia_weddingday,
                marria_address = marriagesCreate.marria_address,
                marria_phone = marriagesCreate.marria_phone,
                marria_divorce = marriagesCreate.marria_divorce,
                marria_lastaddress = marriagesCreate.marria_lastaddress,
                id_statusPC = marriagesCreate.id_statusPC,
                Createdate = DateTime.Now,
            };

            user.Marriage.Add(newMarriages);

            await databaseContext.SaveChangesAsync();   
            return Ok(new { msg = "Ok",user});
        }
        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Marriage>> DeleteMarriage( int id)
        {
            var marriage = await marriagesService.FindByMarraigeId(id);
            if(marriage == null) return NotFound();

            await marriagesService.Delete(marriage);
            return NoContent();
        }

        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Marriage>> FindByUserId(int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Marriage).ThenInclude(x=>x.Title).Include(x=>x.Marriage).ThenInclude(x=>x.StatusPC).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            return Ok(user.Marriage);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateMarriage([FromForm] MarriagesUpdate data,int id)
        {
            try
            {
                return Ok(await marriagesService.Update(data,id));
            }catch(Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }
    }

    
}
