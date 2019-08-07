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
            throw new NotImplementedException();
        }

        public Task<List<Customer>> GetCustomersAsync()
        {
            using(DBProjContext db = new DBProjContext())
            {
                return db.Customers.ToListAsync();
            }
        }

        public Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
