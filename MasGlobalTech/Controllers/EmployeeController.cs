using MasGlobalTech.Models;
using MasGlobalTech.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MasGlobalTech.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<BaseEmployeeDto>> GetEmployee(long id)
        {
            try
            {
                return await _employeeService.GetEmployee(id);
            }
            catch (InvalidOperationException)
            {
                //Do some logging stuff
                return NotFound("");
            }
            catch (Exception)
            {
                //Do some logging stuff
                throw;
            }
        }

        [HttpGet("")]
        public async Task<IEnumerable<BaseEmployeeDto>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }
    }
}
