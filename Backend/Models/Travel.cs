namespace Backend.Models
{
    public class Travel
    {
        public int Id { get; set; }
        public DateTime travel_startdate { get; set; }
        public DateTime travel_enddate { get;  set; }
        public string travel_city { get; set; }
        public string travel_county     { get; set; }
        public string travel_purpose { get; set; }
        public string travel_capital { get; set; }
        public DateTime Cratedate { get; set; }
    }
}
