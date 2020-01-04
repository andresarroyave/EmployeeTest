using MasGlobalTech.Helpers;

namespace MasGlobalTech.Models
{
    public class EmployeeByMonthFactory : EmployeeFactory
    {
        public override BaseEmployeeDto CreateEmployee()
        {
            return new EmployeeByMonthDto();
        }
    }
}
