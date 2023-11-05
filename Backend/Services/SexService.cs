using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class SexService : ISexService
    {
        private readonly DatabaseContext databaseContext;

        public SexService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<IEnumerable<Sex>> FindAll()
        {
            var sexs = await databaseContext.Sexs.ToListAsync();
            return sexs;
        }
    }
}
