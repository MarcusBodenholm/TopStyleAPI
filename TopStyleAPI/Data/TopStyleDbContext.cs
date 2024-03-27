using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TopStyleAPI.Domain.Entities;

namespace TopStyleAPI.Data
{
    public class TopStyleDbContext : IdentityDbContext<ApplicationUser>
    {
        public TopStyleDbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
