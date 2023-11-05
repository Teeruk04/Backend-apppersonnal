using Backend.DTOS.Activities;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ActivityService : IActivityService
    {
        private readonly DatabaseContext databaseContext;

        public ActivityService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Activity activity)
        {
            await databaseContext.Activities.AddAsync(activity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object activity)
        {
            databaseContext.Activities.Remove((Activity)activity);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Activity>> FindAll()
        {
            var  activities = await databaseContext.Activities.ToListAsync();
            return activities;
        }

        public async Task<object> FindByActivityId(int id)
        {
            return await databaseContext.Activities.SingleOrDefaultAsync(x=>x.Id.Equals(id));
        }

        public async Task<object> Update(ActivityUpdate data, int id)
        {
            var result = await databaseContext.Activities.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.Activi_startdate = data.Activity_startdate;
            result.Activi_enddate = data.Activity_enddate;
            result.Activi_placename = data.Activity_placename;
            result.Activi_position = data.Activity_position;

            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };
        }
    }
}
