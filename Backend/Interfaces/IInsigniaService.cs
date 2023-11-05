using Backend.DTOS.Insignias;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IInsigniaService
    {
        Task<IEnumerable<Insignia>> FindAll();
        Task<object> FindByInsigniaId(int id);
        Task<object> Update(InsigniaUpdate data, int id);
        Task Create(Insignia insignia);
        Task Delete(object insignia);
    }
}
