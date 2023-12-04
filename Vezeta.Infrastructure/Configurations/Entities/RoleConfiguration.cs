using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Vezeta.Infrastructure.Configurations.Entities;

public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
         builder.HasData(
            new IdentityRole
            {
                Name = "Doctor",
                NormalizedName = "DOCTOR"
            },
            new IdentityRole
            {
                Name = "Patient",
                NormalizedName = "PATIENT"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
    }
}