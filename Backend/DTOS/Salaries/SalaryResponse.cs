using Backend.Models;

namespace Backend.DTOS.Salaries
{
    public class SalaryResponse
    {
        static public object FromSalary(Salary salary)
        {
            return new
            {
                salary.Id,
                StatusSName = salary.Status.Name,
                TypeSName = salary.Types.Name,
                salary.salary_details,
                salary.salary_ordernum,
                salary.salary_datenum,
                salary.salary_effectivedate,
                salary.salary_enddate,
                salary.salary_salary,
                salary.salary_beforepostpone,
                salary.salary_percentage,
                salary.salary_calculationbase,
                salary.Createdate,
            };
        }
    }
}
