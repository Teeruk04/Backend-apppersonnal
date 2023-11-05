using Backend.DTOS.Marriages;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IMarriagesService
    {
        Task<IEnumerable<Marriage>> FindAll();
        Task<object> FindByMarraigeId(int id);
        Task<object> Update(MarriagesUpdate data,int id);
        Task Create(Marriage marriage);
        Task Delete(object marriage);
    }
}
