using Application.DTOs;

namespace Application.UseCases.Interfaces
{
    public interface ICompanyService
    {
        void Add(CreateCompanyDto dto);
        void Delete(int id);
        List<Company> GetAll();
        Company GetById(int id);
    }
}
