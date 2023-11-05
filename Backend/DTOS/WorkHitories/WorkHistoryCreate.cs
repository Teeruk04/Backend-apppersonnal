namespace Backend.DTOS.WorkHitories
{
    public class WorkHistoryCreate
    {
        public DateTime WorkH_startdate { get; set; }
        public DateTime WorkH_enddate { get;set; }
        public String WorkH_employer { get; set; }
        public String WorkH_placename { get; set; }
        public String WorkH_position { get; set; }
        public String WorkH_reason { get; set; }
    }
}
