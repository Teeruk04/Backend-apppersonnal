using Backend.Models;

namespace Backend.DTOS.Academics
{
    public class AcademicResponse
    {
        static public object FromAcademic(Academicposition academicposition)
        {
            return new
            {
                academicposition.Id,
                academicposition.academic_position,
                academicposition.academic_branchcode,
                academicposition.academic_branchname,
                academicposition.academic_startdate,
                academicposition.academic_refer,
                academicposition.File,
                academicposition.Createdate
            };
        }
    }
}
