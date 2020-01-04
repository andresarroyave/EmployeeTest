using MasGlobalTech.DataAccess;
using MasGlobalTech.Helpers;
using MasGlobalTech.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace MasGlobalTech.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IOptions<ExternalResources> _appSettings;

        public EmployeeService(IEmployeeRepository employeeRepository, 
            IOptions<ExternalResources> appSettings)
        {
            _employeeRepository = employeeRepository;
            _appSettings = appSettings;
        }

        public async Task<BaseEmployeeDto> GetEmployee(long id)
        {
            var employee = await _employeeRepository.GetEmployee(id);

            return ProcessEmployee(employee);
        }

        public async Task<IEnumerable<BaseEmployeeDto>> GetEmployees()
        {
            var employees = await _employeeRepository.GetEmployees();

            var baseEmployees = new List<BaseEmployeeDto>();
            foreach (var employee in employees)
            {
                var newEmployee = ProcessEmployee(employee);
                baseEmployees.Add(newEmployee);
            }

            return baseEmployees;
        }

        private BaseEmployeeDto ProcessEmployee(Employee employee)
        {
            EmployeeFactory factory;

            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    factory = new EmployeeByHourFactory();
                    break;
                case "MonthlySalaryEmployee":
                    factory = new EmployeeByMonthFactory();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(
                        $"The specified Contract Type doesn't exists: {employee.ContractTypeName}");
            }

            var newEmployee = factory.CreateEmployee();

            newEmployee.Id = employee.Id;
            newEmployee.Name = employee.Name;
            newEmployee.RoleId = employee.RoleId;
            newEmployee.RoleName = employee.RoleName;
            newEmployee.RoleDescription = employee.RoleDescription;
            newEmployee.MonthlySalary = employee.MonthlySalary;
            newEmployee.HourlySalary = employee.HourlySalary;

            return newEmployee;
        }
    }
}
