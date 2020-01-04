using MasGlobalTech.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobalTech.DataAccess
{
    public interface IEmployeeRepository
    {
        Task<Employee> GetEmployee(long id);
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
