

namespace Domain.Interfaces
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(int companyId);
        Task<IEnumerable<Employee>> GetEmployeesByPositionAsync(string position);
    }
}
