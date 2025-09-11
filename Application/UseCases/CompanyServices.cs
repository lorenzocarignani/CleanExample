using Application.DTOs;
using Application.UseCases.Interfaces;
using Domain.Interfaces;

namespace Application.UseCases
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository) =>
            _companyRepository = companyRepository;

        public async Task<int> CreateCompanyAsync(CreateCompanyDto dto)
        {
            var company = new Company
            {
                Name = dto.Name,
                Address = dto.Address,
                Country = dto.Country
            };

            await _companyRepository.AddAsync(company);
            await _companyRepository.SaveChangesAsync();
            return company.Id;
        }

        public async Task DeleteCompanyAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            if (company != null)
            {
                await _companyRepository.DeleteAsync(company);
                await _companyRepository.SaveChangesAsync();
            }
        }

        public async Task<List<CompanyDto>> GetAllCompaniesAsync()
        {
            var companies = await _companyRepository.GetAllAsync();
            return companies.Select(c => new CompanyDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Country = c.Country
            }).ToList();
        }

        public async Task<CompanyDto?> GetCompanyByIdAsync(int id)
        {
            var company = await _companyRepository.GetByIdAsync(id);
            return company == null ? null : new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Country = company.Country
            };
        }

        public async Task<CompanyDto?> GetCompanyWithEmployeesAsync(int id)
        {
            var company = await _companyRepository.GetCompanyWithEmployeesAsync(id);
            return company == null ? null : new CompanyDto
            {
                Id = company.Id,
                Name = company.Name,
                Address = company.Address,
                Country = company.Country,
                Employees = company.Employees.Select(e => new EmployeeDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Age = e.Age,
                    Position = e.Position,
                    CompanyId = e.CompanyId,
                    CompanyName = company.Name
                }).ToList()
            };
        }

        public async Task<List<CompanyDto>> GetCompaniesByCountryAsync(string country)
        {
            var companies = await _companyRepository.GetCompaniesByCountryAsync(country);
            return companies.Select(c => new CompanyDto
            {
                Id = c.Id,
                Name = c.Name,
                Address = c.Address,
                Country = c.Country
            }).ToList();
        }
    }
}