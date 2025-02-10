using CustomerAPI_LM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerAPI_LM.Data
{
    public class CustomerData
    {
        public static List<Customer> Customers = new List<Customer>
        {
            new Customer {Id = 1, FirstName = "Jason", LastName = "Smith", Address="Texas" },
            new Customer {Id = 2, FirstName = "Mary", LastName = "Peterson", Address="Florida" },
            new Customer {Id = 3, FirstName = "Jim", LastName = "Beam", Address="Minnesota" },
            new Customer {Id = 4, FirstName = "Jane", LastName = "Deer", Address="California" },
            new Customer {Id = 5, FirstName = "John", LastName = "Doe", Address="Ohio" },
        };

    }
}
