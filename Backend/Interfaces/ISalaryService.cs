using Backend.Models;

namespace Backend.Interfaces
{
    public interface ISalaryService
    {
        Task<IEnumerable<Salary>> FindAll();
        Task<object> FindBySalaryId(int id);
        Task Create(Salary salary);
        Task Delete(object salary);
    }
}
