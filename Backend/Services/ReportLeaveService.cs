using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ReportLeaveService : IReporrtLeaveService
    {
        private readonly DatabaseContext databaseContext;

        public ReportLeaveService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(ReportLeave reportLeave)
        {
          await databaseContext.ReportLeaves.AddAsync(reportLeave);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object reportLeave)
        {
            databaseContext.ReportLeaves.Remove((ReportLeave) reportLeave);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<ReportLeave>> FindAll()
        {
            var reportLeave = await databaseContext.ReportLeaves.ToListAsync();
            return reportLeave;
        }

        public async Task<object> FindByreportLeaveId(int id)
        {
            return await databaseContext.ReportLeaves.Include(x=>x.Leaves).SingleOrDefaultAsync(x=>x.Id.Equals(id));
        }
    }
}
