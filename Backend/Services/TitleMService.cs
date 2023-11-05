using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class TitleMService : ITiTleMService
    {
        private readonly DatabaseContext databaseContext;

        public TitleMService(DatabaseContext  databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<TitleM>> FindAll()
        {
            var titleMs = await databaseContext.TitleMs.ToListAsync();
            return titleMs;
        }
    }
}
