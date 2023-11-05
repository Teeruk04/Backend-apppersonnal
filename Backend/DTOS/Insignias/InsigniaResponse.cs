using Backend.Models;

namespace Backend.DTOS.Insignias
{
    public class InsigniaResponse
    {
        static public object FromInsignia(Insignia insignia)
        {
            return new
            {
                insignia.Id,
                insignia.insignia_name,
                insignia.insignia_year,
                insignia.insignia_receiveddate,
                insignia.Createdate,
            };
        }
    }
}
