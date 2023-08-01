using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROCESSRUS_CODING_CHALLENGE.Entities.Configurations;

namespace PROCESSRUS_CODING_CHALLENGE.Data;

public class APIContext : IdentityDbContext<User>
{
    public APIContext(DbContextOptions options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new RoleConfig());
    }
}
