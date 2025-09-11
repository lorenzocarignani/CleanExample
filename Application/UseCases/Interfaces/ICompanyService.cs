using Application.DTOs;

namespace Application.UseCases.Interfaces
{
    public interface ICompanyService
    {
        Task<int> CreateCompanyAsync(CreateCompanyDto dto);
        Task DeleteCompanyAsync(int id);
        Task<List<CompanyDto>> GetAllCompaniesAsync();
        Task<CompanyDto?> GetCompanyByIdAsync(int id);
        Task<CompanyDto?> GetCompanyWithEmployeesAsync(int id);
        Task<List<CompanyDto>> GetCompaniesByCountryAsync(string country);
    }
}
