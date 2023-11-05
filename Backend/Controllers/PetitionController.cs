using Backend.DTOS.Petitions;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Controllers
{
    public class PetitionController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IPetitionService petitionService;

        public PetitionController(DatabaseContext databaseContext,IPetitionService petitionService)
        {
            this.databaseContext = databaseContext;
            this.petitionService = petitionService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPetition([FromQuery] string? search ="")
        {
            var petitions = (await petitionService.FindAll(search)).Select(PetitionResponse.FromPetition );

            //var petitions = (await petitionService.FindAll()).Select(PetitionResponse.FromPetition );
            return Ok(petitions);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetPetitionById(int id)
        {
            //var data = await petitionService.FindByPetitionId(id);
            var data = await databaseContext.Petitions.Include(x=>x.Author).FirstOrDefaultAsync(x=>x.Id == id);
            return Ok(data);
        }
        [Authorize]
        [HttpPost("[action]")]
        public async Task<ActionResult<Petition>> CreatePetition([FromForm] PetitionCreate petitionCreate)
        {
            // ดึง Token จาก HttpContext
            var token = HttpContext.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

           

            // ถอดรหัส Token เพื่อใช้งาน
            var jwt = new JwtSecurityToken(token);
            var userId = jwt.Claims.First(c => c.Type == "userId").Value;
            int idUser = int.Parse(userId);
            
            var user = await databaseContext.Users.Include(x => x.Petitions).FirstOrDefaultAsync(x => x.Id.Equals(idUser));
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles,
                WriteIndented = true
            };
            if (user == null) return NotFound();

            
            (string errorMessage, string imageName) = await petitionService.UploadImage(petitionCreate.FormFile);
            if (!string.IsNullOrEmpty(errorMessage)) return BadRequest(errorMessage);
            var newPetition = new Petition
            {
                peti_message = petitionCreate.peti_message,
                File = imageName,
                peti_staus = "รอเจ้าหน้าที่รับเรื่อง",
                Createdate = DateTime.Now,
            };

           
            user.Petitions.Add(newPetition);
            
            await databaseContext.SaveChangesAsync();
            
            return Ok(new { msg = "Ok", user });
           
        }


        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Petition>> DeleteEducation( int id)
        {
            var petition = await petitionService.FindByPetitionId(id);
            if (petition == null) return NotFound();

            await petitionService.Delete(petition);
            return NoContent();
        }

        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Petition>> FindByUserId(int userid,[FromQuery] string? search ="")
        {
            var user = await databaseContext.Users.Include(x => x.Petitions).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var petitions = user.Petitions.Where(x =>
            x.Createdate.Year.ToString().Contains(search) ||
            x.peti_staus.Contains(search)
            ) ;

            return Ok(petitions);


        }
        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> AcceptPetition(int id)
        {
            try
            {
                return Ok(await petitionService.AcceptPetition(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 400, message = e.Message });
            }
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> ConfirmPetition(int id)
        {
            try
            {
                return Ok(await petitionService.ConfirmPetiton(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 400, message = e.Message });
            }
        }


        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> CancelPetition(int id)
        {
            try
            {
                return Ok(await petitionService.CancelPetition(id));
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = 400, message = e.Message });
            }
        }

       
    }
}
