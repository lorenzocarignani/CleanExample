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
        private readonly CompanyService _companyService;
        public CompaniesController(CompanyService companyService) => _companyService = companyService;

        [HttpPost]
        public IActionResult Create(CreateCompanyDto dto)
        {
            _companyService.CreateCompany(dto);
            return Ok("Company created");
        }

        [HttpGet]
        public IActionResult GetAll() => Ok(_companyService.GetAllCompanies());

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var company = _companyService.GetCompanyById(id);
            return company != null ? Ok(company) : NotFound();
        }
    }
}
