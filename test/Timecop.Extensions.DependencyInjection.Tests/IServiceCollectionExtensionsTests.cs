using Microsoft.Extensions.DependencyInjection;
using System;
using FluentAssertions;
using TCop;

namespace TCop.Extensions.DependencyInjection.Tests
{
    public class IServiceCollectionExtensionsTests
    {
        public class TestClockConsumer
        {
            public IClock Clock { get; }

            public TestClockConsumer(IClock clock)
            {
                Clock = clock;
            }
        }

        [Fact]
        public void AddTimecop_RegistersCurrentTimeClockAsSingleton()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddTransient<TestClockConsumer>();
            serviceCollection.AddTimecop();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var serviceInstance1 = serviceProvider.GetService<TestClockConsumer>()!;
            var serviceInstance2 = serviceProvider.GetService<TestClockConsumer>()!;

            serviceInstance1.Clock.Should().BeOfType<CurrentTimeClock>();

            serviceInstance1.Clock.Should().Be(serviceInstance2.Clock);
        }
    }
}