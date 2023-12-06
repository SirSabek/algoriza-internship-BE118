using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Vezeta.Domain.Entities;
using Vezeta.Infrastructure.Configurations.Entities;

namespace Vezeta.Infrastructure.Persistance;

public class VezetaDbContext: IdentityDbContext<User, IdentityRole<int>, int> 
{
    public VezetaDbContext(DbContextOptions<VezetaDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Admin>().ToTable("Admins");
        modelBuilder.Entity<Patient>().ToTable("Patients");
        modelBuilder.Entity<Doctor>().ToTable("Doctors");

        // seeding data
        modelBuilder.ApplyConfiguration(new SpecializationConfiguration());
        modelBuilder.ApplyConfiguration(new RoleConfiguration());
        modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        modelBuilder.ApplyConfiguration(new PatientConfiguration());
      
    }

    public DbSet<Admin> Admins { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Specialization> Specializations { get; set; } = null!;
    public DbSet<Booking> Bookings { get; set; } = null!;
    public DbSet<ExaminationDetails> ExaminationDetails { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
}