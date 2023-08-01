using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PROCESSRUS_CODING_CHALLENGE.Entities.Configurations;
public class RoleConfig : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "FrontOffice",
                NormalizedName = "FRONTOFFICE"
            },
            new IdentityRole
            {
                Name = "BackOffice",
                NormalizedName = "BACKOFFICE"
            }
        );
    }
}
