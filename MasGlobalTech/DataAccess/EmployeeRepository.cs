using MasGlobalTech.Helpers;
using MasGlobalTech.Models;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobalTech.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IHttpClientUtility _httpClientUtility;

        private readonly string _employeeUri;

        public EmployeeRepository(IHttpClientUtility httpClientUtility,
            IOptions<ExternalResources> appSettings)
        {
            _httpClientUtility = httpClientUtility;
            _employeeUri = $"{appSettings.Value.BaseUrl}{appSettings.Value.GetEmployees}";
        }

        public async Task<Employee> GetEmployee(long id)
        {
            var employees = await _httpClientUtility.GetListAsync<Employee>(_employeeUri);
            return employees.First(employee => employee.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _httpClientUtility.GetListAsync<Employee>(_employeeUri);
        }
    }
}
