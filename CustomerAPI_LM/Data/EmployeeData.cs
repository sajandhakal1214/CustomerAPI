using CustomerAPI_LM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_LM.Data
{
    public class EmployeeData
    {
        public static List<Employee> Employees = new List<Employee>
        {
            new Employee { Id= 1, FirstName= "Olivia", LastName= "Williams", Address="Dallas", Salary= 53987 },
            new Employee { Id = 2,  FirstName= "Charlie", LastName= "Garcia", Address="Plano", Salary= 98782 },
            new Employee { Id = 3,  FirstName= "Jane", LastName= "Davis", Address="Plano", Salary= 45235 },
            new Employee { Id = 4,  FirstName= "John", LastName= "Martin", Address="Plano", Salary= 61524 },
            new Employee { Id = 5,  FirstName= "Bob", LastName= "Brown", Address="Plano", Salary= 32545 },
        };

    }
}

