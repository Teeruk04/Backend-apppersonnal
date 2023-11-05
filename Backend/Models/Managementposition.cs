using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Managementposition
    {
        public int Id { get; set; }
        public string manageP_position { get; set; }
        public string manageP_agency { get; set; }
        public  string manageP_details { get; set; }
        public DateTime manageP_startdate { get; set; }
        public DateTime? manageP_enddate { get; set; }
        public string manageP_refer { get; set; }
        public DateTime Createdate { get; set; }
        
        public int id_statusS { get; set; }
        [ForeignKey("id_statusS")]
        public virtual Status Status { get; set; }
    }
}
