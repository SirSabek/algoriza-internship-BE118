using Vezeta.Domain.Entities;

namespace Vezeta.Application.Common.Interfaces.Persistance;

public interface IDoctorRepository : IRepository<Doctor>
{
    Task<List<SpecializationCount>> GetTopDoctorSpecializations();
    Task<List<DoctorBookingCount>> GetTopDoctors();
    Task<IQueryable<DoctorSchedule>> GetAllDoctorsSchedule();

}