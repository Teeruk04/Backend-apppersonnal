using Backend.DTOS.Educations;
using Backend.Interfaces;
using Backend.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class EducationController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IEducationService educationService;
        

        public EducationController(DatabaseContext databaseContext, IEducationService educationService )
        {
            this.databaseContext = databaseContext;
            this.educationService = educationService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEducation()
        {
            var educations = (await educationService.FindAll()).Select(EducationResponse.FromEucation);
            return Ok(educations);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetEducationById(int id)
        {
            var data = await educationService.FindByEducationId(id);
            return Ok(data);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<Education>> CreateEducation ([FromForm] EducationCreate educationCreate ,int userid)
        {
            (string errorMessage, string imageName) = await educationService.UploadImage(educationCreate.FormFile);
            if (!string.IsNullOrEmpty(errorMessage)) return BadRequest(errorMessage);
            var user = await databaseContext.Users.Include(x=>x.Education).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newEducation = new Education{
           
                Educa_startdate =educationCreate.Educa_startdate,
                Educa_enddate = educationCreate.Educa_enddate,
                Educa_placename = educationCreate.Educa_placename,
                Educa_location = educationCreate.Educa_location,
                Educa_course = educationCreate.Educa_course,
                Educa_results =educationCreate.Educa_results,
                File = imageName,
                id_level = educationCreate.id_level,
                Createdat = DateTime.Now,


            };

            user.Education.Add(newEducation);
            
            
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "Ok", user });
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Education>> DeleteEducation( int id)
        {
            var education = await educationService.FindByEducationId(id);
            if (education == null) return NotFound();

            await educationService.Delete(education);
            return NoContent();
        }

        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Education>> FindByUserId(int userid, [FromQuery]string? search = "")
        {
            var user = await databaseContext.Users
                .Include(x => x.Education)
                    .ThenInclude(x=>x.Level)
                .FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var educations = user.Education.Where(a => a.Educa_course.Contains(search));

            return Ok(educations);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateEducation ([FromForm] EducationUpdate data ,int id)
        {
            try
            {
                return Ok(await educationService.Update(data, id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }



    }
}
