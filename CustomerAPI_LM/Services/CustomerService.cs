using CustomerAPI_LM.Delegates;
using CustomerAPI_LM.Interfaces;
using CustomerAPI_LM.Models;
using System.Collections.Generic;
using System.Linq;


namespace CustomerAPI_LM.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> _customers;

        // Delegates for operations
        public GetCustomerByIdDelegate GetCustomerById { get; set; }
        public UpdateCustomerDelegate UpdateCustomer { get; set; }

        public CustomerService()
        {
            _customers = new List<Customer>
            {
                new Customer {Id = 1, FirstName = "Jason", LastName = "Smith", Address="Texas" },
                new Customer {Id = 2, FirstName = "Mary", LastName = "Peterson", Address="Florida" },
                new Customer {Id = 3, FirstName = "Jim", LastName = "Beam", Address="Minnesota" },
                new Customer {Id = 4, FirstName = "Jane", LastName = "Deer", Address="California" },
                new Customer {Id = 5, FirstName = "John", LastName = "Doe", Address="Ohio" },
            };

            GetCustomerById = GetCustomer;
            UpdateCustomer = UpdateCustomerRecord;
        }


        public Customer GetCustomer(int id)
        {
            return _customers.FirstOrDefault(c => c.Id == id);

        }

        public Customer UpdateCustomerRecord(int id, Customer updatedCustomer)
        {
            var customer = _customers.FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                customer.FirstName = updatedCustomer.FirstName;
                customer.LastName = updatedCustomer.LastName;
                customer.Address = updatedCustomer.Address;
            }

            return customer;
        }
    }
}
