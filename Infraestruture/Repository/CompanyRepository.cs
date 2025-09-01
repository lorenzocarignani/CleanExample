
using Domain.Interfaces;
using Infraestruture.Context;


namespace Infraestruture.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly EnterpriseDbContext _context;
        public CompanyRepository(EnterpriseDbContext context) => _context = context;

        public void Add(Company entity)
        {
            _context.Companies.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Company entity) {
            _context.Companies.Remove(entity);
            _context.SaveChanges();
            }

        public Company? Get(int id) => _context.Companies.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Company> GetAll() => _context.Companies;
    }
}
