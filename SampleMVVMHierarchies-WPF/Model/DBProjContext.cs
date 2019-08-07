using SampleMVVMHierarchies_WPF.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVMHierarchies_WPF.Services
{
    class DBProjContext : DbContext
    {
        public DbSet<Task<Customer>> Customers { get; set; }
    }
}
