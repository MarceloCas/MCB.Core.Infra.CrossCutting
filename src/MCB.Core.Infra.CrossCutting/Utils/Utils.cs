using MCB.Core.Infra.CrossCutting.Abstractions.Utils;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MCB.Core.Infra.CrossCutting.Tests")]

namespace MCB.Core.Infra.CrossCutting.Utils;

internal class Utils
    : IUtils
{
    public TEnum GetRandomEnumValue<TEnum>()
        where TEnum : struct, Enum, IConvertible
    {
        return Enum.GetValues<TEnum>()
            .OrderBy(q => Guid.NewGuid())
            .FirstOrDefault();
    }
}
