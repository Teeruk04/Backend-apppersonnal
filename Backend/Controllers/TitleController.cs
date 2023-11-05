using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class TitleController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly ITitleService titleService;

        public TitleController(DatabaseContext databaseContext, ITitleService titleService)
        {
            this.databaseContext = databaseContext;
            this.titleService = titleService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTitle()
        {
            return Ok(await databaseContext.Titles.ToListAsync());
        }
    }
}
