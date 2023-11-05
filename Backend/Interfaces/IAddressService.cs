using Backend.DTOS.Addresss;
using Backend.Models;

namespace Backend.Interfaces
{
    public interface IAddressService
    {
        Task<IEnumerable<Address>> FindAll();
        Task<object> FindByAddressId(int id);
        Task<object> Update(AddressUpdate data, int id);
        Task Create(Address address);
        Task Delete(object address);
    }
}
