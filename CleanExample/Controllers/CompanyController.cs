using Application.DTOs;
using Application.UseCases;
using Application.UseCases.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompaniesController(ICompanyService companyService) =>
            _companyService = companyService;

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var id = await _companyService.CreateCompanyAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, new { Id = id });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>
            Ok(await _companyService.GetAllCompaniesAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            return company != null ? Ok(company) : NotFound();
        }

        [HttpGet("{id}/with-employees")]
        public async Task<IActionResult> GetWithEmployees(int id)
        {
            var company = await _companyService.GetCompanyWithEmployeesAsync(id);
            return company != null ? Ok(company) : NotFound();
        }

        [HttpGet("by-country/{country}")]
        public async Task<IActionResult> GetByCountry(string country) =>
            Ok(await _companyService.GetCompaniesByCountryAsync(country));

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _companyService.DeleteCompanyAsync(id);
            return NoContent();
        }
    }
}
