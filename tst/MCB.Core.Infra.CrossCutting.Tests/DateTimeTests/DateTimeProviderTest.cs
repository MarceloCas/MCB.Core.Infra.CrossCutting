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
        var timeProviderUtcNow = new DateTimeProvider().GetDate();

        // Assert
        timeProviderUtcNow.Should().BeAfter(utcNow);
    }
    [Fact]
    public void DateTimeProvider_Should_Return_GetDateCustomFuncion()
    {
        // Arrange
        var dateTimeProvider = new DateTimeProvider();
        var utcNow = DateTimeOffset.UtcNow;

        // Act
        dateTimeProvider.ChangeGetDateCustomFunction(new Func<DateTimeOffset>(() => utcNow));
        var timeProviderUtcNow = dateTimeProvider.GetDate();

        // Assert
        timeProviderUtcNow.Should().Be(utcNow);
    }
}
