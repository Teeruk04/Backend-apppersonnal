using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Child
    {
        public int Id { get; set; }
        public string Child_name { get; set; }
        public string Child_lastname { get; set; }
        public DateTime Child_birthdate     { get; set; }
        public string Child_race { get; set; }
        public string Child_nationlyty { get; set; }
        public string Child_religion { get; set; }
        public string Chaild_address { get; set; }
        public string Child_occupation { get; set; }
        public string Child_position { get; set; }
        public string Child_workplace { get; set; }
        public string Child_phone { get; set; }
        public DateTime Createdate  { get; set; }

        public int id_title { get; set; }
        [ForeignKey("id_title")]
        public virtual Title Title { get; set; }
    }
}
