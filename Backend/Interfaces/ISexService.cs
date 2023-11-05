using Backend.Models;

namespace Backend.Interfaces
{
    public interface ISexService
    {
        Task<IEnumerable<Sex>> FindAll();
    }
}
