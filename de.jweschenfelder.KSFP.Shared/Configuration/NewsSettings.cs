﻿using System;
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
		public string? NewsHtmlEn { get; set; }
		public string? NewsHtmlDe { get; set; }
	}
}
