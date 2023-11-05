namespace Backend.DTOS.Activities
{
    public class ActivityUpdate
    {
        public DateTime Activity_startdate { get; set; }
        public DateTime Activity_enddate { get; set; }
        public String Activity_placename { get; set; }
        public String Activity_position { get; set; }
    }
}
