using System.Runtime.Intrinsics.X86;
using AutoMapper;
using Vezeta.Contract.Dtos.Auth;
using Vezeta.Contract.Dtos.BookingDtos;
using Vezeta.Contract.Dtos.Doctor;
using Vezeta.Contract.Dtos.Patient;
using Vezeta.Contract.Dtos.Schedules;
using Vezeta.Domain.Entities;

namespace Vezeta.Api.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<Doctor, GetDoctorDto>()
        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
        .ReverseMap();

        CreateMap<Doctor, AddDoctorDto>().ReverseMap()
        .ForMember(src => src.Image, opt => opt.Ignore());
       
        CreateMap<Doctor, UpdateDoctorDto>() 
        .ForMember(src => src.Image, opt => opt.Ignore()).ReverseMap();

        CreateMap<Patient, GetPatientDto>()
        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
        .ReverseMap();

        CreateMap<IGrouping<int, DoctorSchedule>, ScheduleDayDto>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Key))
        .ForMember(dest => dest.TimeSlots, opt => opt.MapFrom(src => src.Select(ds => new TimeSlotDto { Id = ds.TimeSlotID })));

  
        CreateMap<TimeSlot, TimeSlotDto>().ReverseMap();

        CreateMap<Booking, GetBookingDto>().ReverseMap();

        CreateMap<Booking, AddBookingDto>().ReverseMap();

        CreateMap<User, UserDTO>().ReverseMap();

        CreateMap<Patient, UserDTO>().ReverseMap();
    }
}