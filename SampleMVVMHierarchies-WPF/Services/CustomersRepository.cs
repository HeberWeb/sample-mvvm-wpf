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
        public Task<List<Customer>> GetCustomersAsync()
        {
            using (DBProjContext db = new DBProjContext())
            {
                return db.Customers.ToListAsync();
            }
        }

        public Task<Customer> GetCustomerAsync(long id)
        {
            using (DBProjContext db = new DBProjContext())
            {
                return db.Customers.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<Customer> AddCustomerAsync(Customer customer)
        {
            using (DBProjContext db = new DBProjContext())
            {
                db.Customers.Add(customer);
                await db.SaveChangesAsync();
                return customer;
            }
        }

        public async Task<Customer> UpdateCustomerAsync(Customer customer)
        {
            using (DBProjContext db = new DBProjContext())
            {
                if (!db.Customers.Local.Any(x => x.Id == customer.Id))
                {
                    db.Customers.Attach(customer);
                }

                db.Entry(customer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return customer;
            }
        }

        public async Task DeleteCustomerAsync(long customerId)
        {
            using (DBProjContext db = new DBProjContext())
            {
                var customer = db.Customers.FirstOrDefault(x => x.Id == customerId);

                if (customer != null)
                {
                    db.Customers.Remove(customer);
                }

                await db.SaveChangesAsync();
            }
        }
    }
}
