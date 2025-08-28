

namespace Infraestruture.Context
{
    public class EnterpriseDbContext
    {
        public List<Company> Companies { get; set; } = new();
        public List<Employee> Employees { get; set; } = new();
    }
}
