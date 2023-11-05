using Backend.DTOS.Childs;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IChildService
    {
        Task<IEnumerable<Child>> FindAll();
        Task<object> FindByChildId(int id);
        Task<object> Update(ChildUpdate data, int id);
        Task Create(Child child);
        Task Delete(object child);
    }
}
