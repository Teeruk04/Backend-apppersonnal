using Backend.DTOS.Travels;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class TravelService : ITravelService
    {
        private readonly DatabaseContext databaseContext;

        public TravelService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Create(Travel travel)
        {
            await databaseContext.Travels.AddAsync(travel);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object travel)
        {
            databaseContext.Travels.Remove((Travel)travel);
            await databaseContext.SaveChangesAsync();
        }
        public async Task<IEnumerable<Travel>> FindAll()
        {
            var Travel = await databaseContext.Travels.ToListAsync();
            return Travel;
        }

        public async Task<object> FindByTravelId(int id)
        {
            return await databaseContext.Travels.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(TravelUpdate data, int id)
        {
            var result = await databaseContext.Travels.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.travel_startdate = data.travel_startdate;
            result.travel_enddate  = data.travel_enddate;
            result.travel_city = data.travel_city;
            result.travel_county = data.travel_county;
            result.travel_purpose = data.travel_purpose;
            result.travel_capital = data.travel_capital;

            await databaseContext.SaveChangesAsync();
            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
        }
    }
}
