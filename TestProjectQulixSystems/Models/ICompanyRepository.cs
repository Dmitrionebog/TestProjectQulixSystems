using System.Collections.Generic;

namespace TestProjectQulixSystems.Models
{
    public interface ICompanyRepository
    {
        //метод для Post Create(создание новой компании)
        bool Create(Company company);
        //метод для удаление существующей компании
        void Delete(int id);
        //метод для получения выбранной компании по id
        Company Get(int id);
        //метод для получения списка ViewModel Companies
        List<CompanyIndex> GetCompaniesIndex();
        //метод для редактирования существующей компании
        bool Update(Company company);
    }
}
