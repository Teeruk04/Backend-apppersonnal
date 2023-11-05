namespace Backend.Models
{
    public partial class Sex
    {
        public int Id { get; set; }
        public string Sex_name { get; set; }
        public DateTime createdate { get; set; } = DateTime.Now;
    }
}
