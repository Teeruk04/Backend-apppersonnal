using Backend.DTOS.Salaries;
using Backend.Interfaces;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    public class SalaryController : BaseApiController
    {
        private readonly DatabaseContext databaseContext;
        private readonly ISalaryService salaryService;

        public SalaryController(DatabaseContext databaseContext, ISalaryService salaryService)
        {
            this.databaseContext = databaseContext;
            this.salaryService = salaryService;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalary()
        {
            var salaries = (await salaryService.FindAll()).Select(SalaryResponse.FromSalary);
            return Ok(salaries);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSalaryById(int id)
        {
            var data = await salaryService.FindBySalaryId(id);
            return Ok(data);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<Salary>> CreateSalary([FromForm] SalaryCreate salaryCreate, int userid)
        {
            var user = await databaseContext.Users.Include(x => x.Salaries).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();
            var newSalary = new Salary
            {
                id_starusS = salaryCreate.id_statusS,
                id_TypeS = salaryCreate.id_typeS,
                salary_details = salaryCreate.salary_details,
                salary_ordernum = salaryCreate.salary_ordernum,
                salary_datenum = salaryCreate.salary_datenum,
                salary_effectivedate = salaryCreate.salary_effectivedate,
                salary_enddate = salaryCreate.salary_enddate,
                salary_salary = sumSalary(salaryCreate.salary_percentage,salaryCreate.salary_calculationbase,salaryCreate.salary_beforepostpone),
                salary_beforepostpone = salaryCreate.salary_beforepostpone,
                salary_percentage = salaryCreate.salary_percentage,
                salary_calculationbase = salaryCreate.salary_calculationbase,
                Createdate = DateTime.Now,

            };


           

            user.Salaries.Add(newSalary);

           
            await databaseContext.SaveChangesAsync();
            return Ok(new { msg = "Ok", user });
        }

        private float sumSalary(float perce,int calcu, int befor )
        {
            return (perce * calcu) / 100 + befor;
        }


        [HttpPost("[action]/{id}")]
        public async Task<ActionResult<Salary>> DeleteSalary( int id)
        {
            var salary = await salaryService.FindBySalaryId(id);
            if (salary == null) return NotFound();

            await salaryService.Delete(salary);
            return NoContent();
        }

        [HttpGet("[action]{userid}")]
        public async Task<ActionResult<Salary>> FindByUserId(int userid,[FromQuery]string? search = "")
        {
            var user = await databaseContext.Users.Include(x => x.Salaries).ThenInclude(x=>x.Types).Include(x=>x.Salaries).ThenInclude(x=>x.Status).FirstOrDefaultAsync(x => x.Id.Equals(userid));
            if (user == null) return BadRequest();

            var salaries = user.Salaries.Where(x =>
            x.salary_datenum.Year.ToString().Contains(search) ||
            x.salary_effectivedate.Year.ToString().Contains(search)
            );

            return Ok(salaries);


        }


    }
}
