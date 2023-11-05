namespace Backend.DTOS.Educations
{
    public class EducationUpdate
    {
        public DateTime Educa_startdate { get; set; }
        public DateTime Educa_enddate { get; set; }
        public String Educa_placename { get; set; }
        public String Educa_location { get; set; }
        public String Educa_course { get; set; }
        public String Educa_results { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public int id_level { get; set; }
    }
}
