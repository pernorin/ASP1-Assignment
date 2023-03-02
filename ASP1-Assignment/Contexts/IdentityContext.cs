using ASP1_Assignment.Models.Entities;
using ASP1_Assignment.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP1_Assignment.Contexts
{
    public class IdentityContext : IdentityDbContext<AppUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Products { get; set; }
    }
}
