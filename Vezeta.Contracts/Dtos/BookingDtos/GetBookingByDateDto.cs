using System.ComponentModel.DataAnnotations;

namespace Vezeta.Contract.Dtos.BookingDtos;

public class GetBookingByDateDto
{
    [EnumDataType(typeof(DateOptions))] 
    public string Date { get; set; }
}