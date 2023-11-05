using Backend.Models;

namespace Backend.DTOS.WorkHitories
{
    public class WorkHistoryResponse
    {
        static public object FormWorkHitory(Workhistory workHistory)
        {
            return new
            {
                workHistory.Id,
                workHistory.WorkH_startdate,
                workHistory.WorkH_enddate,
                workHistory.WorkH_employer,
                workHistory.WorkH_placename,
                workHistory.WorkH_position,
                workHistory.WorkH_reason,
                workHistory.createdate,
            };
        }
    }
}
