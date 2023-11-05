using Backend.DTOS.Childs;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ChildService : IChildService
    {
        private readonly DatabaseContext databaseContext;

        public ChildService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Child child)
        {
            await databaseContext.Childrens.AddAsync(child);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object child)
        {
            databaseContext.Childrens.Remove((Child)child);
            await databaseContext.SaveChangesAsync();
        }

        public async  Task<IEnumerable<Child>> FindAll()
        {
            var childs = await databaseContext.Childrens.Include(x => x.Title).ToListAsync();
            return childs;
        }

        public async Task<object> FindByChildId(int id)
        {
            return await databaseContext.Childrens.Include(x => x.Title).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(ChildUpdate data, int id)
        {
            var result = await databaseContext.Childrens.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.id_title = data.id_title;
            result.Child_name = data.Child_name;
            result.Child_lastname = data.Child_lastname;
            result.Child_birthdate =data.Child_birthdate;
            result.Child_race = data.Child_race;
            result.Child_nationlyty = data.Child_nationality;
            result.Child_religion = data.Child_religion;
            result.Chaild_address = data.Child_address;
            result.Child_occupation = data.Child_occuopation;
            result.Child_position =data.Child_position;
            result.Child_workplace = data.Child_workkplace;
            result.Child_phone = data.Child_phone;

            await databaseContext.SaveChangesAsync();
            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
        }
    }
}
