using System;
using System.Collections.Generic;

namespace de.jweschenfelder.KSFP.Shared.Configuration
{
	[Serializable]
	public class GallerySettings
	{
		public IList<GalleryItem> GalleryItems { get; set; } = new List<GalleryItem>();
	}

	/// <summary>
	/// TODO: Put classes below in extra files. Let ReSharper do that job.
	/// </summary>

	[Serializable]
	public class GalleryItem
	{
		public string? HtmlTitleEn { get; set; }
		public string? HtmlTitleDe { get; set; }
		public string? ThumbnailUrlEn { get; set; }
		public string? ThumbnailUrlDe { get; set; }
		public string? UrlEn { get; set; }
		public string? UrlDe { get; set; }
		public string? AltEn { get; set; }
		public string? AltDe { get; set; }
		public string? HtmlCreditsEn { get; set; }
		public string? HtmlCreditsDe { get; set; }
	}
}
