using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class TitleMController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;

        public TitleMController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
       [HttpGet("[action]")]
        public async Task<IActionResult> GetTitleM()
        {
            return Ok(await databaseContext.TitleMs.ToListAsync());
        }
    }
}
