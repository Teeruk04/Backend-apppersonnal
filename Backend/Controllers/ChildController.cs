using Backend.DTOS.Childs;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class ChildController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IChildService childService;

        public ChildController(DatabaseContext databaseContext, IChildService childService)
        {
            this.databaseContext = databaseContext;
            this.childService = childService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetChild()
        {
            var childs = (await childService.FindAll()).Select(ChildResponse.FromChild);
            return Ok(childs);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetChildById(int id)
        {
            var data = await childService.FindByChildId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Child>> CreateChild ([FromForm] ChildCreate childCreate,int userid)
        {
            var user = await databaseContext.Users.Include(x => x.children).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newChild = new Child
            {
                Child_name = childCreate.Child_name,
                Child_lastname = childCreate.Child_lastname,
                Child_birthdate = childCreate.Child_birthdate,
                Child_race = childCreate.Child_race,
                Child_nationlyty = childCreate.Child_nationality,
                Child_religion = childCreate.Child_religion,
                Chaild_address = childCreate.Child_address,
                Child_occupation = childCreate.Child_occuopation,
                Child_position = childCreate.Child_position,
                Child_workplace = childCreate.Child_workkplace,
                Child_phone = childCreate.Child_phone,
                Createdate = DateTime.Now,
                id_title = childCreate.id_title,
            };
            user.children.Add(newChild);

        
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "Ok", user });


        }

        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Child>> DeleteChild( int id)
        {
            var child = await childService.FindByChildId(id);
            if (child == null) return NotFound();

            await childService.Delete(child);
            return NoContent();
        }
        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Child>> FindByUserId(int userid)
        {
            var user = await databaseContext.Users.Include(x => x.children).ThenInclude(x=>x.Title).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            return Ok(user.children);


        }
        

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateChaild ([FromForm] ChildUpdate data,int id)
        {
            try
            {
                return Ok(await childService.Update(data, id));
            }catch(Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }

    }
}
