using CustomerAPI_LM.Data;
using CustomerAPI_LM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_LM.Delegates
{
    // Delegate for getting customer by ID
    public delegate Customer GetCustomerByIdDelegate(int id);

    // Delegate for updating customer
    public delegate void UpdateCustomerDelegate(int id, Customer updatedCustomer);

    // Delegate for getting employee by ID
    public delegate Employee GetEmployeeByIdDelegate(int id);

    // Delegate for updating employee
    public delegate void UpdateEmployeeDelegate(int id, Employee updatedEmployee);


}
