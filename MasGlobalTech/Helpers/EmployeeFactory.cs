using MasGlobalTech.Models;

namespace MasGlobalTech.Helpers
{
    public abstract class EmployeeFactory
    {
        public abstract BaseEmployeeDto CreateEmployee();

        public decimal CalculateEmployeeSalary()
        {
            var employee = CreateEmployee();
            return employee.CalculateAnnualSalary();
        }
    }
}
