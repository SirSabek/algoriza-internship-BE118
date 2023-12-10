using Vezeta.Domain.Enums;

namespace Vezeta.Domain.Entities;

public class Coupon
{
    public int Id { get; set; }
    public string Code { get; set; }
    public DiscountType DiscountType { get; set; }
    public bool IsValid { get; set; }
    public int DiscountValue { get; set; } = 0;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}