using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.Tests.EnumsTests;

public class EnumUtilsTest
{
    [Fact]
    public void EnumUtils_Should_GetRandomEnumValue()
    {
        // Arrange
        var dummyEnumCollection = new List<DummyEnum>();

        // Act
        for (int i = 0; i < 100; i++)
            dummyEnumCollection.Add(new Utils.Utils().GetRandomEnumValue<DummyEnum>());

        // Assert
        foreach (var dummyEnum in dummyEnumCollection)
            Enum.IsDefined(dummyEnum).Should().BeTrue();

        dummyEnumCollection.Distinct().Count().Should().BeGreaterThan(1);
    }

    public enum DummyEnum
    {
        DummyValueA,
        DummyValueB,
        DummyValueC
    }
}
