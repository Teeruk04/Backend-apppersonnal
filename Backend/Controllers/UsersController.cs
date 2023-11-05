using Backend.DTOS.Users;
using Backend.Interfaces;
using Backend.Models;
using Mapster;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUserService userService;

        public UsersController(DatabaseContext databaseContext, IUserService userService)
        {
            this.databaseContext = databaseContext;
            this.userService = userService;
        }

        //[HttpGet]
        //public async Task<ActionResult> GetUsers ()
        //{   
            
        //    return Ok(await databaseContext.Users.Include(a => a.Title).Include(a => a.StatusU).Include(a => a.Sex).ToListAsync());
        //}

        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromForm] LoginRequest loginRequest)
        {
            var user = await userService.Login(loginRequest.Email, loginRequest.Password);
            if (user == null) return BadRequest(new { StatusCode = 400 });
            var token = userService.GenerateToken(user);
            return Ok(new { StatusCode = 200, token, msg = "เข้าสุ่ระบบสำเร็จ" });
        }

         [HttpPost("[action]")]
        public async Task<IActionResult> Register([FromForm] RegisterRequest registerRequest)
        {
            (string errorMessage, string imageName) = await userService.UploadImage(registerRequest.FormFile);
            if (!string.IsNullOrEmpty(errorMessage)) return BadRequest(errorMessage);
            var user = registerRequest.Adapt<User>();
            user.Field = imageName;
            await userService.Register(user);            
            return Ok(new {StatusCode = 200, msg = "OK" });

        }

        
        [Authorize]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetByToken()
        {
            try
            {
                var userToken = await HttpContext.GetTokenAsync("access_token");
                return Ok(await userService.GetByToken(userToken));
            }
            catch (Exception e)
            {
                return BadRequest(new { StatusCode = 400, e.Message });
            }
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<User>> DeleteUser([FromQuery] int id)
        {
            var data = await databaseContext.Users.FindAsync(id);
            if (data == null) return NotFound();

            await userService.Delete(data);
            return NoContent();
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetUser([FromQuery] string? search = "")
        {
            var users = (await userService.FindAll(search)).Select(UserResponse.FromUser);
            return Ok(users);
            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserbyId(int id)
        {
            var user = await userService.FindById(id);
            //var user = (await databaseContext.Users.Include(x => x.Petitions).Include(x=>x.Education).Include(x=>x.Activity).Include(x=>x.Workhistory).Include(x=>x.Arrest).Include(x=>x.FatherAndMother).Include(x=>x.Marriage).Include(x=>x.children).Include(x=>x.Addresses).Include(x=>x.Travels).Include(x=>x.Salaries).Include(x=>x.Managementpositions).Include(x=>x.Academicpositions).Include(x=>x.Insignias).FirstOrDefaultAsync());
            return Ok(user);

        }

       
        

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateUser ([FromForm] UserUpdate data,int userid)
        {
            try
            {
                return Ok(await userService.Update(data,userid));
            }catch(Exception e)
            {
                return BadRequest(new { statusCode = e.Message });
            }
        }
    }
}
