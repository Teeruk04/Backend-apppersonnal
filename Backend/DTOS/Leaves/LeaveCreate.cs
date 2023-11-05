using Backend.Constants;

namespace Backend.DTOS.Leaves
{
    public class LeaveCreate
    {
        public int user_id { get; set; }
        public LeaveType leave_type { get; set; }
        public DateTime leave_startdate { get; set; }
        public DateTime leave_enddate { get; set; }
        public string leave_note { get; set; }
    };
}
