using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class StatusSController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;

        public StatusSController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStatusS()
        {
            return Ok(await databaseContext.Statuses.ToListAsync());
        }

    }
}
