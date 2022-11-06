using MCB.Core.Infra.CrossCutting.Abstractions.Utils;

namespace MCB.Core.Infra.CrossCutting.Utils;

public class Utils
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
