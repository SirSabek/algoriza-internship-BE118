using Microsoft.EntityFrameworkCore;
using Vezeta.Domain.Entities;

namespace Vezeta.Infrastructure.Configurations.Entities;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Specialization> builder)
    {
        builder.HasData(
            new Specialization
            {
                Id = 1,
                Name = "Cardiology"
            },
            new Specialization
            {
                Id = 2,
                Name = "Dermatology"
            },
            new Specialization
            {
                Id = 3,
                Name = "Endocrinology"
            },
            new Specialization
            {
                Id = 4,
                Name = "Gastroenterology"
            },
            new Specialization
            {
                Id = 5,
                Name = "Hematology"
            },
            new Specialization
            {
                Id = 6,
                Name = "Infectious Disease"
            },
            new Specialization
            {
                Id = 7,
                Name = "Nephrology"
            },
            new Specialization
            {
                Id = 8,
                Name = "Neurology"
            },
            new Specialization
            {
                Id = 9,
                Name = "Oncology"
            },
            new Specialization
            {
                Id = 10,
                Name = "Pulmonology"
            },
            new Specialization
            {
                Id = 11,
                Name = "Rheumatology"
            },
            new Specialization
            {
                Id = 12,
                Name = "Urology"
            },
            new Specialization
            {
                Id = 13,
                Name = "Ophthalmology"
            },
            new Specialization
            {
                Id = 14,
                Name = "Psychiatry"
            },
            new Specialization
            {
                Id = 15,
                Name = "Obstetrics and Gynecology"
            },
            new Specialization
            {
                Id = 16,
                Name = "Orthopedics"
            },
            new Specialization
            {
                Id = 17,
                Name = "Otolaryngology"
            },
            new Specialization
            {
                Id = 18,
                Name = "Pediatrics"
            },
            new Specialization
            {
                Id = 19,
                Name = "Physical Medicine and Rehabilitation"
            },
            new Specialization
            {
                Id = 20,
                Name = "Plastic Surgery"
            },
            new Specialization
            {
                Id = 21,
                Name = "General Surgery"
            },
            new Specialization
            {
                Id = 22,
                Name = "Thoracic Surgery"
            },
            new Specialization
            {
                Id = 23,
                Name = "Vascular Surgery"
            },
            new Specialization
            {
                Id = 24,
                Name = "Dentistry"
            },
            new Specialization
            {
                Id = 25,
                Name = "Dietetics"
            },
            new Specialization
            {
                Id = 26,
                Name = "Emergency Medicine"
            });
    }
}