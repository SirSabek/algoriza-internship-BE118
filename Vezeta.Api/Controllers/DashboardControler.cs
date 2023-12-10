using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common.Interfaces.Persistance;

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
}