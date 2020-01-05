using MasGlobalTech.Dtos;

namespace MasGlobalTech.Factories
{
    public class EmployeeByHourFactory : EmployeeFactory
    {
        public override BaseEmployeeDto CreateEmployee()
        {
            return new EmployeeByHourDto();
        }
    }
}
