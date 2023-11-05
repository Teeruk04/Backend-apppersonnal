using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Education
    {
        public int Id { get; set; }
        public DateTime Educa_startdate { get; set; }
        public DateTime Educa_enddate { get; set; }
        public string Educa_placename { get; set; }
        public string Educa_location { get; set;}
        public string Educa_course { get; set; }
        public  string Educa_results    { get; set; }
        public string File { get; set; }
        public DateTime Createdat { get; set; }




        public int id_level { get; set; }
        [ForeignKey("id_level")]
        public virtual Level Level { get; set; }



    }
}
