using SampleMVVMHierarchies_WPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVMHierarchies_WPF.Services
{
    class CustomersRepository : ICustomersRepository
    {
        DBProjContext _context = new DBProjContext();
        public Task<Customer> AddCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task DeleteCustomerAsync(Guid customerId)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetCustomerAsync(Guid id)
        {
            //return _context.Customers.ToListAsync();
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
