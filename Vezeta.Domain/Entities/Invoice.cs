using System.ComponentModel.DataAnnotations.Schema;

namespace Vezeta.Domain.Entities;

public class Invoice
{
    public int Id { get; set; }
    [ForeignKey(nameof(Booking))]
    public int BookingId { get; set; }
    public Booking Booking { get; set; } = null!;
    [ForeignKey(nameof(Patient))]
    public int PatientId { get; set; }
    public Patient Patient { get; set; } = null!;
    public int TotalPrice { get; set; }
}