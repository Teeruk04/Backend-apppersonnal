using Backend.DTOS.Arrests;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IArrestService
    {
        Task<IEnumerable<Arrest>> FindAll();
        Task<object> FindByArrestId(int id);
        Task<object> Update(ArrestUpdate data, int id);
        Task Create(Arrest arrest);
        Task Delete(object arrest);
    }
}
