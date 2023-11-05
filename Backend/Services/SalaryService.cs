using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly DatabaseContext databaseContext;

        public SalaryService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Create(Salary salary)
        {
            await databaseContext.Salarys.AddAsync(salary);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object salary)
        {
            databaseContext.Salarys.Remove((Salary)salary);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Salary>> FindAll()
        {
            var salaries = await databaseContext.Salarys.Include(x=>x.Types).Include(x=>x.Status).ToListAsync();
            return salaries;
        }

        public async Task<object> FindBySalaryId(int id)
        {
            return await databaseContext.Salarys.Include(x => x.Types).Include(x => x.Status).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }
    }
}
