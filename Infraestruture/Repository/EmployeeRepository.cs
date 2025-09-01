
using Domain.Interfaces;
using Infraestruture.Context;

namespace Infraestruture.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EnterpriseDbContext _context;
        public EmployeeRepository(EnterpriseDbContext context) => _context = context;

        public void Add(Employee entity)
        {
            _context.Employees.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _context.Employees.Remove(entity);
            _context.SaveChanges();
        }

        public Employee? Get(int id) => _context.Employees.FirstOrDefault(e => e.Id == id);

        public IEnumerable<Employee> GetAll() => _context.Employees;
    }
}
