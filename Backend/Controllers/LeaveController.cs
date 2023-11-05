using Backend.Constants;
using Backend.DTOS.Leaves;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class LeaveController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly ILeaveService leaveService;

        public LeaveController(DatabaseContext databaseContext, ILeaveService leaveService)
        {
            this.databaseContext = databaseContext;
            this.leaveService = leaveService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLeave()
        {
            var leave = (await leaveService.FindAll()).Select(LeaveResponse.FromLeave);
            return Ok(leave);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetLeaveById(int id)
        {
            var data = await leaveService.FindById(id);
            return Ok(data);
        }
        [HttpPost("[action]")]
        public async Task<ActionResult<Leave>> CreateLeave([FromForm] LeaveCreate leaveCreate)
        {
            var user = await databaseContext.Users.Include(x => x.StatusU).Include(x => x.ReportLeaves).ThenInclude(x => x.Leaves).FirstOrDefaultAsync(x => x.Id == leaveCreate.user_id);
            if (user == null) return BadRequest();

            var currentYear = user.ReportLeaves.FirstOrDefault(x => x.createdate.Year == DateTime.Now.Year);
            if (currentYear == null)
            {
                var oldLeave = user.ReportLeaves.FirstOrDefault(x => x.createdate.Year == DateTime.Now.Year - 1);
                var leaveCont = oldLeave == null ? 0 : oldLeave.ReportL_leave - oldLeave.Leaves.Where(x => x.leave_type == LeaveType.leave).Sum(x => x.leave_quantity);
                var newReportLeave = new ReportLeave
                {
                    ReportL_lastyear = leaveCont < 0 ? 0 : leaveCont,
                    ReportL_thisyear = 10,
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

                newReportLeave.Leaves.Add(new Leave
                {
                    leave_type = leaveCreate.leave_type,
                    leave_quantity = GetBusinessDayCount(leaveCreate.leave_startdate, leaveCreate.leave_enddate),
                    leave_startdate = leaveCreate.leave_startdate,
                    leave_enddate = leaveCreate.leave_enddate,
                    leave_note = leaveCreate.leave_note,
                }
                );
                user.ReportLeaves.Add(newReportLeave);

            }
            else
            {
                currentYear.Leaves.Add(new Leave
                {
                    leave_type = leaveCreate.leave_type,
                    leave_quantity = GetBusinessDayCount(leaveCreate.leave_startdate, leaveCreate.leave_enddate),
                    leave_startdate = leaveCreate.leave_startdate,
                    leave_enddate = leaveCreate.leave_enddate,
                    leave_note = leaveCreate.leave_note,
                });
            }
            await databaseContext.SaveChangesAsync();

            return Ok(new { msg = "Ok" });
        }

        private float GetBusinessDayCount(DateTime start_date, DateTime end_dete)
        {
            TimeSpan daysCount = end_dete - start_date;

            int totalDays = daysCount.Days;
            int businessDays = 0;
            for (var date = start_date; date <= end_dete; date = date.AddDays(1))
            {
                if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                {
                    businessDays++;
                }
            }
            return businessDays;
        }
        [HttpGet("[action]/{reportId}")]
        public async Task<ActionResult<object>> FindByReportId(int reportId)
        {
            var report = await databaseContext.ReportLeaves.Include(x => x.Leaves).FirstOrDefaultAsync(x => x.Id.Equals(reportId));
            if (report == null) return BadRequest();

            return Ok(LeaveResponse.sumLeave(report));

        }



        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Leave>> DeleteLeave(int id)
        {
            var leave = await leaveService.FindById(id);
            if (leave == null) return NotFound();

            await leaveService.Delete(leave);
            return NoContent();
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateLeave([FromForm] LeaveUpdate data, int id)
        {
            try
            {
                return Ok(await leaveService.Update(data, id));
            }
            catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }
    }
}
