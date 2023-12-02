using Vezeta.Application.Common.Interfaces.Services;

namespace Vezeta.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
