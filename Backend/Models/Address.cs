using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Address
    {
        public int Id { get; set; }
        public DateTime address_startdate { get; set; }
        public DateTime? address_enddate     { get; set; }
        public string? address_housenumber { get; set; }
        public string? address_alley { get; set; }
        public string? address_road { get; set; }
        public string address_canton { get; set; }
        public string address_district { get; set; }
        public string address_province { get; set; }
        public string address_country { get; set; }
        public DateTime Createdate { get; set; }
        public int id_statusA { get; set; }
        [ForeignKey("id_statusA")]
        public virtual StatusA StatusA { get; set; }


    }
}
