using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class StatusMController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;

        public StatusMController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStatusM()
        {
            return Ok(await databaseContext.StatusMs.ToListAsync());

        }
    }
}