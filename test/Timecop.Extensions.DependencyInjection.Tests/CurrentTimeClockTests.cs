using FluentAssertions;

namespace TCop.Extensions.DependencyInjection.Tests
{
    public class CurrentTimeClockTests
    {
        private static readonly TimeSpan DateTimeComparisonPrecision = TimeSpan.FromMilliseconds(50);

        [Fact]
        public void Now_ShouldReturnCurrentTime()
        {
            new CurrentTimeClock().Now.Should().BeCloseTo(DateTime.Now, DateTimeComparisonPrecision);
        }

        [Fact]
        public void UtcNow_ShouldReturnCurrentTime()
        {
            new CurrentTimeClock().UtcNow.Should().BeCloseTo(DateTime.UtcNow, DateTimeComparisonPrecision);
        }
    }
}