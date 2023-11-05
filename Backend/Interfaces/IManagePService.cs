using Backend.DTOS.Managementpositions;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IManagePService
    {
        Task<IEnumerable<Managementposition>> FindAll();
        Task<object> FindByManahePId(int id);
        Task<object> Update(ManagementPCUpdate data, int id);
        Task Create(Managementposition managementposition);
        Task Delete(object managementposition);
    }
}
