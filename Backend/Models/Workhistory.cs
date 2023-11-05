namespace Backend.Models
{
    public class Workhistory
    {
        public int Id { get; set; }
        public DateTime WorkH_startdate { get; set; }
        public DateTime WorkH_enddate { get; set; }
        public string WorkH_employer { get; set; }
        public string WorkH_placename { get; set; }
        public string WorkH_position    { get; set; }
        public string WorkH_reason { get; set; }
        public DateTime createdate {get; set; }
    }
}
