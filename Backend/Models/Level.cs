namespace Backend.Models
{
    public class Level
    {
        public int Id { get; set; }
        public string Level_name { get; set; }
        public DateTime Createdate  { get; set; } = DateTime.Now;
    }
}
