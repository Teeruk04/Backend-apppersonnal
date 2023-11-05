using Backend.DTOS.Managementpositions;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class ManagePController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IManagePService managePService;

        public ManagePController(DatabaseContext databaseContext,IManagePService managePService)
        {
            this.databaseContext = databaseContext;
            this.managePService = managePService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetManageP()
        {
            var managePs = (await managePService.FindAll()).Select(ManagePResponse.FromManageP);
            return Ok(managePs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetManagePById(int id)
        {
            var data = await managePService.FindByManahePId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Managementposition>> CreateManageP([FromForm] ManagePCreate managePCreate, int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Managementpositions).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var newManageP = new Managementposition
            {
                manageP_position = managePCreate.manageP_position,
                manageP_agency = managePCreate.manageP_agency,
                manageP_details = managePCreate.manageP_details,
                manageP_startdate = managePCreate.manageP_startdate,
                manageP_enddate = managePCreate.manageP_enddate,
                manageP_refer = managePCreate.manageP_refer,
                id_statusS = managePCreate.id_statusS,
                Createdate = DateTime.Now,
            };
            user.Managementpositions.Add(newManageP);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "Ok", user });
        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Managementposition>> DeleteEducation( int id)
        {
            var education = await managePService.FindByManahePId(id);
            if (education == null) return NotFound();

            await managePService.Delete(education);
            return NoContent();
        }

        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Managementposition>> FindByUserId(int userid,[FromQuery] string? search = "")
        {
            var user = await databaseContext.Users.Include(x => x.Managementpositions).ThenInclude(x=>x.Status).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var managements = user.Managementpositions.Where(x =>
            x.manageP_position.Contains(search) ||
            x.manageP_agency.Contains(search) ||
            x.manageP_startdate.Year.ToString().Contains(search) ||
            x.Status.Name.Contains(search));
            return Ok(managements);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateManagePC ([FromForm] ManagementPCUpdate data,int id)
        {
            try
            {
                return Ok(await managePService.Update(data, id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }

    }
}
