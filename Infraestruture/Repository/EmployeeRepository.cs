using Domain.Interfaces;
using Infraestruture.Context;
using Microsoft.EntityFrameworkCore;

public class EmployeeRepository : IEmployeeRepository
{
    private readonly EnterpriseDbContext _context;

    public EmployeeRepository(EnterpriseDbContext context) => _context = context;

    public async Task AddAsync(Employee entity)
    {
        await _context.Employees.AddAsync(entity);
    }

    public async Task DeleteAsync(Employee entity)
    {
        _context.Employees.Remove(entity);
        await Task.CompletedTask;
    }

    public async Task<Employee?> GetByIdAsync(int id) =>
        await _context.Employees
            .Include(e => e.Company)
            .FirstOrDefaultAsync(e => e.Id == id);

    public async Task<IEnumerable<Employee>> GetAllAsync() =>
        await _context.Employees
            .Include(e => e.Company)
            .ToListAsync();

    public async Task SaveChangesAsync() =>
        await _context.SaveChangesAsync();

    // Métodos personalizados
    public async Task<IEnumerable<Employee>> GetEmployeesByCompanyIdAsync(int companyId) =>
        await _context.Employees
            .Include(e => e.Company)
            .Where(e => e.CompanyId == companyId)
            .ToListAsync();

    public async Task<IEnumerable<Employee>> GetEmployeesByPositionAsync(string position) =>
        await _context.Employees
            .Include(e => e.Company)
            .Where(e => e.Position.ToLower().Contains(position.ToLower()))
            .ToListAsync();
}