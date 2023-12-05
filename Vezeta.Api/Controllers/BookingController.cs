using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Contract.Dtos.BookingDtos;
using Vezeta.Domain.Entities;

namespace Vezeta.Api.Controllers;

[ApiController]
[Route("booking")]

public class BookingController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookingController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("bookings")]
    public async Task<IActionResult> GetBookings([FromQuery] RequestParams requestParams)
    {
        var bookings = await _unitOfWork.Bookings.GetPagedList(requestParams, new List<string> { "Patient", "Doctor" });
        var result = _mapper.Map<List<GetBookingDto>>(bookings);
        return Ok(result);
    }

    // update this to capture the doctor id from the token
    [HttpGet("doctor/{id:int}")]
    public async Task<IActionResult> GetDoctorBookings(int id)
    {
        var bookings = await _unitOfWork.Bookings.GetAll(q=> q.DoctorId == id, orderBy: q => q.OrderByDescending(q => q.Date), new List<string> { "Patient", "Doctor" });
        var result = _mapper.Map<List<GetBookingDto>>(bookings);
        return Ok(result);
    }

    [HttpGet("booking/{id:int}")]
    public async Task<IActionResult> GetBooking(int id)
    {
        var booking = await _unitOfWork.Bookings.Get(q => q.Id == id, new List<string> { "Patient", "Doctor" });
        var result = _mapper.Map<GetBookingDto>(booking);
        return Ok(result);
    }


    [HttpPost("AddBooking")]
    public async Task<IActionResult> AddBooking([FromBody] AddBookingDto bookingDto)
    {
        var booking = _mapper.Map<Booking>(bookingDto);
        booking.PatientId = 1; // update this to capture the patient id from the token
        booking.CreatedAt = DateTime.Now;
        booking.Status = Status.Pending;
        await _unitOfWork.Bookings.Insert(booking);
        await _unitOfWork.Save();
        
        return Ok(bookingDto);
    }

    [HttpPut("id:int", Name = "UpdateBooking")]
    public async Task<IActionResult> UpdateBooking(int id, [FromBody] UpdateBookingDto bookingDto)
    {
        var booking = await _unitOfWork.Bookings.Get(q => q.Id == id);
        booking = _mapper.Map(bookingDto, booking);
        booking.UpdatedAt = DateTime.Now;
        _unitOfWork.Bookings.Update(booking);
        await _unitOfWork.Save();
        return NoContent();
    }

    [HttpDelete("DeleteBooking")]
    public async Task<IActionResult> DeleteBooking(int id)
    {
        await _unitOfWork.Bookings.Delete(id);
        await _unitOfWork.Save();
        return NoContent();
    }
}