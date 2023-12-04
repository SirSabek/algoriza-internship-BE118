using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vezeta.Domain.Entities;
using Vezeta.Domain.Enums;

namespace Vezeta.Infrastructure.Configurations.Entities;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasData(
        new Patient
        {
            Id = 1,
            FirstName = "Mark",
            LastName = "Til",
            Gender = Gender.Male,
            DateOfBirth = new DateTime(1980, 1, 1),
            Email = "Mark.Til@example.com",
            PhoneNumber = "1234567890"
        },
        new Patient
        {
            Id = 2,
            FirstName = "Jeny",
            LastName = "Doe",
            Gender = Gender.Female,
            DateOfBirth = new DateTime(1985, 1, 1),
            Email = "Jeny.doe@example.com",
            PhoneNumber = "0987654321"
        }
    );        
    }
}