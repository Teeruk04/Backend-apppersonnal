using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class StatusUService : IStatusUService
    {
        private readonly DatabaseContext databaseContext;

        public StatusUService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<StatusU>> FindAll()
        {
            var statusUs = await databaseContext.StatusUs.ToListAsync();
            return statusUs;
        }
    }
}
