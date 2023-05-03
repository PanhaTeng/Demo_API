using Demo_API.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Demo_API.Data
{
    public class DataContext:IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        {
            
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Company> Companies { get; set; }
        
    }
}
