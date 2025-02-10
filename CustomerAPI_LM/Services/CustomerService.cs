using CustomerAPI_LM.Delegates;
using CustomerAPI_LM.Interfaces;
using CustomerAPI_LM.Models;
using System.Collections.Generic;
using System.Linq;


namespace CustomerAPI_LM.Services
{
    public class CustomerService : ICustomerService
    {
        // Delegates for operations
        private GetCustomerByIdDelegate _getCustomerById;
        private UpdateCustomerDelegate _updateCustomer;

        public CustomerService(GetCustomerByIdDelegate getCustomerById, UpdateCustomerDelegate updateCustomer)
        {
          
            _getCustomerById = getCustomerById;
            _updateCustomer = updateCustomer;
        }


        public Customer GetCustomer(int id)
        {
            return _getCustomerById(id);

        }

        public void UpdateCustomerRecord(int id, Customer updatedCustomer)
        {
            _updateCustomer(id, updatedCustomer);
        }
    }
}
