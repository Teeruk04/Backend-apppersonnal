using Backend.Models;

namespace Backend.Interfaces
{
    public interface ITiTleMService
    {
        Task<IEnumerable<TitleM>> FindAll();
    }
}
