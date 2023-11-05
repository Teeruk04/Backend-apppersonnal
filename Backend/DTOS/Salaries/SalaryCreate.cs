namespace Backend.DTOS.Salaries
{
    public class SalaryCreate
    {
        public int id_statusS { get; set; }
        public int id_typeS { get; set; }
        public string? salary_details { get; set; }
        public string salary_ordernum { get; set; }
        public DateTime salary_datenum { get; set; }
        public DateTime salary_effectivedate { get; set; }
        public DateTime? salary_enddate { get; set; }
        public float? salary_salary { get; set; }
        public int salary_beforepostpone { get; set; }
        public float salary_percentage { get; set; }
        public int salary_calculationbase { get; set; }
    }
}
