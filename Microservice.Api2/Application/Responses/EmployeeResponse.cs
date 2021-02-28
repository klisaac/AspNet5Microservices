using System;

namespace Microservice.Api2.Application.Responses
{
    public class EmployeeResponse
    {
        public int EmployeeId { get; set; }
        public string EmployeeNumber { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
    }
}
