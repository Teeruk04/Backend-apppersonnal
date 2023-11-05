using Backend.Models;

namespace Backend.DTOS.Activities
{
    public class ActivityResponse
    {
        static public object FormActivity(Activity activity)
        {
            return new
            {
                activity.Id,
                activity.Activi_startdate,
                activity.Activi_enddate,
                activity.Activi_placename,
                activity.Activi_position,
                activity.createdate,
            };
        }
    }
}
