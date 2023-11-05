using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class FatherAndMother
    {
        public int Id { get; set; }
        public string fa_name { get; set; }
        public string fa_lastname { get; set; }
        public DateTime fa_birthdate { get; set; }
        public string fa_placebirth { get; set; }
        public string fa_race { get; set; }
        public string fa_religion   { get; set; }
        public string fa_nationality { get; set; }
        public string fa_address { get; set; }
        public string fa_phone { get; set; }
        public string fa_occupation { get; set; }
        public string fa_position { get; set; }
        public string fa_workplace { get; set; }
        public string fa_WPphone { get; set; }
        public string mo_name { get; set; }
        public string mo_lastname { get; set; }
        public DateTime mo_birthdate { get; set; }
        public string mo_placebirth { get; set; }
        public string mo_race { get; set; }
        public string mo_religion { get; set; }
        public string mo_nationality { get; set; }
        public string mo_address { get; set; }
        public string mo_phone  { get; set; }
        public string mo_occupation     { get; set; }
        public string mo_position { get; set; }
        public string mo_workplace { get; set; }
        public string mo_WPphone { get; set; }
        public DateTime Createdate { get; set; }


        public int Fa_title { get; set; }
        [ForeignKey("Fa_title")]
        public  Title Title { get; set; }

        public int MO_title { get; set; }
        [ForeignKey("MO_title")]
        public  TitleM TitleM { get; set; }
    }
}
