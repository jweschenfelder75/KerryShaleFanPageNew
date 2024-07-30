using de.jweschenfelder.KSFP.Shared.Enums;
using System;

namespace de.jweschenfelder.KSFP.Shared.Objects
{
	[Serializable]
	public class NewsItemDto
	{
		public string? HtmlTitleEn { get; set; }
		public string? HtmlTitleDe { get; set; }
		public string? HtmlSubTitleEn { get; set; }
		public string? HtmlSubTitleDe { get; set; }
		public string? HtmlBodyDe { get; set; }
		public string? HtmlBodyEn { get; set; }
		public string? ImageUrlEn { get; set; }
		public string? ImageUrlDe { get; set; }
		public string? PrimaryUrlEn { get; set; }
		public string? PrimaryUrlDe { get; set; }
		public string? SecondaryUrlEn { get; set; }
		public string? SecondaryUrlDe { get; set; }
		public NewsCategoryEnum Category { get; set; }
	}
}
