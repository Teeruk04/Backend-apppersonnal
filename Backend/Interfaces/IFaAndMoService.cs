using Backend.DTOS.FatherAndMothers;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IFaAndMoService
    {
        Task<IEnumerable<FatherAndMother>> FindAll();
        Task<object> FindByFatherAndMotherId(int id);
        Task<object> Update(FAtherAndMotherUpdate data, int id);
        Task Create(FatherAndMother fatherandmother);
        Task Delete(object fatherandmother);
    }
}
