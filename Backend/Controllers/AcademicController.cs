using Backend.DTOS.Academics;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class AcademicController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IAcademicService academicService;

        public AcademicController(DatabaseContext databaseContext, IAcademicService academicService)
        {
            this.databaseContext = databaseContext;
            this.academicService = academicService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAcademic()
        {
            var academics = (await academicService.FindAll()).Select(AcademicResponse.FromAcademic);
            return Ok(academics);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAcademicId(int id)
        {
            var data = await academicService.FindByAcademicId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Academicposition>> CreateAcademic([FromForm] AcademicCreate academicCreate, int userid)
        {
            (string errorMessage, string imageName) = await academicService.UploadImage(academicCreate.FormFile);
            if (!string.IsNullOrEmpty(errorMessage)) return BadRequest(errorMessage);
            var user = await databaseContext.Users.Include(x => x.Academicpositions).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newAcademic = new Academicposition
            {
                academic_position = academicCreate.academic_position,
                academic_branchcode = academicCreate.academic_branchcode,
                academic_branchname = academicCreate.academic_branchname,
                academic_startdate = academicCreate.academic_startdate,
                academic_refer = academicCreate.academic_refer,
                File = imageName,
                Createdate = DateTime.Now,
            };

            user.Academicpositions.Add(newAcademic);

            
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "Ok", user });
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Academicposition>> DeleteAcademic( int id)
        {
            var academic = await academicService.FindByAcademicId(id);
            if (academic == null) return NotFound();

            await academicService.Delete(academic);
            return NoContent();
        }
        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Academicposition>> FindByUserId ( int userid,[FromQuery]string? search ="")
        {
            var user = await databaseContext.Users.Include(x => x.Academicpositions).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var academics = user.Academicpositions.Where(x => 
            x.academic_position.Contains(search)||
            x.academic_branchname.Contains(search)||
            x.academic_startdate.Year.ToString().Contains(search)
            );

            return Ok(academics);

            
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAcademic ([FromForm] AcademicUpdate data ,int id)
        {
            try
            {
                return Ok(await academicService.Update(data, id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }
    }
}
