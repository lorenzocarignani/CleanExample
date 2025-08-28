using Application.DTOs;
using Application.UseCases.Interfaces;

using Domain.Interfaces;
using Infraestruture.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.UseCases
{
    public class CompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        public CompanyService(ICompanyRepository companyRepository) => _companyRepository = companyRepository;

        public void CreateCompany(CreateCompanyDto dto)
        {
            var company = new Company
            {
                Name = dto.Name,
                Address = dto.Address,
                Country = dto.Country
            };
            _companyRepository.Add(company);
        }

        public IEnumerable<Company> GetAllCompanies() => _companyRepository.GetAll();
        public Company? GetCompanyById(int id) => _companyRepository.Get(id);
    }

}

