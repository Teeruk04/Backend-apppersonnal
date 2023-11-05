using Backend.DTOS.Arrests;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ArrestService : IArrestService
    {
        private readonly DatabaseContext databaseContext;

        public ArrestService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Arrest arrest)
        {
            await databaseContext.Arrests.AddAsync(arrest);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object arrest)
        {
            databaseContext.Arrests.Remove((Arrest)arrest);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Arrest>> FindAll()
        {
            var arrest = await databaseContext.Arrests.ToListAsync();
            return arrest;
        }

        public async Task<object> FindByArrestId(int id)
        {
            return await databaseContext.Arrests.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(ArrestUpdate data, int id)
        {
            var result = await databaseContext.Arrests.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.Arrest_date = data.Arrest_date;
            result.Arrest_crimescene = data.Arrest_crimescene;
            result.Arrest_plaint = data.Arrest_plaint;
            result.Arrest_outcomeofthecase = data.Arrest_outcomeofthecase;

            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
        }
    }
}
