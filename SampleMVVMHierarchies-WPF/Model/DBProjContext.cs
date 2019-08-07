using SampleMVVMHierarchies_WPF.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVVMHierarchies_WPF.Services
{
    class DBProjContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Table names match entity names by default (don't pluralize)
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            // Globally disable the convention for cascading deletes
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            modelBuilder.Entity<Customer>()
                        .Property(c => c.Id) // Client must set the ID.
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
