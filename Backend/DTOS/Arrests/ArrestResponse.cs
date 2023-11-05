using Backend.Models;

namespace Backend.DTOS.Arrests
{
    public class ArrestResponse
    {
        static public object FormArrest(Arrest arrest)
        {
            return new
            {
                arrest.Id,
                arrest.Arrest_date,
                arrest.Arrest_crimescene,
                arrest.Arrest_plaint,
                arrest.Arrest_outcomeofthecase,
                arrest.Createdate,
            };
        }
    }
}
