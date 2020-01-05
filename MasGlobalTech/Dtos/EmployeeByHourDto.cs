namespace MasGlobalTech.Dtos
{
    public class EmployeeByHourDto : BaseEmployeeDto
    {
        public override decimal CalculateAnnualSalary()
        {
            var workHoursPerMonth = 120;
            var monthsPerYear = 12;

            return workHoursPerMonth * HourlySalary * monthsPerYear;
        }
    }
}
