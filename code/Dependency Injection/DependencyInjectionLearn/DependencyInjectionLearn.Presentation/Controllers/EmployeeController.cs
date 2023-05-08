using DependencyInjectionLearn.Domain;
using DependencyInjectionLearn.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace DependencyInjectionLearn.Presentation.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            return Ok(JsonSerializer.Serialize(await _employeeService.GetAsync()));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            Employee employee = await _employeeService.GetByIdAsync(id);
            if (employee != null)
            {
                return Ok(JsonSerializer.Serialize(employee));
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (await _employeeService.AddAsync(employee))
                {
                    return Ok("Employee added successfully.");
                }
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                if (await _employeeService.UpdateAsync(employee))
                {
                    return Ok("Employee updated successfully.");
                }
            }
            return BadRequest();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (await _employeeService.DeleteAsync(id))
            {
                return Ok("Employee deleted successfully.");
            }
            return BadRequest();
        }
    }
}
