using DI.Basic.Application.Common.Interfaces.Services;

namespace DI.Basic.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
