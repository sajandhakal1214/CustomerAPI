using CustomerAPI_LM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_LM.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(int id);
        void UpdateCustomerRecord(int id, Customer updatedCustomer);
    }

}
