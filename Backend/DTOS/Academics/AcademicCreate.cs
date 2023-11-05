namespace Backend.DTOS.Academics
{
    public class AcademicCreate
    {
        public string academic_position { get; set; }
        public string academic_branchcode { get; set; }
        public string academic_branchname { get; set; }
        public DateTime academic_startdate { get; set; }
        public string academic_refer { get; set; }
        public IFormFileCollection? FormFile { get; set; }

    }
}
