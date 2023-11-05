using Backend.DTOS.Addresss;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class AddressService : IAddressService
    {
        private readonly DatabaseContext databaseContext;

        public AddressService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Address address)
        {
            await databaseContext.Addresss.AddAsync(address);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object address)
        {
            databaseContext.Addresss.Remove((Address)address);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Address>> FindAll()
        {
            var Addresss = await databaseContext.Addresss.Include(x => x.StatusA).ToListAsync();
            return Addresss;
        }

        public async Task<object> FindByAddressId(int id)
        {
            return await databaseContext.Addresss.Include(x => x.StatusA).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(AddressUpdate data, int id)
        {
            var result = await databaseContext.Addresss.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.address_startdate = data.address_startdate;
            result.address_enddate = data.address_enddate;
            result.address_housenumber= data.address_housenumber;
            result.address_alley = data.address_alley;
            result.address_road =data.address_road;
            result.address_canton= data.address_canton;
            result.address_district= data.address_district;
            result.address_province= data.address_province;
            result.address_country= data.address_country;
            result.id_statusA= data.id_statusA;
            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };

        }
    }
}
