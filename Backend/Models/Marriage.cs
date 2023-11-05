using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Marriage
    {
        public int Id { get; set; }
        public string marria_name { get; set; }
        public string marria_lastname { get; set; }
        public DateTime marria_birdate { get; set; }
        public string marria_race { get; set; }
        public string marria_religion { get; set; }
        public string marria_nationality { get; set; }
        public string marria_occupation { get; set; }
        public string marria_position { get; set; }
        public string marria_workplace { get; set; }
        public string marria_WPphone { get; set; }
        public DateTime marriia_weddingday { get; set; }
        public string marria_address { get; set; }
        public string marria_phone { get; set; }
        public string marria_divorce { get; set; }
        public string marria_lastaddress { get; set; }
        public DateTime Createdate { get; set; }

     

        public int id_title { get; set; }
        [ForeignKey("id_title")]
        public virtual Title Title { get; set; }

        public int id_statusPC { get; set; }
        [ForeignKey("id_statusPC")]
        public virtual StatusPC StatusPC { get; set; }


    }
}
