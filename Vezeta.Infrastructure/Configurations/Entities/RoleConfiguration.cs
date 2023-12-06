using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vezeta.Infrastructure.Configurations.Entities;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
    {
        builder.ToTable("AspNetRoles");
        builder.HasData(
            new IdentityRole<int>
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN"
            },
            new IdentityRole<int>
            {
                Id = 2,
                Name = "Patient",
                NormalizedName = "PATIENT"
            },
            new IdentityRole<int>
            {
                Id = 3,
                Name = "Doctor",
                NormalizedName = "DOCTOR"
            }
        );
       
    }
}