using CustomerAPI_LM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_LM.Interfaces
{    public interface IEmployeeService
    {
        Employee GetEmployee(int id);
        void UpdateEmployeeRecord(int id, Employee updatedEmployee);
    }

}
