using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Vezeta.Application.Common;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Domain.Entities;
using Vezeta.Infrastructure.Repositories.Persistance;
using X.PagedList;

namespace Vezeta.Infrastructure.Persistance;

public class DoctorRepository : Repository<Doctor>, IDoctorRepository
{
    public DoctorRepository(VezetaDbContext context) : base(context)
    {
    }


    public async Task<List<SpecializationCount>> GetTopDoctorSpecializations()
    {
        var query = await _context.Bookings.GroupBy(q => q.Doctor.SpecializationId)
            .Select(q => new SpecializationCount{
                Name = q.FirstOrDefault().Doctor.Specialization.Name,
                Count = q.Count()
            }).ToListAsync();

        return query;
    }

    public async Task<List<DoctorBookingCount>> GetTopDoctors()
    {
        var query = await _context.Bookings.GroupBy(q => q.DoctorId)
            .Select(q => new DoctorBookingCount
            {
                DoctorName = q.FirstOrDefault().Doctor.FirstName + " " + q.FirstOrDefault().Doctor.LastName,
                Specialization = q.FirstOrDefault().Doctor.Specialization.Name,
                Image = q.FirstOrDefault().Doctor.Image,
                BookingCount = q.Count()
            }).OrderByDescending(q => q.BookingCount).Take(5).ToListAsync();

        return query;
    }

    public async Task<IQueryable<Application.Common.DoctorSchedule>> GetAllDoctorsSchedule()
    {
        var query = _context.Doctors.Select(q => new Application.Common.DoctorSchedule 
        {
            FullName = q.FirstName + " " + q.LastName,
            Image = q.Image,
            Email = q.Email,
            Phone = q.PhoneNumber,
            Specialization = q.Specialization.Name,
            Price = q.Price,
            Gender = q.Gender,
            Schedule = q.DoctorSchedules.GroupBy(q => q.ScheduleDayID).Select(q => new ScheduleDays
            {
                DayId = q.FirstOrDefault().ScheduleDayID,
                Hours = q.Select(q => new WorkingHours
                {
                    StartTime = q.TimeSlot.StartTime,
                    EndTime = q.TimeSlot.EndTime
                }).ToList()
            }).ToList()

        });
        return query;
    }
}