using System;
using System.Linq.Expressions;
using Microservice.Api2.Core.Specifications.Base;
using Microservice.Api2.Core.Models.Entities;

namespace Microservice.Api2.Core.Specifications
{
    public class EmployeeSpecification : BaseSpecification<Employee>
    {
        public EmployeeSpecification() : base(null)
        {
        }

        public EmployeeSpecification(int employeeId)
            : base(e => e.EmployeeId == employeeId)
        {
        }

        public EmployeeSpecification(string empName)
            : base(e => e.FirstName.ToLower().Contains(empName.ToLower()) || e.LastName.ToLower().Contains(empName.ToLower()))
        {
        }

        public EmployeeSpecification(Expression<Func<Employee, bool>> expression) : base(expression)
        {
        }
    }
}
