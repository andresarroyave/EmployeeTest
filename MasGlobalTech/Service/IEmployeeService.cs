using MasGlobalTech.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasGlobalTech.Service
{
    public interface IEmployeeService
    {
        Task<IEnumerable<BaseEmployeeDto>> GetEmployees();
        Task<BaseEmployeeDto> GetEmployee(long id);
    }
}
