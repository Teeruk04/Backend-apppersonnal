using Backend.DTOS.Managementpositions;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class ManagePService : IManagePService
    {
        private readonly DatabaseContext databaseContext;

        public ManagePService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task Create(Managementposition managementposition)
        {
            await databaseContext.Managementpositions.AddAsync(managementposition);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(object managementposition)
        {
            databaseContext.Managementpositions.Remove((Managementposition) managementposition);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Managementposition>> FindAll()
        {

            var managePs = await databaseContext.Managementpositions.Include(x => x.Status).ToListAsync();
            return managePs;
        }

        public async Task<object> FindByManahePId(int id)
        {
            return await databaseContext.Managementpositions.Include(x => x.Status).SingleOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<object> Update(ManagementPCUpdate data, int id)
        {
            var result = await databaseContext.Managementpositions.FirstOrDefaultAsync(a => a.Id.Equals(id));
            if (result is null) return new { statusCode = 400, message = "ไม่พบข้อมูล" };

            result.manageP_position = data.manageP_position;
            result.manageP_agency = data.manageP_agency;
            result.manageP_details = data.manageP_details;
            result.manageP_startdate = data.manageP_startdate;
            result.manageP_enddate = data.manageP_enddate;
            result.manageP_refer = data.manageP_refer;
            result.id_statusS = data.id_statusS;

            await databaseContext.SaveChangesAsync();

            return new { statusCode = 200, message = "อัพเดตสำเร็จ" };

        }
    }
}
