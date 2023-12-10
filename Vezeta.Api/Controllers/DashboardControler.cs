using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Contract.Dtos.BookingDtos;

namespace Vezeta.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class DashboardController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DashboardController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("doctorCount")]
    public async Task<IActionResult> GetDoctorsCount()
    {
        var count = await _unitOfWork.Doctors.GetAll();
        return Ok(count.Count());
    }
    
    [HttpGet("patientCount")]
    public async Task<IActionResult> GetCount()
    {
        var count = await _unitOfWork.Patients.GetAll();
        return Ok(count.Count());
    }

    [HttpGet("bookingCount")]
    public async Task<IActionResult> GetBookingsCount()
    {
        var count = await _unitOfWork.Bookings.GetAll();
        return Ok(count.Count());
    }

    [HttpGet("Top5Specializations")]
    public async Task<IActionResult> Top5Specializations()
    {
        var topSpecializations = await _unitOfWork.Doctors.GetTopDoctorSpecializations();
        return Ok(topSpecializations);
    }

    [HttpGet("Top10Doctors")]
    public async Task<IActionResult> Top10Doctors()
    {
        var topDoctors = await _unitOfWork.Doctors.GetTopDoctors();
        return Ok(topDoctors);
    }

    [HttpGet("bookingsByDate")]
    public async Task<IActionResult> GetBookingsByDate([FromQuery] GetBookingByDateDto request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        DateTime startDate;
        switch (request.Date)
        {
            case "last24Hours":
                startDate = DateTime.Now.AddDays(-1);
                break;
            case "last7Days":
                startDate = DateTime.Now.AddDays(-7);
                break;
            case "last30Days":
                startDate = DateTime.Now.AddDays(-30);
                break;
            case "last12Months":
                startDate = DateTime.Now.AddMonths(-12);
                break;
            default:
                return BadRequest("Invalid Date");
        }

        var bookings = await _unitOfWork.Bookings.GetAll(q => q.CreatedAt >= startDate);
        return Ok(bookings);
    }
}