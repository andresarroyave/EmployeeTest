namespace MasGlobalTech.Dtos
{
    public class EmployeeByMonthDto : BaseEmployeeDto
    {
        public override decimal CalculateAnnualSalary()
        {
            var monthsPerYear = 12;

            return MonthlySalary * monthsPerYear;
        }
    }
}
