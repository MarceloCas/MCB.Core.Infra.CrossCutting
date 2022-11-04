using FluentAssertions;
using MCB.Core.Infra.CrossCutting.Serialization;
using System;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.Tests.SerializationTests;

public class ProtobufSerializerTest
{
    [Fact]
    public void ExtensionMethods_Should_Serialize_And_Deserialize()
    {
        // Arrange
        var customer = new Customer
        {
            Id = Guid.NewGuid(),
            CreatedBy = "marcelo.castelo@outlook.com",
            CreatedAt = System.DateTime.UtcNow,
            UpdatedBy = null,
            UpdatedAt = null
        };
        ProtobufSerializer.ConfigureTypeCollection(new[] { typeof(Customer) });

        // Act
        var protobuf = new ProtobufSerializer().SerializeToProtobuf(customer);
        var deserializedCustomer = new ProtobufSerializer().DeserializeFromProtobuf<Customer>(protobuf);

        // Assert
        deserializedCustomer.Should().NotBeNull();
        customer.Id.Should().Be(deserializedCustomer.Id);
        customer.CreatedAt.Should().Be(deserializedCustomer.CreatedAt);
        customer.CreatedBy.Should().Be(deserializedCustomer.CreatedBy);
        deserializedCustomer.UpdatedBy.Should().BeEmpty();
        deserializedCustomer.UpdatedAt.Should().BeNull();
    }

    public class Customer
    {
        public Guid Id { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public System.DateTime? UpdatedAt { get; set; }

        public Customer()
        {
            CreatedBy = string.Empty;
            UpdatedBy = string.Empty;
            UpdatedAt = default;
        }
    }
}
