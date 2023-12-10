using Vezeta.Domain.Entities;
using Vezeta.Domain.Enums;

namespace Vezeta.Contract.Dtos.Patient
{
    public class GetPatientDto 
    {
        public string FullName { get; set; }
        public byte[] Image { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        //public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
    }
}