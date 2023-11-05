namespace Backend.Models
{
    public class Academicposition
    {
        public int Id { get; set; }
        public string academic_position { get; set; }
        public string academic_branchcode { get; set; }
        public string academic_branchname { get; set; }
        public DateTime academic_startdate { get; set; }
        public string academic_refer { get; set; }
        public string File { get; set; }
        public DateTime Createdate { get; set; }
    }
}
