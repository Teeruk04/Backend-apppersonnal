using Backend.DTOS.WorkHitories;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IWorkHistoryService
    {
        Task<IEnumerable<Workhistory>> FindAll();
        Task<object> FindByWorkHistoryId(int id);
        Task<object> Update(WorkHistoryUpdate data, int id);
        Task Create(Workhistory workhistory);
        Task Delete(object workhistory);
    }
}
