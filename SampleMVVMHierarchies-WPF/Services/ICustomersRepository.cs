using SampleMVVMHierarchies_WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVMHierarchies_WPF.Services
{
    public interface ICustomersRepository<T>
    {
        Task<List<T>> GetCustomersAsync();
        Task<T> GetCustomerAsync(Guid id);
        Task<T> AddCustomerAsync(T customer);
        Task<T> UpdateCustomerAsync(T customer);
        Task DeleteCustomerAsync(Guid customerId);
    }

}
