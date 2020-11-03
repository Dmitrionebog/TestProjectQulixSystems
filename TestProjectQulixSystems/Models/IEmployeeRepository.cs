using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectQulixSystems.Models
{
    public interface IEmployeeRepository
    {
        //метод для Post Create(создание нового сотрудника)
        void Create(Employee employee);
        //метод для удаление сотрудника
        void Delete(int id);
        //метод для получения выбранного сотрудника по id
        Employee Get(int id);
        //метод для получения списка сотрудников
        List<Employee> GetEmployees();
        //метод для редактирования данных о сотруднике
        void Update(Employee employee);
        //метод для автогенерации id нового сотрудника
        int GetNextId();
        //метод для получения списка компаний
        List<object> GetCompanies();
    }
}
