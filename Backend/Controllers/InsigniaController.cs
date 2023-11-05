using Backend.DTOS.Insignias;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class InsigniaController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IInsigniaService insigniaService;

        public InsigniaController(DatabaseContext databaseContext, IInsigniaService insigniaService)
        {
            this.databaseContext = databaseContext;
            this.insigniaService = insigniaService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetInsignias()
        {
            var insignias = (await insigniaService.FindAll()).Select(InsigniaResponse.FromInsignia);
            return Ok(insignias);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetInsigniaById(int id)
        {
            var data = await insigniaService.FindByInsigniaId(id);
            return Ok(data);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Insignia>> CreateInsignia([FromForm] InsigniaCreate insigniaCreate , int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Insignias).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newInsignia = new Insignia
            {
                insignia_name = insigniaCreate.insignia_name,
                insignia_year = insigniaCreate.insignia_year,
                insignia_receiveddate = insigniaCreate.insignia_receiveddate,
                Createdate = DateTime.Now,
            };

            user.Insignias.Add(newInsignia);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "OK", user });
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Insignia>> DeleteInsignia( int id)
        {
            var insignia = await insigniaService.FindByInsigniaId(id);
            if (insignia == null) return NotFound();
            await insigniaService.Delete(insignia);
            return NoContent();
        }
        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Insignia>> FindByUserId(int userid,[FromQuery]string? search="")
        {
            var user = await databaseContext.Users.Include(x => x.Insignias).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var insigniaes = user.Insignias.Where(x =>
            x.insignia_name.Contains(search) ||
            x.insignia_year.Contains(search));

            return Ok(insigniaes);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateIngisnia ([FromForm] InsigniaUpdate data,int id)
        {
            try
            {
                return Ok(await insigniaService.Update(data, id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }

    }
}
