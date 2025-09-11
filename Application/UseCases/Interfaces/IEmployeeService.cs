using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases.Interfaces
{
    public interface IEmployeeService
    {
        Task<int> CreateEmployeeAsync(CreateEmployeeDto dto);
        Task DeleteEmployeeAsync(int id);
        Task<List<EmployeeDto>> GetAllEmployeesAsync();
        Task<EmployeeDto?> GetEmployeeByIdAsync(int id);
        Task<List<EmployeeDto>> GetEmployeesByCompanyIdAsync(int companyId);
        Task<List<EmployeeDto>> GetEmployeesByPositionAsync(string position);
    }
}
