using MCB.Core.Infra.CrossCutting.Abstractions.Serialization;
using ProtoBuf.Meta;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("MCB.Core.Infra.CrossCutting.Tests")]

namespace MCB.Core.Infra.CrossCutting.Serialization;

internal class ProtobufSerializer
    : IProtobufSerializer
{
    // Public static methods
    public static void ConfigureTypeCollection(IEnumerable<Type>? typeCollection)
    {
        if (typeCollection is null)
            return;

        foreach (var type in typeCollection)
        {
            var metaType = RuntimeTypeModel.Default.Add(
                type,
                applyDefaultBehaviour: false
            );

            foreach (var property in type.GetProperties())
                metaType.Add(property.Name);
        }
    }

    // Public Methods
    public byte[] SerializeToProtobuf(object obj)
    {
        using var memoryStream = new MemoryStream();
        RuntimeTypeModel.Default.Serialize(memoryStream, obj);
        return memoryStream.ToArray();
    }
    public T? DeserializeFromProtobuf<T>(byte[] byteArray)
    {
        using var memoryStream = new MemoryStream(byteArray);
        return RuntimeTypeModel.Default.Deserialize<T>(memoryStream);
    }
}
