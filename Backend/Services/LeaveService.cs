using Backend.DTOS.Leaves;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class LeaveService : ILeaveService
    {
        private readonly DatabaseContext databaseContext;

        public LeaveService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Leave leave)
        {
           await databaseContext.Leaves.AddAsync(leave);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object leave)
        {
            databaseContext.Leaves.Remove((Leave) leave);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Leave>> FindAll()
        {
            var leave = await databaseContext.Leaves.ToListAsync();
            return leave;   
        }

        public async Task<object> FindById(int id)
        {
            return await databaseContext.Leaves.SingleOrDefaultAsync(x=>x.Id.Equals(id));
        }

        public async Task<object> Update(LeaveUpdate data, int id)
        {
            var result = await databaseContext.Leaves.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };


            result.leave_startdate = data.leave_startdate;
            result.leave_enddate = data.leave_enddate;
            result.leave_quantity = data.leave_quantity;
            result.leave_type = data.leave_type;
            result.leave_note = data.leave_note;
            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };

        }
    }
}
