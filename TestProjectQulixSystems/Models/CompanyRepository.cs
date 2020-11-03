using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectQulixSystems.Models
{
    public class CompanyRepository : ICompanyRepository
    {
        string connectionString = null;
        public CompanyRepository(string conn)
        {
            connectionString = conn;
        }

        public List<CompanyIndex> GetCompaniesIndex()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<CompanyIndex>("SELECT Id, Name, IIF (cid is null, 0, count(*)) as HeadCount, LawForm FROM " +
                    "(SELECT Companies.Id, Companies.Name, Companies.LawForm, Employees.CompanyId as cid FROM Companies " +
                    "LEFT OUTER Join  Employees ON Companies.Id = Employees.CompanyId) as d " +
                    "GROUP BY d.Id, d.Name, d.LawForm, d.cid").ToList();
            }
        }
        public Company Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Company>("SELECT * FROM Companies WHERE Id = @id", new { id }).FirstOrDefault();
            }
        }

        public bool Create(Company Company)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Companies (Id ,Name, LawForm) VALUES(@Id, @Name, @LawForm)";
                try
                {
                    db.Execute(sqlQuery, Company);
                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    { 
                        return false;
                    }
                 }
                return true;
            }
        }

        public bool Update(Company Company)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Companies SET Name = @Name, LawForm = @LawForm WHERE Id = @Id";
                try
                {
                    db.Execute(sqlQuery, Company);
                }
                catch (DbException)
                {
                    return false;
                }
                return true;
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Companies WHERE Id = @id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
