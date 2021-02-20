using System;
using System.ComponentModel.DataAnnotations;

namespace Microservice.Api2.Core.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        [DataType("decimal(16, 3)")]
        public decimal Salary { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
    }
}
