using Backend.Constants;
using Backend.Models;
namespace Backend.DTOS.Leaves
{
    public class LeaveResponse
    {
        static public object FromLeave(Leave leave)
        {
            return new
            {
                leave.Id,
                leave.leave_type,
                leave.leave_quantity,
                leave.leave_startdate,
                leave.leave_enddate,
                leave.leave_note,
            };
        }

        static public object sumLeave(ReportLeave report)
        {
            return new
            {
                leavesickCount = report.Leaves.Where(x => x.leave_type == LeaveType.leavesick).Sum(x => x.leave_quantity),
                leavepersonalCount = report.Leaves.Where(x => x.leave_type == LeaveType.leavepersonal).Sum(x => x.leave_quantity),
                leavematerntityCount = report.Leaves.Where(x => x.leave_type == LeaveType.leavematerntity).Sum(x => x.leave_quantity),
                leaveTHHWWGBCount = report.Leaves.Where(x => x.leave_type == LeaveType.leaveTHHWWGB).Sum(x => x.leave_quantity),
                leaveCount = report.Leaves.Where(x => x.leave_type == LeaveType.leave).Sum(x => x.leave_quantity),
                leaveordinationCount = report.Leaves.Where(x => x.leave_type == LeaveType.leaveordination).Sum(x => x.leave_quantity),
                leaveforfastingCount = report.Leaves.Where(x => x.leave_type == LeaveType.leaveforfasting).Sum(x => x.leave_quantity),
                leavespouseCount = report.Leaves.Where(x => x.leave_type == LeaveType.leavespouse).Sum(x => x.leave_quantity),
                leaveforstudyCount = report.Leaves.Where(x => x.leave_type == LeaveType.leaveforstudy).Sum(x => x.leave_quantity),
                report.Leaves,

            };
        }
    }
}
