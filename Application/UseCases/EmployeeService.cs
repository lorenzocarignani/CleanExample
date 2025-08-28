using Application.DTOs;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ICompanyRepository _companyRepository;

        public EmployeeService(IEmployeeRepository employeeRepository, ICompanyRepository companyRepository)
        {
            _employeeRepository = employeeRepository;
            _companyRepository = companyRepository;
        }

        public void CreateEmployee(CreateEmployeeDto dto)
        {
            var company = _companyRepository.Get(dto.CompanyId);
            if (company == null) return;

            var employee = new Employee
            {
                Name = dto.Name,
                Age = dto.Age,
                Position = dto.Position,
                CompanyId = dto.CompanyId,
                Company = company
            };
            _employeeRepository.Add(employee);
            company.Employees.Add(employee);
        }

        public IEnumerable<Employee> GetAllEmployees() => _employeeRepository.GetAll();
        public Employee? GetEmployeeById(int id) => _employeeRepository.Get(id);
    }
}
