namespace Vezeta.Contract.Dtos.BookingDtos
{
    public class AddBookingDto
    {
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int ScheduleDayId { get; set; }
        public int TimeSlotId { get; set; }
        public string? Coupon { get; set; } = null;
    }
}