using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Vezeta.Domain.Entities;

namespace Vezeta.Infrastructure.Configurations.Entities;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        //seed data and take care of (Id, FirstName,LastName, SpecializationId, Email(FirstName+LastName@test.com), Phone )
        builder.HasData(
            new Doctor
            {
                Id = 1,
                FirstName = "Ahmed",
                LastName = "Mohamed",
                SpecializationId = 1,
                Email = "AhmedMohamed@test.com",
            },
            new Doctor
            {
                Id = 2,
                FirstName = "Ali",
                LastName = "Ahmed",
                SpecializationId = 2,
                Email = "",
            },
            new Doctor
            {
                Id = 3,
                FirstName = "Mohamed",
                LastName = "Ali",
                SpecializationId = 3,
                Email = "",
            },
            new Doctor
            {
                Id = 4,
                FirstName = "Khaled",
                LastName = "Mohamed",
                SpecializationId = 4,
                Email = "",
            },
            new Doctor
            {
                Id = 5,
                FirstName = "Mahmoud",
                LastName = "Khaled",
                SpecializationId = 5,
                Email = "",
            },
            new Doctor
            {
                Id = 6,
                FirstName = "Hassan",
                LastName = "Mahmoud",
                SpecializationId = 6,
                Email = "",
            },
            new Doctor
            {
                Id = 7,
                FirstName = "Hussein",
                LastName = "Hassan",
                SpecializationId = 7,
                Email = "",
            },
            new Doctor
            {
                Id = 8,
                FirstName = "Omar",
                LastName = "Hussein",
                SpecializationId = 8,
                Email = "",
            },
            new Doctor
            {
                Id = 9,
                FirstName = "Amr",
                LastName = "Omar",
                SpecializationId = 9,
                Email = "",
            },
            new Doctor
            {
                Id = 10,
                FirstName = "Abdallah",
                LastName = "Amr",
                SpecializationId = 10,
                Email = "",
            },
            new Doctor
            {
                Id = 11,
                FirstName = "Abdelrahman",
                LastName = "Abdallah",
                SpecializationId = 11,
                Email = "",
            },
            new Doctor
            {
                Id = 12,
                FirstName = "Youssef",
                LastName = "Abdelrahman",
                SpecializationId = 12,
                Email = "",
            });
    }
}