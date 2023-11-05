using Backend.DTOS.Travels;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ITravelService
    {

        Task<IEnumerable<Travel>> FindAll();
        Task<object> FindByTravelId(int id);
        Task<object> Update(TravelUpdate data, int id);
        Task Create(Travel travel);
        Task Delete(object travel);
    }
}
