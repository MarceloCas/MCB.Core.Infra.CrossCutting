using MCB.Core.Infra.CrossCutting.Abstractions.DateTime;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MCB.Core.Infra.CrossCutting.Tests")]

namespace MCB.Core.Infra.CrossCutting.DateTime;

internal class DateTimeProvider
    : IDateTimeProvider
{
    // Properties
    public Func<DateTimeOffset>? GetDateCustomFunction { get; private set; }

    // Public Methods
    public void ChangeGetDateCustomFunction(Func<DateTimeOffset>? getDateCustomFunction)
    {
        GetDateCustomFunction = getDateCustomFunction;
    }
    public DateTimeOffset GetDate()
    {
        return GetDateCustomFunction?.Invoke() ?? DateTimeOffset.UtcNow;
    }
}
