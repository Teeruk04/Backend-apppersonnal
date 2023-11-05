using Backend.DTOS.Marriages;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class MarriageService : IMarriagesService
    {
        private readonly DatabaseContext databaseContext;

        public MarriageService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Marriage marriage)
        {
            await databaseContext.Marriages.AddAsync(marriage);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object marriage)
        {
            databaseContext.Marriages.Remove((Marriage)marriage);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Marriage>> FindAll()
        {
            var marriages = await databaseContext.Marriages.Include(x => x.Title).Include(x=>x.StatusPC).ToListAsync();
            return marriages;
        }

        public async Task<object> FindByMarraigeId(int id)
        {
            return await databaseContext.Marriages.Include(x => x.Title).Include(x => x.StatusPC).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(MarriagesUpdate data, int id)
        {
            var result = await databaseContext.Marriages.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };


            result.id_title = data.id_title;
            result.marria_name = data.marriage_name;
            result.marria_lastname = data.marriage_lastname;
            result.marria_birdate = data.marria_birdate;
            result.marria_race = data.marria_race;
            result.marria_religion = data.marria_religion;
            result.marria_nationality = data.marria_nationality;
            result.marria_occupation = data.marria_occupation;
            result.marria_position = data.marria_position;
            result.marria_workplace = data.marria_workplace;
            result.marria_WPphone = data.marria_WPphone;
            result.marriia_weddingday = data.marriia_weddingday;
            result.marria_address = data.marria_address;
            result.marria_phone = data.marria_phone;
            result.marria_divorce = data.marria_divorce;
            result.marria_lastaddress= data.marria_lastaddress;
            result.id_statusPC = data.id_statusPC;

            await databaseContext.SaveChangesAsync();
            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
        }
    }
}
