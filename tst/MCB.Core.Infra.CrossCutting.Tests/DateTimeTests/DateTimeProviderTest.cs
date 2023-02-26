using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DateTime;
using System;
using System.Runtime.CompilerServices;
using Xunit;

[assembly:InternalsVisibleTo("MCB.Core.Infra.CrossCutting.Tests")]

namespace MCB.Core.Infra.CrossCutting.Tests.DateTimeTests;

public class DateTimeProviderTest
{
    [Fact]
    public void DateTimeProvider_Should_Return_GetDate()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;

        // Act
        var timeProviderUtcNow = new DateTimeProvider(getDateCustomFunction: null).GetDate();

        // Assert
        timeProviderUtcNow.Should().BeAfter(utcNow);
    }
    [Fact]
    public void DateTimeProvider_Should_Return_GetDateCustomFuncion()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;
        var dateTimeProvider = new DateTimeProvider(new Func<DateTimeOffset>(() => utcNow));

        // Act
        var timeProviderUtcNow = dateTimeProvider.GetDate();

        // Assert
        timeProviderUtcNow.Should().Be(utcNow);
    }
}