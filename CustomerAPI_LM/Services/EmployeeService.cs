using CustomerAPI_LM.Interfaces;
using CustomerAPI_LM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_LM.Services
{
    public class EmployeeService: IEmployeeService
    {
        private List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>
            {
                new Employee { Id= 1, FirstName= "Olivia", LastName= "Williams", Address="Dallas", Salary= 53987 },
                new Employee { Id = 2,  FirstName= "Charlie", LastName= "Garcia", Address="Plano", Salary= 98782 },
                new Employee { Id = 3,  FirstName= "Jane", LastName= "Davis", Address="Plano", Salary= 45235 },
                new Employee { Id = 4,  FirstName= "John", LastName= "Martin", Address="Plano", Salary= 61524 },
                new Employee { Id = 5,  FirstName= "Bob", LastName= "Brown", Address="Plano", Salary= 32545 },
            };
        }

        public Employee GetEmployee(int id)
        {
            return _employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee UpdateEmployeeRecord(int id, Employee updateEmployee)
        {
            var employee = _employees.FirstOrDefault(c => c.Id == id);

            if (employee != null)
            {
                employee.FirstName = updateEmployee.FirstName;
                employee.LastName = updateEmployee.LastName;
                employee.Address = updateEmployee.Address;
                employee.Salary = updateEmployee.Salary;
            }

            return employee;
        }
    }
}
