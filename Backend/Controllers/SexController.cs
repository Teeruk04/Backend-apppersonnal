using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class SexController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly ISexService sexService;

        public SexController(DatabaseContext databaseContext, ISexService sexService)
        {
            this.databaseContext = databaseContext;
            this.sexService = sexService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSex()
        {
            return Ok(await databaseContext.Sexs.ToListAsync());
        }
    }
}
