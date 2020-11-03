using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectQulixSystems.Models
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LawForm { get; set; }
        public List<Employee> Employees { get; set; }
        public Company()
        {
            Employees = new List<Employee>();
        }
    }
}
