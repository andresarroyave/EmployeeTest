using MasGlobalTech.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobalTech.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<BaseEmployeeDto>> GetEmployees();
        Task<BaseEmployeeDto> GetEmployee(long id);
    }
}
