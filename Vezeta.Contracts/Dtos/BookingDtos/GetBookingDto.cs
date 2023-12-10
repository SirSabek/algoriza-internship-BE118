namespace Vezeta.Contract.Dtos.BookingDtos;
public class GetBookingDto
{
    public int Id { get; set; }
    public DateTime RequestDate { get; set; }
    public int PatientId { get; set; }
    public Status Status { get; set; }
}
