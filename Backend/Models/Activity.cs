namespace Backend.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public DateTime Activi_startdate { get; set; }
        public DateTime Activi_enddate { get; set; }
        public string Activi_placename { get; set; }
        public string Activi_position { get; set;}
        public DateTime createdate { get; set;}
    }
}
