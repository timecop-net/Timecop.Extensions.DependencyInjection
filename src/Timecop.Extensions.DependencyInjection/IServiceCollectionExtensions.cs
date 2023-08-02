using Microsoft.Extensions.DependencyInjection;

namespace TCop.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtensions
    {
        /// <summary>
        /// Registers the singleton instance of the <see cref="IClock"/> implementation that returns the current time.
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTimecop(this IServiceCollection services)
        {
            services.AddSingleton<IClock>(new CurrentTimeClock());
            return services;
        }
    }
}