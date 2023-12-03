using Microsoft.AspNetCore.Identity;

namespace Vezeta.Domain.Entities;

public class Patient : User
{
    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}