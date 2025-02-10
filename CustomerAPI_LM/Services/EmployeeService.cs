using CustomerAPI_LM.Delegates;
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
        private GetEmployeeByIdDelegate _getEmployeeById;
        private UpdateEmployeeDelegate _updateEmployee;


        public EmployeeService(GetEmployeeByIdDelegate getEmployeeById, UpdateEmployeeDelegate updateEmployee)
        {
            _getEmployeeById = getEmployeeById;
            _updateEmployee = updateEmployee;
        }

        public Employee GetEmployee(int id)
        {
            return _getEmployeeById(id);
        }

        public void UpdateEmployeeRecord(int id, Employee updatedEmployee)
        {
            _updateEmployee(id, updatedEmployee);
        }
    }
}
