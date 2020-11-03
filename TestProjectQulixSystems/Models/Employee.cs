using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestProjectQulixSystems.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        //[DisplayFormat(DataFormatString = "{0:M/d/YYYY}")]
        public DateTime Date { get; set; }
        public string Position { get; set; }
        public int CompanyId { get; set; }
    }
}
