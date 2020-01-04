using MasGlobalTech.Helpers;

namespace MasGlobalTech.Models
{
    public class EmployeeByHourFactory : EmployeeFactory
    {
        public override BaseEmployeeDto CreateEmployee()
        {
            return new EmployeeByHourDto();
        }
    }
}
