using Backend.Models;

namespace Backend.DTOS.ReportLeaves
{
    public class ReportLeaveResponse
    {
        static public object FromReportLeave(ReportLeave reportLeave)
        {
            return new
            {
                reportLeave.Id,
                reportLeave.ReportL_lastyear,
                reportLeave.ReportL_thisyear,
                reportLeave.ReportL_leavesick,
                reportLeave.ReportL_leavepersonal,
                reportLeave.ReportL_leavematerntity,
                reportLeave.ReportL_leaveTHHWWGB,
                reportLeave.ReportL_leave,
                reportLeave.ReportL_leaveordination,
                reportLeave.ReportL_leaveforfasting,
                reportLeave.ReportL_leavespouse,
                reportLeave.ReportL_leaveforstudy

            };
        }

        static public object ReportLeave(ReportLeave reportLeave)
        {
            return new
            {
                reportLeave.ReportL_lastyear,
                reportLeave.ReportL_thisyear,
                reportLeave.ReportL_leavesick,
                reportLeave.ReportL_leavepersonal,
                reportLeave.ReportL_leavematerntity,
                reportLeave.ReportL_leaveTHHWWGB,
                reportLeave.ReportL_leave,
                reportLeave.ReportL_leaveordination,
                reportLeave.ReportL_leaveforfasting,
                reportLeave.ReportL_leavespouse,
                reportLeave.ReportL_leaveforstudy,


            };
        }
    }
}
