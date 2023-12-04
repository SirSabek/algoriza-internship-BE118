using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vezeta.Domain.Entities;

namespace Vezeta.Infrastructure.Configurations.Entities;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        //seed data of (Id, FirstName,LastName, Email with this pattern "FirstName+LastName@test.com", Phone )
        builder.HasData(
            new Patient
            {
                Id = 1,
                FirstName = "Ahmed",
                LastName = "Mohamed",
                Email = "AhmedMohamed@test.com",
                PhoneNumber = "01000000000"
            },
            new Patient
            {
                Id = 2,
                FirstName = "Ali",
                LastName = "Ahmed",
                Email = "AliAhmed@test.com",
                PhoneNumber = "01000000000"
            },
            new Patient
            {
                Id = 3,
                FirstName = "Mohamed",
                LastName = "Ali",
                Email = "MohamedAli@test.com",
                PhoneNumber = "01000000000"
            });


    }
}