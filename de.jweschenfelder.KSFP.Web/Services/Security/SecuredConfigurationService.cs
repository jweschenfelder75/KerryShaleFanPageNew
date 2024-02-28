using Microsoft.Extensions.Options;
using de.jweschenfelder.KSFP.Shared.Configuration;
using de.jweschenfelder.KSFP.Web.Interfaces.Security;

namespace de.jweschenfelder.KSFP.Web.Services.Security
{
    public class SecuredConfigurationService : ISecuredConfigurationService
    {
        private readonly IOptions<NewsSettings> _cachedNewsSettings;
        private readonly IOptionsMonitor<NewsSettings> _currentNewsSettings;
        private readonly IOptions<GallerySettings> _cachedGallerySettings;
        private readonly IOptionsMonitor<GallerySettings> _currentGallerySettings;

        private readonly ILogger<SecuredConfigurationService> _logger;  // TODO: Implement logging!

        /// <summary>
        /// 
        /// </summary>
        public SecuredConfigurationService(ILogger<SecuredConfigurationService> logger, 
            IOptions<NewsSettings> cachedNewsSettings, IOptionsMonitor<NewsSettings> currentNewsSettings, IOptions<GallerySettings> cachedGallerySettings,
            IOptionsMonitor<GallerySettings> currentGallerySettings)
        {
            _logger = logger;
            _cachedNewsSettings = cachedNewsSettings;
            _currentNewsSettings = currentNewsSettings;
            _cachedGallerySettings = cachedGallerySettings;
            _currentGallerySettings = currentGallerySettings;
        }

        /// <inheritdoc cref="ISecuredConfigurationService"/>
        public NewsSettings GetCachedNewsSettingsConfigurationFromFile()
        {
            return _cachedNewsSettings.Value;
        }

        /// <inheritdoc cref="ISecuredConfigurationService"/>
        public NewsSettings GetCurrentNewsSettingsConfigurationFromFile()
        {
            return _currentNewsSettings.CurrentValue;
        }

        /// <inheritdoc cref="ISecuredConfigurationService"/>
        public GallerySettings GetCachedGallerySettingsConfigurationFromFile()
        {
            return _cachedGallerySettings.Value;
        }

        /// <inheritdoc cref="ISecuredConfigurationService"/>
        public GallerySettings GetCurrentGallerySettingsConfigurationFromFile()
        {
            return _currentGallerySettings.CurrentValue;
        }
    }
}
