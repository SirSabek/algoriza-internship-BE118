using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vezeta.Domain.Entities;
using Vezeta.Domain.Enums;

namespace Vezeta.Infrastructure.Configurations.Entities;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasData(
            new Doctor
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@example.com",
                Gender = Gender.Male,
                Price = 100,
                DateOfBirth = new DateTime(1980, 1, 1),
                SpecializationId = 1
            },
            new Doctor
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                Email = "jane.doe@example.com",
                Gender = Gender.Female,
                Price = 200,
                DateOfBirth = new DateTime(1985, 2, 2),
                SpecializationId = 2
            },
            new Doctor
            {
                Id = 3,
                FirstName = "Bob",
                LastName = "Smith",
                Email = "bob.smith@example.com",
                Gender = Gender.Male,
                Price = 200,
                DateOfBirth = new DateTime(1990, 3, 3),
                SpecializationId = 3
            },
            new Doctor
            {
                Id = 4,
                FirstName = "Alice",
                LastName = "Johnson",
                Email = "alice.johnson@example.com",
                Gender = Gender.Female,
                Price = 150,
                DateOfBirth = new DateTime(1995, 4, 4),
                SpecializationId = 4
            }
        );

    }
}