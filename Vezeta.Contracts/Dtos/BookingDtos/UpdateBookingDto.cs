namespace Vezeta.Contract.Dtos.BookingDtos
{
    public class UpdateBookingDto
    {
        public DateTime Date { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public Status Status { get; set; }
    }
}