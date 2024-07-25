using LogSearcherWeb.Interfaces;
using LogSearcherWeb.Services;

namespace Shortener.Presentation.Tools
{
    /// <summary>
    /// Used to instance extension-methods to IServiceCollection
    /// </summary>
    public static class ServiceExtensions
    {
        /// <summary>
        /// Configures DI-container
        /// </summary>
        public static void AddServicesIntoDI(this IServiceCollection services)
        {
            services.AddTransient<ILogSearchService, LogSearchService>();
        }

    }
}
