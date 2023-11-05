using Backend.DTOS.Addresss;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class AddressController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly IAddressService addressService;

        public AddressController(DatabaseContext databaseContext, IAddressService addressService)
        {
            this.databaseContext = databaseContext;
            this.addressService = addressService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAdddress()
        {
            var addresss = (await addressService.FindAll()).Select(AddressResponse.FormAddress);
            return Ok(addresss);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var data = await addressService.FindByAddressId(id);
            return Ok(data);
        }   

        [HttpPost("[action]")]
        public async Task<ActionResult<Address>> CreateAddress([FromForm] AddressCreate addressCreate, int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Addresses).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newAddress = new Address
            {
                address_startdate = addressCreate.address_startdate,
                address_enddate = addressCreate.address_enddate,
                address_housenumber = addressCreate.address_housenumber,
                address_alley = addressCreate.address_alley,
                address_road = addressCreate.address_road,
                address_canton = addressCreate.address_canton,
                address_district = addressCreate.address_district,
                address_province = addressCreate.address_province,
                address_country = addressCreate.address_country,
                id_statusA = addressCreate.id_statusA,
                Createdate = DateTime.Now,
            };

            user.Addresses.Add(newAddress);
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "Ok", user });
        }


        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Address>> DeleteAddress(int id)
        {
            var address = await addressService.FindByAddressId(id);
            if (address == null) return NotFound();

            await addressService.Delete(address);
            return NoContent();
        }
        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Address>> FindByUserId(int userid, [FromQuery] string? search = "" )
        {
            var user = await databaseContext.Users.Include(x => x.Addresses).ThenInclude(x=>x.StatusA).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var address = user.Addresses.Where(x=>
            x.address_startdate.Year.ToString().Contains(search)||
            x.address_country.Contains(search)||
            x.address_province.Contains(search) ||
            x.StatusA.Name.Contains(search));
            

            return Ok(address);


        }

        [HttpPost("[action]")]
        public async Task<IActionResult> UpdateAddress ([FromForm] AddressUpdate data , int id)
        {
            try
            {
                return Ok(await addressService.Update(data , id));
            }catch (Exception e)
            {
                return BadRequest(new { statusCode = e.Message });

            }
        }


    }
}
