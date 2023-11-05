using Backend.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public LeaveType leave_type { get; set; }
        public float leave_quantity { get; set; }
        public DateTime leave_startdate { get; set; }
        public DateTime leave_enddate { get; set; }
        public string leave_note { get; set; }
        public DateTime createdate { get; set; } = DateTime.Now;


    }
}
