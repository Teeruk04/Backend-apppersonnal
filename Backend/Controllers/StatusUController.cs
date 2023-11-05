using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class StatusUController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IStatusUService statusUService;

        public StatusUController(DatabaseContext databaseContext,IStatusUService statusUService)
        {
            this.databaseContext = databaseContext;
            this.statusUService = statusUService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetStatusU()
        {
            return Ok(await databaseContext.StatusUs.ToListAsync());
        }
    }
}
