using AutoMapper;
using Vezeta.Contract.Dtos.BookingDtos;
using Vezeta.Contract.Dtos.Doctor;
using Vezeta.Contract.Dtos.Patient;
using Vezeta.Domain.Entities;

namespace Vezeta.Api.Configurations;

public class MapperInitializer : Profile
{
    public MapperInitializer()
    {
        CreateMap<Doctor, GetDoctorDto>()
        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
        .ReverseMap();

        CreateMap<Doctor, AddDoctorDto>().ReverseMap();

        CreateMap<Doctor, UpdateDoctorDto>().ReverseMap();

        CreateMap<Patient, GetPatientDto>()
        .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName))
        .ReverseMap();

        CreateMap<Booking, GetBookingDto>().ReverseMap();
        CreateMap<Booking, AddBookingDto>().ReverseMap();


    }
}