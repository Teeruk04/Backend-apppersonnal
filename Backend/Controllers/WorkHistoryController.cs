using Backend.DTOS.WorkHitories;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class WorkHistoryController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IWorkHistoryService workHistoryService;

        public WorkHistoryController(DatabaseContext databaseContext, IWorkHistoryService workHistoryService)
        {
            this.databaseContext = databaseContext;
            this.workHistoryService = workHistoryService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkHistory()
        {
            var workHitstory = (await workHistoryService.FindAll()).Select(WorkHistoryResponse.FormWorkHitory);
            return Ok(workHitstory);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetWorkHistoryById(int id)
        {
            var data = await workHistoryService.FindByWorkHistoryId(id);
            return Ok(data);
        }


        [HttpPost("[action]")]
        public async Task<ActionResult<Workhistory>> CreateWorkHistory([FromForm] WorkHistoryCreate workHistoryCreate, int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Workhistory).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newWorkHistory = new Workhistory
            {
                WorkH_startdate = workHistoryCreate.WorkH_startdate,
                WorkH_enddate = workHistoryCreate.WorkH_enddate,
                WorkH_employer = workHistoryCreate.WorkH_employer,
                WorkH_placename = workHistoryCreate.WorkH_placename,
                WorkH_position = workHistoryCreate.WorkH_position,
                WorkH_reason = workHistoryCreate.WorkH_reason,
                createdate = DateTime.Now,
            };
            user.Workhistory.Add(newWorkHistory);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "OK", user });


        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Activity>> DeleteWorkHistory(int id)
        {
            var workHistory = await workHistoryService.FindByWorkHistoryId(id);
            if (workHistory == null) return NotFound();
            await workHistoryService.Delete(workHistory);
            return NoContent();
        }

        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Workhistory>> FindByUserId(int userid, [FromQuery] string? search = "")
        {
            var user = await databaseContext.Users.Include(x => x.Workhistory).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var works = user.Workhistory.Where(x =>
            x.WorkH_employer.Contains(search) || 
            x.WorkH_position.Contains(search) || 
            x.WorkH_startdate.Year.ToString().Contains(search) ||
            x.WorkH_enddate.Year.ToString().Contains(search) 
            );

            return Ok(works);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateWork ([FromForm] WorkHistoryUpdate data , int id)
        {
            try
            {
                return Ok(await workHistoryService.Update(data , id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }
    }
}
