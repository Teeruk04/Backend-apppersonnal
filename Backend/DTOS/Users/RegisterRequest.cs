using System.ComponentModel.DataAnnotations;

namespace Backend.DTOS.Users
{
    public class RegisterRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(3)]
        public string Password { get; set; }
        [Required]
        public string User_name {get;set;}
        [Required]
        public string User_lastname { get;set;}
        public string User_cardnumber { get;set;}
        public string User_birthdate { get;set;}
        public string User_placeofbirth { get;set;}
        public string User_race { get;set;}
        public string User_nationality { get;set;}
        public string User_religion { get;set;}
        public IFormFileCollection? FormFile { get; set; }
        public DateTime createdate { get;set;}
        public int id_title { get;set;}
        public int id_statusU { get;set;}
        public int id_sex { get;set;}



    }
}
