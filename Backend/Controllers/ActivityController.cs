using Backend.DTOS.Activities;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class ActivityController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IActivityService activityService;

        public ActivityController(DatabaseContext databaseContext, IActivityService activity)
        {
            this.databaseContext = databaseContext;
            this.activityService = activity;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetActivity()
        {
            var activities = (await activityService.FindAll()).Select(ActivityResponse.FormActivity);
            return Ok(activities);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetACtivityById(int id)
        {
            var data = await activityService.FindByActivityId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Activity>> CreateActivity([FromForm] ActivityCreate activityCreate, int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Activity).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newActivity = new Activity
            {
                Activi_startdate = activityCreate.Activity_startdate,
                Activi_enddate = activityCreate.Activity_enddate,
                Activi_placename = activityCreate.Activity_placename,
                Activi_position = activityCreate.Activity_position,
                createdate = DateTime.Now,
            };

            user.Activity.Add(newActivity);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "OK", user });
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Activity>> DeleteActivity ( int id)
        {
            var activity = await activityService.FindByActivityId(id);
            if(activity == null) return NotFound();
            await activityService.Delete(activity);
            return NoContent();
        }
        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Activity>> FindByUserId(int userid,[FromQuery]string? search = "")
        {
            var user = await databaseContext.Users.Include(x => x.Activity).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var activities = user.Activity.Where(x =>
            x.Activi_startdate.Year.ToString().Contains(search) ||
            x.Activi_enddate.Year.ToString().Contains(search) ||
            x.Activi_placename.Contains(search)
            );



            return Ok(activities);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateActivity ([FromForm] ActivityUpdate data ,int id)
        {
            try
            {
                return Ok(await activityService.Update(data, id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }

    }
}
