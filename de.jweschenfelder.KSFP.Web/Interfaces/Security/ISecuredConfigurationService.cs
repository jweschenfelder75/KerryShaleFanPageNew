using de.jweschenfelder.KSFP.Shared.Configuration;

namespace de.jweschenfelder.KSFP.Web.Interfaces.Security
{
	public interface ISecuredConfigurationService
	{
		/// <summary>
		/// Returns the old cached NewsSettings data. Implementation hint: You can compare single properties with GetCurrentNewsSettingsConfigurationFromFile() to see if something particular has changed.
		/// </summary>
		/// <returns></returns>
		public NewsSettings GetCachedNewsSettingsConfigurationFromFile();

		/// <summary>
		/// Returns the current NewsSettings data. Implementation hint: You can compare single properties with GetCachedNewsSettingsConfigurationFromFile() to see if something particular has changed.
		/// </summary>
		/// <returns></returns>
		public NewsSettings GetCurrentNewsSettingsConfigurationFromFile();

		/// <summary>
		/// Returns the old cached GallerySettings data. Implementation hint: You can compare single properties with GetCurrentGallerySettingsConfigurationFromFile() to see if something particular has changed.
		/// </summary>
		/// <returns></returns>
		public GallerySettings GetCachedGallerySettingsConfigurationFromFile();

		/// <summary>
		/// Returns the current GallerySettings data. Implementation hint: You can compare single properties with GetCachedGallerySettingsConfigurationFromFile() to see if something particular has changed.
		/// </summary>
		/// <returns></returns>
		public GallerySettings GetCurrentGallerySettingsConfigurationFromFile();
	}
}
