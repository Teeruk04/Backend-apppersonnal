using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class LevelController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;

        public LevelController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetLevel()
        {
            return Ok(await databaseContext.Levels.ToListAsync());
        }
    }
}
