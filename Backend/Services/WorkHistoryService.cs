using Backend.DTOS.WorkHitories;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class WorkHistoryService : IWorkHistoryService
    {
        private readonly DatabaseContext databaseContext;

        public WorkHistoryService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task Create(Workhistory workhistory)
        {
            await   databaseContext.WorkHistories.AddAsync(workhistory);    
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object workhistory)
        {
            databaseContext.WorkHistories.Remove((Workhistory)workhistory);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Workhistory>> FindAll()
        {
            var workHistories = await databaseContext.WorkHistories.ToListAsync();
            return workHistories;
        }

        public async Task<object> FindByWorkHistoryId(int id)
        {
            return await databaseContext.WorkHistories.SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(WorkHistoryUpdate data, int id)
        {
            var result = await databaseContext.WorkHistories.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.WorkH_startdate = data.WorkH_startdate;
            result.WorkH_enddate = data.WorkH_enddate;
            result.WorkH_employer = data.WorkH_employer;
            result.WorkH_placename = data.WorkH_placename;
            result.WorkH_position = data.WorkH_position;
            result.WorkH_reason = data.WorkH_reason;

            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
        }
    }
}
