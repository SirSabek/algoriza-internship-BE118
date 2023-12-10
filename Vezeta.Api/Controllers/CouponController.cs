using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Vezeta.Application.Common.Interfaces.Persistance;
using Vezeta.Contract.Dtos.Coupon;
using Vezeta.Domain.Entities;

namespace Vezeta.Api.Controllers;

[ApiController]
[Route("api/[controller]")]

public class CouponConTroller : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;


    public CouponConTroller(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet("coupons")]
    public async Task<IActionResult> GetCoupons()
    {
        var coupons = await _unitOfWork.Coupon.GetAll();
        return Ok(coupons);
    }

    [HttpGet("coupon/{id:int}")]
    public async Task<IActionResult> GetCoupon(int id)
    {
        var coupon = await _unitOfWork.Coupon.Get(q => q.Id == id);
        return Ok(coupon);
    }

    [HttpPost("coupon")]
    public async Task<IActionResult> AddCoupon(CouponDto couponDto)
    {
        var coupon = _mapper.Map<Coupon>(couponDto);
        coupon.CreatedAt = DateTime.Now;
        await _unitOfWork.Coupon.Insert(coupon);
        await _unitOfWork.Save();
        return Ok(coupon);
    }

    [HttpPut("coupon/{id:int}")]
    public async Task<IActionResult> UpdateCoupon(int id, CouponDto couponDto)
    {
        var coupon = await _unitOfWork.Coupon.Get(q => q.Id == id);
        if (coupon == null)
        {
            return NotFound();
        }
        _mapper.Map(couponDto, coupon);
        coupon.UpdatedAt = DateTime.Now;
        await _unitOfWork.Save();
        return Ok(coupon);
    }

    [HttpDelete("coupon/{id:int}")]
    public async Task<IActionResult> DeleteCoupon(int id)
    {
        var coupon = await _unitOfWork.Coupon.Get(q => q.Id == id);
        if (coupon == null)
        {
            return NotFound();
        }
        await _unitOfWork.Coupon.Delete(id);
        await _unitOfWork.Save();
        return Ok(coupon);
    }
}