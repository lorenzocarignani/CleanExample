using Application.DTOs;
using Application.UseCases;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;
        public EmployeesController(EmployeeService employeeService) => _employeeService = employeeService;

        [HttpPost]
        public IActionResult Create(CreateEmployeeDto dto)
        {
            _employeeService.CreateEmployee(dto);
            return Ok("Employee created");
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_employeeService.GetAllEmployees());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            return employee != null ? Ok(employee) : NotFound();
        }
    }
}
