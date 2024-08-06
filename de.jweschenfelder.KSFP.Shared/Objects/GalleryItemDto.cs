using System;

namespace de.jweschenfelder.KSFP.Shared.Objects
{
	[Serializable]
	public class GalleryItemDto
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
