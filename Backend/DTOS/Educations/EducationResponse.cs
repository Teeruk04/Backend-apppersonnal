using Backend.Models;

namespace Backend.DTOS.Educations
{
    public class EducationResponse
    {
       
        static public object FromEucation(Education education)
        {
            return new
            {
                education.Id,
                education.Educa_startdate,
                education.Educa_enddate,
                education.Educa_placename,
                education.Educa_location,
                education.Educa_course,
                education.Educa_results,
                education.File,
                LevelName = education.Level.Level_name,
            };
        }

    }
}
