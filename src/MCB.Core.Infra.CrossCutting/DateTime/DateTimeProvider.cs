using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;

namespace MCB.Core.Infra.CrossCutting.DateTime;

public class DateTimeProvider
    : IDateTimeProvider
{
    // Properties
    public Func<DateTimeOffset> GetDateCustomFunction { get; private set; }

    // Constructors
    public DateTimeProvider(Func<DateTimeOffset>? getDateCustomFunction)
    {
        GetDateCustomFunction = getDateCustomFunction ?? new Func<DateTimeOffset>(() => DateTimeOffset.UtcNow);
    }

    // Public Methods
    public DateTimeOffset GetDate()
    {
        return GetDateCustomFunction?.Invoke() ?? DateTimeOffset.UtcNow;
    }
}