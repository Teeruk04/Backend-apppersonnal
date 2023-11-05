using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class StatusAController : BaseApiController
    {
        private readonly DatabaseContext databasecontext;

        public StatusAController(DatabaseContext databasecontext)
        {
            this.databasecontext = databasecontext;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetStatusA()
        {
            return Ok(await databasecontext.StatusAs.ToListAsync());

        }
    }
}
