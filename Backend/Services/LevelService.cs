using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class LevelService : ILevelService
    {
        private readonly DatabaseContext databaseContext;

        public LevelService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Level>> FindAll()
        {
            var levels = await databaseContext.Levels.ToListAsync();
            return levels;
        }
    }
}
