using CustomerAPI_LM.Data;
using CustomerAPI_LM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_LM.Delegates
{
    public static class CustomerDelegates
    {
               
        public static Customer GetCustomerById(int id)
        {
            return CustomerData.Customers.FirstOrDefault(c => c.Id == id);
        }

        public static void UpdateCustomer(int id, Customer customer)
        {
            var existingCustomer = CustomerData.Customers.FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                customer.FirstName = existingCustomer.FirstName;
                customer.LastName = existingCustomer.LastName;
                customer.Address = existingCustomer.Address;
            }
        }
    }
}
