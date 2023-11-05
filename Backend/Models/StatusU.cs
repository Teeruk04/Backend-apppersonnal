namespace Backend.Models
{
    public partial class StatusU
    {
        public int Id { get; set; }
        public string StatusU_name { get; set; }
        public DateTime createdate { get; set; } = DateTime.Now;
    }
}
