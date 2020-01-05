using MasGlobalTech.Models;

namespace MasGlobalTech.Factories
{
    public class EmployeeByMonthFactory : EmployeeFactory
    {
        public override BaseEmployeeDto CreateEmployee()
        {
            return new EmployeeByMonthDto();
        }
    }
}
