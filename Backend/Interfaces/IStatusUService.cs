using Backend.Models;

namespace Backend.Interfaces
{
    public interface IStatusUService
    {
        Task<IEnumerable<StatusU>> FindAll();
    }
}
