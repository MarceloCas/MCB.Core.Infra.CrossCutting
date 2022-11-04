using MCB.Core.Infra.CrossCutting.Abstractions.Serialization;
using System.Runtime.CompilerServices;
using System.Text.Json;

[assembly: InternalsVisibleTo("MCB.Core.Infra.CrossCutting.Tests")]

namespace MCB.Core.Infra.CrossCutting.Serialization;

internal class JsonSerializer
    : IJsonSerializer
{
    // Fields
    private readonly JsonSerializerOptions _jsonSerializerOptions = new(
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }
    );

    private readonly Newtonsoft.Json.Schema.Generation.JSchemaGenerator _jSchemaGenerator = new();

    // Public Methods
    public string SerializeToJson(object obj)
    {
        return System.Text.Json.JsonSerializer.Serialize(obj, _jsonSerializerOptions);
    }
    public T? DeserializeFromJson<T>(string json)
    {
        return System.Text.Json.JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);
    }
    public string GenerateJsonSchema(Type type)
    {
        return _jSchemaGenerator.Generate(type).ToString();
    }
    public string GenerateJsonSchema(object obj)
    {
        return GenerateJsonSchema(obj.GetType());
    }
}
