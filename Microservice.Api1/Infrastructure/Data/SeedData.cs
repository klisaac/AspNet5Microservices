using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microservice.Api2.Core.Models.Entities;

namespace Microservice.Api2.Infrastructure.Data
{
    public class SeedData
    {
        public static async Task SeedAsync(Api1Context dataContext)
        {
            try
            {
                if (!dataContext.Employees.Any())
                {
                    dataContext.Employees.AddRange(GetPreconfiguredEmployees());
                    await dataContext.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static IEnumerable<Employee> GetPreconfiguredEmployees()
        {
            return new List<Employee>()
            {
                new Employee() { EmployeeNumber = "3100", Title = "Mr.", FirstName = "Adrian", LastName="Taylor", BirthDate = new DateTime(1980, 12, 26), HireDate = new DateTime(2001, 06, 26), Designation = "Network Engineer", Salary = 35000, Department = "Accounts"},
                new Employee() { EmployeeNumber = "3101", Title = "Mr.", FirstName = "Rob", LastName="Hendrick", BirthDate = new DateTime(1978, 12, 26), HireDate = new DateTime(1999, 05, 25), Designation = "Hardware Engineer", Salary = 35000, Department = "Sales"},
                new Employee() { EmployeeNumber = "3102", Title = "Mr.", FirstName = "Brian", LastName="Jones", BirthDate = new DateTime(1980, 12, 26), HireDate = new DateTime(2000, 04, 24), Designation = "HR Manager", Salary = 45000, Department = "Human Resources" },
            };
        }
    }
}
