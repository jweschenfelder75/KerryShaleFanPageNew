using de.jweschenfelder.KSFP.Shared.Enums;
using System;
using System.Collections.Generic;

namespace de.jweschenfelder.KSFP.Shared.Configuration
{
	[Serializable]
	public class NewsSettings
	{
		public IList<NewsItem> NewsItems { get; set; } = new List<NewsItem>();
	}

	/// <summary>
	/// TODO: Put classes below in extra files. Let ReSharper do that job.
	/// </summary>

	[Serializable]
	public class NewsItem
	{
		public NewsCategoryEnum Category { get; set; }
		public string? HtmlTitleEn { get; set; }
		public string? HtmlTitleDe { get; set; }
		public string? HtmlSubTitleEn { get; set; }
		public string? HtmlSubTitleDe { get; set; }
		public string? HtmlBodyEn { get; set; }
		public string? HtmlBodyDe { get; set; }
		public string? ImageUrlEn { get; set; }
		public string? ImageUrlDe { get; set; }
		public string? PrimaryUrlEn { get; set; }
		public string? PrimaryUrlDe { get; set; }
		public string? SecondaryUrlEn { get; set; }
		public string? SecondaryUrlDe { get; set; }
		public string? OptionalWhereEn { get; set; }
		public string? OptionalWhereDe { get; set; }
	}
}
