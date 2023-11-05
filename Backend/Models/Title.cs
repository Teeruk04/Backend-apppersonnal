namespace Backend.Models
{
    public partial class Title
    {
        public int Id { get; set; }
        public string Title_name { get; set; }
        public DateTime createdate { get; set; } = DateTime.Now;
    }
}
