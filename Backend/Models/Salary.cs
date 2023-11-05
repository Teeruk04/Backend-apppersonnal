using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public string salary_details { get; set; }
        public string salary_ordernum { get; set; }
        public DateTime salary_datenum { get; set; }
        public DateTime salary_effectivedate { get; set; }
        public DateTime? salary_enddate { get; set; }
        public float salary_salary { get; set; }
        public int salary_beforepostpone { get; set; }
        public  float salary_percentage { get; set; }
        public int salary_calculationbase { get; set; }
        public DateTime Createdate  { get; set; }


        public int id_starusS { get; set; }
        [ForeignKey("id_starusS")]
        public Status Status { get; set; }  

        public int id_TypeS { get; set; }
        [ForeignKey("id_TypeS")]
        public TypeS Types { get; set; }
    }
}
