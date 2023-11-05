using Backend.DTOS.Leaves;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface ILeaveService
    {
        Task<IEnumerable<Leave>> FindAll();
        Task<object> FindById(int id);
        Task<object> Update(LeaveUpdate data, int id);
        Task Create(Leave leave);
        Task Delete(object leave);
    }
}
