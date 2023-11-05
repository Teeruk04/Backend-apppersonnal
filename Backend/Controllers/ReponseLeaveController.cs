using Backend.Constants;
using Backend.DTOS.ReportLeaves;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Controllers
{
    public class ReponseLeaveController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IReporrtLeaveService reporrtLeaveService;

        public ReponseLeaveController(DatabaseContext databaseContext, IReporrtLeaveService reporrtLeaveService)
        {
            this.databaseContext = databaseContext;
            this.reporrtLeaveService = reporrtLeaveService;
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<ReportLeave>> CreateReportLeave([FromForm] int userid)
        {
            var user = await databaseContext.Users.Include(x => x.ReportLeaves).ThenInclude(x => x.Leaves).Include(x => x.StatusU).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var currentYear = user.ReportLeaves.FirstOrDefault(x => x.createdate.Year == DateTime.Now.Year);
            var oldLeave = user.ReportLeaves.FirstOrDefault(x => x.createdate.Year == DateTime.Now.Year - 1);


            var leaveCont = oldLeave == null ? 0 : oldLeave.ReportL_leave - oldLeave.Leaves.Where(x => x.leave_type == LeaveType.leave).Sum(x => x.leave_quantity);

            var newReportLeave = new ReportLeave
            {
                ReportL_lastyear = leaveCont < 0 ? 0 : leaveCont,
                ReportL_thisyear = 30,
                ReportL_leavesick = user.StatusU.Id == 1 ? 60 : 30,
                ReportL_leavepersonal = user.StatusU.Id == 1 ? 45 : 10,
                ReportL_leavematerntity = 90,
                ReportL_leaveTHHWWGB = 90,
                ReportL_leaveordination = 120,
                ReportL_leaveforfasting = 90,
                ReportL_leavespouse = 512,
                ReportL_leaveforstudy = 1024,
                createdate = DateTime.Now,

            };
            newReportLeave.ReportL_leave = newReportLeave.ReportL_lastyear + newReportLeave.ReportL_thisyear >= 20 ? 20 : newReportLeave.ReportL_lastyear + newReportLeave.ReportL_thisyear;

            user.ReportLeaves.Add(newReportLeave);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "Ok", user });
        }

       

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReportLeave()
        {
            var reportleave = (await reporrtLeaveService.FindAll()).Select(ReportLeaveResponse.FromReportLeave);
            return Ok(reportleave);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetReportLeaveById(int id)
        {
            var data = await reporrtLeaveService.FindByreportLeaveId(id);
            return Ok(data);
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<ReportLeave>> DeleteReport(int id)
        {
            var reportleave = await reporrtLeaveService.FindByreportLeaveId(id);
            if (reportleave == null) return NotFound();

            await reporrtLeaveService.Delete(reportleave);
            return NoContent();
        }

        [HttpGet("[action]/{userid}")]
        public async Task<ActionResult<ReportLeave>> FindByUserId(int userid,[FromQuery] string? search = "" )
        {
            var user = await databaseContext.Users.Include(x => x.ReportLeaves).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var reportLeave = user.ReportLeaves.Where(x => x.createdate.Year.ToString().Contains(search));

            return Ok(reportLeave);
            //return Ok(user.ReportLeaves.OrderByDescending(x => x.createdate));
        }


    }
}
