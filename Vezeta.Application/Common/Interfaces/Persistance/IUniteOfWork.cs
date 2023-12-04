using Vezeta.Domain.Entities;

namespace Vezeta.Application.Common.Interfaces.Persistance;

public interface IUnitOfWork : IDisposable
{
    IRepository<Doctor> Doctors { get; }
    IRepository<Patient> Patients { get; }

    Task Save();
}