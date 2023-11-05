using Backend.Interfaces;
using Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.Services
{
    public class TitleService : ITitleService
    {
        private readonly DatabaseContext databaseContext;

        public TitleService(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<IEnumerable<Title>> FindAll()
        {
            var titles = await databaseContext.Titles.ToListAsync();
            return titles;
        }
    }
}
