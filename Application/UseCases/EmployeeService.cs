using Application.DTOs;
using Application.UseCases.Interfaces;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
        }

        public async Task<int> CreateEmployeeAsync(CreateEmployeeDto dto)
        {
            var company = await _companyRepository.GetByIdAsync(dto.CompanyId);
            if (company == null)
                throw new ArgumentException("Company not found");

            var employee = new Employee
            {
                Name = dto.Name,
                Age = dto.Age,
                Position = dto.Position,
                CompanyId = dto.CompanyId,
            };

            await _employeeRepository.AddAsync(employee);
            await _employeeRepository.SaveChangesAsync();
            return employee.Id;
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            if (employee != null)
            {
                await _employeeRepository.DeleteAsync(employee);
                await _employeeRepository.SaveChangesAsync();
            }
        }

        public async Task<List<EmployeeDto>> GetAllEmployeesAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Position = e.Position,
                CompanyId = e.CompanyId,
                CompanyName = e.Company?.Name ?? ""
            }).ToList();
        }

        public async Task<EmployeeDto?> GetEmployeeByIdAsync(int id)
        {
            var employee = await _employeeRepository.GetByIdAsync(id);
            return employee == null ? null : new EmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Position = employee.Position,
                CompanyId = employee.CompanyId,
                CompanyName = employee.Company?.Name ?? ""
            };
        }

        public async Task<List<EmployeeDto>> GetEmployeesByCompanyIdAsync(int companyId)
        {
            var employees = await _employeeRepository.GetEmployeesByCompanyIdAsync(companyId);
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Position = e.Position,
                CompanyId = e.CompanyId,
                CompanyName = e.Company?.Name ?? ""
            }).ToList();
        }

        public async Task<List<EmployeeDto>> GetEmployeesByPositionAsync(string position)
        {
            var employees = await _employeeRepository.GetEmployeesByPositionAsync(position);
            return employees.Select(e => new EmployeeDto
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Position = e.Position,
                CompanyId = e.CompanyId,
                CompanyName = e.Company?.Name ?? ""
            }).ToList();
        }
    }
}