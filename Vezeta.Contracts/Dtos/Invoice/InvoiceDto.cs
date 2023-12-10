namespace Vezeta.Contracts.Dtos.Invoice;

public class InvoiceDto
{
    public int BookingId { get; set; }
    public int PatientId { get; set; }
    public int TotalPrice { get; set; }
}