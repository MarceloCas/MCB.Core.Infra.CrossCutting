using System;
using Xunit;
using FluentAssertions;
using MCB.Core.Infra.CrossCutting.Serialization;

namespace MCB.Core.Infra.CrossCutting.Tests.SerializationTests;

public class ExtensionMethodsTest
{
    [Fact]
    public void ExtensionMethods_Should_Serialize_And_Deserialize()
    {
        // Arrange
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            CreatedBy = "marcelo.castelo@outlook.com",
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedBy = null,
            UpdatedAt = null
        };

        // Act
        var json = new JsonSerializer().SerializeToJson(customer);
        var deserializedCustomer = new JsonSerializer().DeserializeFromJson<Customer>(json);

        // Assert
        customer.Id.Should().Be(deserializedCustomer.Id);
        customer.CreatedAt.Should().Be(deserializedCustomer.CreatedAt);
        customer.CreatedBy.Should().Be(deserializedCustomer.CreatedBy);
        deserializedCustomer.UpdatedBy.Should().BeNull();
        deserializedCustomer.UpdatedAt.Should().BeNull();
    }

    [Fact]
    public void ExtensionMethods_Should_Generate_Schema()
    {
        // Arrange
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            CreatedBy = "marcelo.castelo@outlook.com",
            CreatedAt = DateTimeOffset.UtcNow,
            UpdatedBy = null,
            UpdatedAt = null
        };

        // Act
        var jsonSchema1 = new JsonSerializer().GenerateJsonSchema(customer);
        var jsonSchema2 = new JsonSerializer().GenerateJsonSchema(customer);

        // Assert
        jsonSchema1.Should().NotBeNull();
        jsonSchema2.Should().NotBeNull();
    }
}

public class Customer
{
    public Guid Id { get; set; }
    public string CreatedBy { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public string UpdatedBy { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }

    public Customer()
    {
        CreatedBy = string.Empty;
        UpdatedBy = string.Empty;
        UpdatedAt = default;
    }
}