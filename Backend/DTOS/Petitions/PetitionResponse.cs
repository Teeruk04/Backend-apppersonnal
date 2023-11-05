using Backend.Models;

namespace Backend.DTOS.Petitions
{
    public class PetitionResponse
    {
        private class Author
        {
            public int Id { get; set; }
            public string user_name { get; set; }
            public string user_lastname { get; set; }

            public Author(User user) { 
                this.Id = user.Id;
                this.user_name = user.User_name;
                this.user_lastname = user.User_lastname;
            }
        }

        static public object FromPetition(Petition petition)
        {
            return new
            {
                petition.Id,
                petition.peti_message,
                petition.File,
                petition.peti_staus,
                petition.Createdate,
                Author = new Author(petition.Author)
            };
        }
    }
}
