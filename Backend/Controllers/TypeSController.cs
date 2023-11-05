using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class TypeSController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;

        public TypeSController(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetTypeS()
        {
            return Ok(await databaseContext.TypeS.ToListAsync());
        }
    }
}
