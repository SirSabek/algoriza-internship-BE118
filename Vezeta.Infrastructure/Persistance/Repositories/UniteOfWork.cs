using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Domain.Entities;
using Vezeta.Infrastructure.Persistance;

namespace Vezeta.Infrastructure.Repositories.Persistance;

public class UniteOfWork : IUnitOfWork
{
    private readonly VezetaDbContext _context;
    private IDoctorRepository _Doctors;
    private IRepository<Patient> _Patients;
    private IRepository<Booking> _Bookings;
    private IRepository<Invoice> _Invoices;

    public UniteOfWork(VezetaDbContext context)
    {
        _context = context;
    }

    public IDoctorRepository Doctors => _Doctors ??= new DoctorRepository(_context); 
    public IRepository<Patient> Patients => _Patients ??= new Repository<Patient>(_context);
    public IRepository<Booking> Bookings => _Bookings ??= new Repository<Booking>(_context);
    public IRepository<Invoice> Invoices => _Invoices ??= new Repository<Invoice>(_context);

    public void Dispose()
    {
        _context.Dispose();
        GC.SuppressFinalize(this);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync();
    }
}