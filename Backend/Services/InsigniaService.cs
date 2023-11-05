using Backend.DTOS.Insignias;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class InsigniaService : IInsigniaService
    {
        private readonly DatabaseContext databaseContext;

        public InsigniaService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Insignia insignia)
        {
            await databaseContext.Insignias.AddAsync(insignia);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object insignia)
        {
            databaseContext.Insignias.Remove((Insignia)insignia);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Insignia>> FindAll()
        {
            var insignias = await databaseContext.Insignias.ToListAsync();
            return insignias;
        }

        public async Task<object> FindByInsigniaId(int id)
        {
            return await databaseContext.Insignias.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(InsigniaUpdate data, int id)
        {
            var result = await databaseContext.Insignias.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.insignia_name = data.insignia_name;
            result.insignia_year = data.insignia_year;
            result.insignia_receiveddate = data.insignia_receiveddate;

            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };

        }
    }
}
