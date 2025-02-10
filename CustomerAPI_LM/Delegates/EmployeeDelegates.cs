using CustomerAPI_LM.Data;
using CustomerAPI_LM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_LM.Delegates
{
    public static class EmployeeDelegates
    {
        public static Employee GetEmployeeById(int id)
        {
            return EmployeeData.Employees.FirstOrDefault(c => c.Id == id);
        }

        public static void UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = EmployeeData.Employees.FirstOrDefault(c => c.Id == id);

            if (employee != null)
            {
                employee.FirstName = existingEmployee.FirstName;
                employee.LastName = existingEmployee.LastName;
                employee.Address = existingEmployee.Address;
            }
        }
    }
}
