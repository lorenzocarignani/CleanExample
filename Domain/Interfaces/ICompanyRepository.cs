

namespace Domain.Interfaces
{
    public interface ICompanyRepository : IRepositoryBase<Company>
    {
        Task<Company?> GetCompanyWithEmployeesAsync(int id);
        Task<IEnumerable<Company>> GetCompaniesByCountryAsync(string country);
    }
}
