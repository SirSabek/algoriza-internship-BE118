using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Contracts.Dtos.Invoice;
using Vezeta.Domain.Entities;
using Vezeta.Domain.Enums;

namespace Vezeta.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InvoiceConTroller : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InvoiceConTroller(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    [HttpGet("invoices")]
    public async Task<IActionResult> GetInvoices()
    {
        var invoices = await _unitOfWork.Invoices.GetAll(includes: new(){"Booking"});
        return Ok(invoices);
    }

    [HttpGet("invoice/{id:int}")]
    public async Task<IActionResult> GetInvoice(int id)
    {
        var invoice = await _unitOfWork.Invoices.Get(q => q.Id == id, includes: new(){"Booking"});
        return Ok(invoice);
    }

    [HttpPost("invoice")]
    public async Task<IActionResult> AddInvoice(InvoiceDto invoiceDto)
    {
        var invoice = _mapper.Map<Invoice>(invoiceDto);
        var totalPrice = await CalculateTotalPrice(invoiceDto.BookingId);
        invoice.TotalPrice = totalPrice;
        await _unitOfWork.Invoices.Insert(invoice);
        await _unitOfWork.Save();
        return Ok(new{invoice.Id, invoice.BookingId, invoice.TotalPrice});
    }

    private async Task<int> CalculateTotalPrice(int bookingId)
    {
        var booking = await _unitOfWork.Bookings.Get(q => q.Id == bookingId);
        var doctor = await _unitOfWork.Doctors.Get(q => q.Id == booking.DoctorId);
        var coupon = await _unitOfWork.Coupon.Get(q => q.Code == booking.Coupon);

        if (coupon is not null)
        {
            if(coupon.DiscountType == DiscountType.Percentage)
            {
                return (int) (doctor.Price * (coupon.DiscountValue / 100));
            }
            else
            {
                return doctor.Price - coupon.DiscountValue;
            }
        }
        else
        {
            return doctor.Price;
        }
    }
}