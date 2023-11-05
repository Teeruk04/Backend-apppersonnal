using Backend.Models;

namespace Backend.DTOS.Travels
{
    public class TravelResponse
    {
        static public object FromTravel(Travel travel)
        {
            return new
            {
                travel.travel_startdate,
                travel.travel_enddate,
                travel.travel_city,
                travel.travel_county,
                travel.travel_purpose,
                travel.travel_capital,
                travel.Cratedate,
            };
        }
    }
}
