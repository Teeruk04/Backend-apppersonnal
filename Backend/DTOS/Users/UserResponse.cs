using Backend.Models;

namespace Backend.DTOS.Users
{
    public class UserResponse
    {
        static public object FromUser(User user)
        {
            return new
            {
                user.Id,
                user.Email,
                user.User_name,
                user.User_lastname,
                user.User_cardnumber,
                user.User_birthdate,
                user.User_placeofbirth,
                user.User_race,
                user.User_nationality,
                user.User_religion,
                user.Field,
                user.Createdate,

                Titlename = user.Title.Title_name,
                statusUname = user.StatusU.StatusU_name,
                sexname = user.Sex.Sex_name,
            };
        }
    }
}
