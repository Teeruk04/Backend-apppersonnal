namespace Backend.DTOS.Users
{
    public class UserUpdate
    {
       
        public string User_name { get; set; }
        public string User_lastname { get; set; }
        public string User_cardnumber { get; set; }
        public DateTime User_birthdate { get; set; }
        public string User_placeofbirth { get; set; }
        public string User_race { get; set; }
        public string User_nationality { get; set; }
        public string User_religion { get; set; }
        public IFormFileCollection? FormFile { get; set; }
        public int id_title { get; set; }
        public int id_statusU { get; set; }
        public int id_sex { get; set; }
    }
}
