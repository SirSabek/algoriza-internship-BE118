using Vezeta.Domain.Entities;

namespace Vezeta.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
    IDoctorRepository Doctors { get; }
    IRepository<Patient> Patients { get; }
    IRepository<Booking> Bookings { get; }
    IRepository<Invoice> Invoices { get; }
    Task Save();
}