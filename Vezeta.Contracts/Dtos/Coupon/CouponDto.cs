using Vezeta.Domain.Enums;

namespace Vezeta.Contract.Dtos.Coupon;

public class CouponDto
{
    public string Code { get; set; }
    public DiscountType DiscountType { get; set; }
    public bool IsValid { get; set; }
}


