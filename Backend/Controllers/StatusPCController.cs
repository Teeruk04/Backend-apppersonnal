using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class StatusPCController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;

        public StatusPCController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStatusPC()
        {
            return Ok(await databaseContext.StatusPCs.ToListAsync());
        }

    }
}
