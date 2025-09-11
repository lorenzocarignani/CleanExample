using Domain.Interfaces;
using Infraestruture.Context;
using Microsoft.EntityFrameworkCore;

public class CompanyRepository : ICompanyRepository
{
    private readonly EnterpriseDbContext _context;

    public CompanyRepository(EnterpriseDbContext context) => _context = context;

    public async Task AddAsync(Company entity)
    {
        await _context.Companies.AddAsync(entity);
    }

    public async Task DeleteAsync(Company entity)
    {
        _context.Companies.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<Company?> GetByIdAsync(int id) =>
        await _context.Companies.FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Company>> GetAllAsync() =>
        await _context.Companies.ToListAsync();

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    // Métodos personalizados
    public async Task<Company?> GetCompanyWithEmployeesAsync(int id) =>
        await _context.Companies
            .Include(c => c.Employees)
            .FirstOrDefaultAsync(c => c.Id == id);

    public async Task<IEnumerable<Company>> GetCompaniesByCountryAsync(string country) =>
        await _context.Companies
            .Where(c => c.Country.ToLower() == country.ToLower())
            .ToListAsync();
}

