using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectQulixSystems.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        string connectionString = null;
        public EmployeeRepository(string conn)
        {
            connectionString = conn;
        }
        public List<Employee> GetEmployees()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Employee>("SELECT * FROM Employees").ToList();
            }
        }

        public Employee Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Employee>("SELECT * FROM Employees WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public void Create(Employee Employee)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Employees (Id, Surname, Name, MiddleName, Date, Position , CompanyId) VALUES(@Id, @Surname, @Name, @MiddleName, @Date, @Position, @CompanyId)";
                db.Execute(sqlQuery, Employee);
            }
        }

        public void Update(Employee Employee)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Employees SET Surname = @Surname, Name = @Name , MiddleName = @MiddleName, Date = @Date, Position = @Position, CompanyId = @CompanyId WHERE Id = @Id";
                db.Execute(sqlQuery, Employee);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Employees WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }

        public int GetNextId()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var currentMaxId = db.Query<Employee>("SELECT Id FROM Employees ORDER BY Id DESC").FirstOrDefault();
                return (currentMaxId!=null) ? (currentMaxId.Id + 1) : 1;
            }
        }

        public List<object> GetCompanies()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<object>("SELECT Id,Name FROM Companies").ToList();
            }
        }
    }
}
