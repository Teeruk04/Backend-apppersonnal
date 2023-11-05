using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class ReportLeave
    {

        public int Id { get; set; }
        public  float ReportL_lastyear { get; set; }
        public float ReportL_thisyear { get; set; }
        public float ReportL_leavesick { get; set; }
        public float ReportL_leavepersonal { get; set; }
        public int ReportL_leavematerntity { get; set; }
        public int ReportL_leaveTHHWWGB { get; set; }
        public float ReportL_leave { get; set; }
        public int ReportL_leaveordination{ get; set; }
        public int ReportL_leaveforfasting { get; set; }
        public int ReportL_leavespouse { get; set; }
        public int ReportL_leaveforstudy { get; set; }
        public DateTime createdate { get; set; }


        public ICollection<Leave> Leaves { get; set; } = new List<Leave>();

        

    }
}
