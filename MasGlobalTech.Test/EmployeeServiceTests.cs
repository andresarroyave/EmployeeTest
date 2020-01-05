using MasGlobalTech.DataAccess;
using MasGlobalTech.Models;
using MasGlobalTech.Service;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private IOptions<ExternalResources> _appSettings;

        [SetUp]
        public void Setup()
        {
            _appSettings = Options.Create(new ExternalResources());
        }

        [Test]
        public async Task GetEmployeeWithMonthContractShouldCalculateAnnualSalaryByMonth()
        {
            //arrange
            var employeeRepository = new Mock<IEmployeeRepository>();

            employeeRepository.Setup(m => m.GetEmployee(1))
                .ReturnsAsync(new Employee() { Id = 1, ContractTypeName = "MonthlySalaryEmployee", MonthlySalary = 100 });

            var employeeService = new EmployeeService(employeeRepository.Object, _appSettings);

            //act
            var employee = await employeeService.GetEmployee(1);

            //assert
            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual(100 * 12, employee.AnnualSalary);
        }

        [Test]
        public async Task GetEmployeeWithHourContractShouldCalculateAnnualSalaryByHour()
        {
            //arrange
            var employeeRepository = new Mock<IEmployeeRepository>();

            employeeRepository.Setup(m => m.GetEmployee(1))
                .ReturnsAsync(new Employee() { Id = 1, ContractTypeName = "HourlySalaryEmployee", HourlySalary = 100 });

            var employeeService = new EmployeeService(employeeRepository.Object, _appSettings);

            //act
            var employee = await employeeService.GetEmployee(1);

            //assert
            Assert.AreEqual(1, employee.Id);
            Assert.AreEqual(120 * 100 * 12, employee.AnnualSalary);
        }

        [Test]
        public void GetEmployeeWithoutContractShouldFail()
        {
            //arrange
            var employeeRepository = new Mock<IEmployeeRepository>();

            employeeRepository.Setup(m => m.GetEmployee(1))
                .ReturnsAsync(new Employee());

            var employeeService = new EmployeeService(employeeRepository.Object, _appSettings);

            //act
            //assert
            Assert.ThrowsAsync<ArgumentOutOfRangeException>(
                async() => await employeeService.GetEmployee(1));
        }
    }
}