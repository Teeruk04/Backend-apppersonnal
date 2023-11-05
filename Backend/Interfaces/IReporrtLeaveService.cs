using Backend.Models;

namespace Backend.Interfaces
{
    public interface IReporrtLeaveService
    {
        Task<IEnumerable<ReportLeave>> FindAll();
        Task<object> FindByreportLeaveId(int id);
        Task Create(ReportLeave reportLeave);
        Task Delete(object reportLeave);

    }
}
