
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
            entity.Id = _context.Companies.Count + 1;
            _context.Companies.Add(entity);
        }

        public void Delete(Company entity) => _context.Companies.Remove(entity);

        public Company? Get(int id) => _context.Companies.FirstOrDefault(c => c.Id == id);

        public IEnumerable<Company> GetAll() => _context.Companies;
    }
}
