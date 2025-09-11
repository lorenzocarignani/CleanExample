using Application.DTOs;
using Application.UseCases;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService) =>
            _employeeService = employeeService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var id = await _employeeService.CreateEmployeeAsync(dto);
                return CreatedAtAction(nameof(GetById), new { id }, new { Id = id });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _employeeService.GetAllEmployeesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return employee != null ? Ok(employee) : NotFound();
        }

        [HttpGet("by-company/{companyId}")]
        public async Task<IActionResult> GetByCompany(int companyId) =>
            Ok(await _employeeService.GetEmployeesByCompanyIdAsync(companyId));

        [HttpGet("by-position/{position}")]
        public async Task<IActionResult> GetByPosition(string position) =>
            Ok(await _employeeService.GetEmployeesByPositionAsync(position));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }
    }
}
