using Backend.Models;

namespace Backend.Interfaces
{
    public interface ITitleService
    {
        Task<IEnumerable<Title>> FindAll();
    }
}
