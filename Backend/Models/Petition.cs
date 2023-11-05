using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Petition
    {
        public int Id { get; set; }
        public string peti_message { get; set; }
        public string File { get; set; }
        public string peti_staus { get; set; }
        public DateTime Createdate { get; set; }
        [JsonIgnore]
        public User Author { get; set; }
    }
}
