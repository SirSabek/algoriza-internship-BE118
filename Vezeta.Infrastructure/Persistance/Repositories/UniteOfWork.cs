using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Domain.Entities;
using Vezeta.Infrastructure.Persistance;

namespace Vezeta.Infrastructure.Repositories.Persistance;

public class UniteOfWork : IUnitOfWork
{
    private readonly VezetaDbContext _context;
    private IRepository<Doctor> _Doctors;
    private IRepository<Patient> _Patients;

    public UniteOfWork(VezetaDbContext context)
    {
        _context = context;
    }

    public IRepository<Doctor> Doctors => _Doctors ??= new Repository<Doctor>(_context); 

    public IRepository<Patient> Patients => _Patients ??= new Repository<Patient>(_context);

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