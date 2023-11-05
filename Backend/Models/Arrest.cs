namespace Backend.Models
{
    public class Arrest
    {
        public int Id { get; set; }
        public DateTime Arrest_date { get; set; }
        public string Arrest_crimescene { get; set; }
        public string Arrest_plaint { get; set; }
        public string Arrest_outcomeofthecase { get; set; }
        public DateTime Createdate { get; set; }
    }
}
