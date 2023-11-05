using Backend.Constants;

namespace Backend.DTOS.Leaves
{
    public class LeaveUpdate
    {
        public LeaveType leave_type { get; set; }
        public DateTime leave_startdate { get; set; }
        public DateTime leave_enddate { get; set; }
        public float leave_quantity { get; set; }
        public string leave_note { get; set; }
    }
}
