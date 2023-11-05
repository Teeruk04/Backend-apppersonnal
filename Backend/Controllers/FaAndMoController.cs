using Backend.DTOS.FatherAndMothers;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class FaAndMoController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IFaAndMoService faAndMoService;

        public FaAndMoController(DatabaseContext databaseContext, IFaAndMoService faAndMoService)
        {
            this.databaseContext = databaseContext;
            this.faAndMoService = faAndMoService;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetFatherAndMother()
        {
            var fatherAndmother = (await faAndMoService.FindAll()).Select(FatherAndMotherResponse.FromFatherAndMother);
            return Ok(fatherAndmother);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetFatherAndMotherById(int id)
        {
            var data = await faAndMoService.FindByFatherAndMotherId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<FatherAndMother>> CreateFaAndMo([FromForm] FatherAndMotherCreate fatherAndMotherCreate , int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Activity).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newFatherAndMother = new FatherAndMother
            {
                Fa_title = 2,
                fa_name = fatherAndMotherCreate.fa_name,
                fa_lastname = fatherAndMotherCreate.fa_lastname,
                fa_birthdate = fatherAndMotherCreate.fa_birthdate,
                fa_placebirth = fatherAndMotherCreate.fa_placebirth,
                fa_race = fatherAndMotherCreate.fa_race,
                fa_religion = fatherAndMotherCreate.fa_religion,
                fa_nationality = fatherAndMotherCreate.fa_nationality,
                fa_address = fatherAndMotherCreate.fa_address,
                fa_phone = fatherAndMotherCreate.fa_phone,
                fa_occupation = fatherAndMotherCreate.fa_occupation,
                fa_position = fatherAndMotherCreate.fa_position,
                fa_workplace = fatherAndMotherCreate.fa_workplace,
                fa_WPphone = fatherAndMotherCreate.fa_WPphone,
                MO_title = fatherAndMotherCreate.mo_title,
                mo_name = fatherAndMotherCreate.mo_name,
                mo_lastname = fatherAndMotherCreate.mo_lastname,
                mo_birthdate = fatherAndMotherCreate.mo_birthdate,
                mo_placebirth = fatherAndMotherCreate.mo_placebirth,
                mo_race = fatherAndMotherCreate.mo_race,
                mo_religion = fatherAndMotherCreate.mo_religion,
                mo_nationality = fatherAndMotherCreate.mo_nationality,
                mo_address = fatherAndMotherCreate.mo_address,
                mo_phone = fatherAndMotherCreate.mo_phone,
                mo_occupation = fatherAndMotherCreate.mo_occupation,
                mo_position = fatherAndMotherCreate.mo_position,
                mo_workplace = fatherAndMotherCreate.mo_workplace,
                mo_WPphone = fatherAndMotherCreate.mo_WPphone,
                Createdate = DateTime.Now,
            };

            user.FatherAndMother.Add(newFatherAndMother);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "OK", user });
        }



        [HttpPost("[action]")]
        public async Task<ActionResult<FatherAndMother>> DeleteFatherAndMother([FromForm] int id)
        {
            var faandmo = await faAndMoService.FindByFatherAndMotherId(id);
            if (faandmo == null) return NotFound();

            await faAndMoService.Delete(faandmo);
            return NoContent();
        }
        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<FatherAndMother>> FindByUserId(int userid)
        {
            var user = await databaseContext.Users.Include(x => x.FatherAndMother).ThenInclude(x=>x.Title).Include(x=>x.FatherAndMother).ThenInclude(x=>x.TitleM).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            return Ok(user.FatherAndMother);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateFaANdMo ([FromForm] FAtherAndMotherUpdate data, int id)
        {
            try
            {
                return Ok(await faAndMoService.Update(data, id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }

    }
}
