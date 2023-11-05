using Backend.DTOS.FatherAndMothers;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class FaAndMoService : IFaAndMoService
    {
        private readonly DatabaseContext databaseContext;

        public FaAndMoService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(FatherAndMother fatherandmother)
        {
            await databaseContext.FatherAndMothers.AddAsync(fatherandmother);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object fatherandmother)
        {
            databaseContext.FatherAndMothers.Remove((FatherAndMother) fatherandmother);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<FatherAndMother>> FindAll()
        {
            var faAndmo = await databaseContext.FatherAndMothers.Include(x=>x.Title).Include(x=>x.TitleM).ToListAsync();
            return faAndmo;
        }

        public async Task<object> FindByFatherAndMotherId(int id)
        {
            return await databaseContext.FatherAndMothers.Include(x=>x.Title).Include(x=>x.TitleM).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(FAtherAndMotherUpdate data, int id)
        {
            var result = await databaseContext.FatherAndMothers.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.fa_name = data.fa_name;
            result.fa_lastname = data.fa_lastname;
            result.fa_birthdate = data.fa_birthdate;
            result.fa_placebirth = data.fa_placebirth;
            result.fa_race = data.fa_race;
            result.fa_religion = data.fa_religion;
            result.fa_nationality = data.fa_nationality;
            result.fa_address = data.fa_address;
            result.fa_phone = data.fa_phone;
            result.fa_occupation = data.fa_occupation;
            result.fa_position = data.fa_position;
            result.fa_workplace = data.fa_workplace;
            result.fa_WPphone = data.fa_WPphone;
            result.MO_title = data.mo_title;
            result.mo_name = data.mo_name;
            result.mo_lastname = data.mo_lastname;
            result.mo_birthdate = data.mo_birthdate;
            result.mo_placebirth = data.mo_placebirth;
            result.mo_race = data.mo_race;
            result.mo_religion = data.mo_religion;
            result.mo_nationality = data.mo_nationality;
            result.mo_address= data.mo_address;
            result.mo_phone = data.mo_phone;
            result.mo_occupation = data.mo_occupation;
            result.mo_position = data.mo_position;
            result.mo_workplace = data.mo_workplace;
            result.mo_WPphone = data.mo_WPphone;

            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
        }
    }
}
