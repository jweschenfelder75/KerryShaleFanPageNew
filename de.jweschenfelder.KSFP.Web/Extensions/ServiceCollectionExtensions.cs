using de.jweschenfelder.KSFP.Web.Providers;

namespace de.jweschenfelder.KSFP.Web.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBrowserTimeProvider(this IServiceCollection services)
            => services.AddSingleton<TimeProvider, BrowserTimeProvider>();
    }
}
