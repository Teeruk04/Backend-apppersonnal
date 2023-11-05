using Backend.Models;

namespace Backend.DTOS.Marriages
{
    public class MarriagesResponse
    {
        static public object FormMarriage(Marriage marriage)
        {
            return new
            {
                marriage.Id,
               TitleName = marriage.Title.Title_name,
                marriage.marria_name,
                marriage.marria_lastname,
                marriage.marria_birdate,
                marriage.marria_race,
                marriage.marria_religion,
                marriage.marria_nationality,
                marriage.marria_occupation,
                marriage.marria_position,
                marriage.marria_workplace,
                marriage.marria_WPphone,
                marriage.marriia_weddingday,
                marriage.marria_address,
                marriage.marria_phone,
                marriage.marria_divorce,
                marriage.marria_lastaddress,
                StatusPCName = marriage.StatusPC.statusPC_name
            };
        }
    }
}
