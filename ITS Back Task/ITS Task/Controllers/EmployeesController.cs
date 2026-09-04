using ITS_Task.Business.DTOs;
using ITS_Task.Business.Interfaces;
using ITS_Task.Models;
using Microsoft.AspNetCore.Mvc;


namespace ITS_Task.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var employees = await _employeeService.GetAllAsync();

            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateEmployeeDto employeeDto)
        {
            var result = await _employeeService.AddAsync(employeeDto);

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _employeeService.DeleteAsync(id);

            if (!deleted)
                return NotFound();

            return Ok();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _employeeService.GetByIdAsync(id);

            if (res == null)
                return NotFound();

            return Ok(res);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id,UpdateEmployeeDto employeeDto)
        {
           
            var updatedEmployee = await _employeeService.UpdateAsync(id, employeeDto);

            if (updatedEmployee == null)
                return NotFound();

            return Ok(updatedEmployee);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search(string Search)
        {
            if (string.IsNullOrWhiteSpace(Search))
                return BadRequest("Search term is required");

            var employees = await _employeeService.SearchAsync(Search);

            return Ok(employees);
        }
    }
}
