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
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id= "94872e29-9ae6-4450-a840-fbfaa34da622",
                    Name="admin",
                    NormalizedName="ADMIN"
                },
                new IdentityRole
                {
                    Id = "8849cc49-f8c5-486f-af6e-b587e9aeeaf2",
                    Name = "user",
                    NormalizedName = "USER"
                }
            );
            var hasher = new PasswordHasher<IdentityUser>();
            builder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id= "beb7dab8-6c49-422f-bb91-be5998cce504",
                    Email= "admin2424@gmail.com",
                    NormalizedEmail="ADMIN2424@GmAIL.COM",
                    UserName= "admin2424@gmail.com",
                    PasswordHash=hasher.HashPassword(null,"admin"),
                    NormalizedUserName= "ADMIN2424@GmAIL.COM"


                },
                new IdentityUser
                {
                    Id = "b9be2c08-e735-45e3-9f88-3bedf6d15d3e",
                    Email = "user2424@gmail.com",
                    NormalizedEmail = "USER2424@GmAIL.COM",
                    UserName = "user2424@gmail.com",
                    PasswordHash = hasher.HashPassword(null, "example"),
                    NormalizedUserName = "USER2424@GmAIL.COM"

                }
            );
            builder.Entity<IdentityUserRole<String>>().HasData(
                new IdentityUserRole<String>() {
                    RoleId = "94872e29-9ae6-4450-a840-fbfaa34da622",
                    UserId = "beb7dab8-6c49-422f-bb91-be5998cce504"
                },
                new IdentityUserRole<String>()
                {
                    RoleId = "8849cc49-f8c5-486f-af6e-b587e9aeeaf2",
                    UserId = "b9be2c08-e735-45e3-9f88-3bedf6d15d3e"
                }

            );
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Company> Companies { get; set; }
        
    }
}
