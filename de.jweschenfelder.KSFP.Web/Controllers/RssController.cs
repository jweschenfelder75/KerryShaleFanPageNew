using de.jweschenfelder.KSFP.Shared.Enums;
using de.jweschenfelder.KSFP.Shared.Objects;
using de.jweschenfelder.KSFP.Web.Interfaces.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace de.jweschenfelder.KSFP.Web.Controllers
{
	[Route("webapi/[controller]")]
	[ApiController]
	public class RssController : ControllerBase
	{
		private readonly IGenericService<NewsItemDto> _newsService;

		private readonly ILogger<RssController> _logger;

		private IList<NewsItemDto> items = new List<NewsItemDto>();
		private IList<NewsItemDto> currentItems = new List<NewsItemDto>();

		public RssController(ILogger<RssController> logger, IGenericService<NewsItemDto> newsService)
		{
			_newsService = newsService;
			_logger = logger;
		}

		// GET: webapi/<RssController>
		[ResponseCache(Duration = 1200)]
		[HttpGet]
		public async Task<IActionResult> Get()
		{

			items = _newsService?.GetAll() ?? new List<NewsItemDto>();
			currentItems = items?.Where(i => i.Category == NewsCategoryEnum.Current).ToList() ?? new List<NewsItemDto>();

			// Get the current url
			var baseUrl = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";
			var url = $"{baseUrl}/webapi/rss";

			var syndicationItems = new List<SyndicationItem>();
			foreach (var item in currentItems)
			{
				var title = item.HtmlTitleEn;
				var imageUrl = $"{baseUrl}/{item.ImageUrlEn}";
				var content = !string.IsNullOrWhiteSpace(item.SecondaryUrlEn)
							? $"<strong>{item.HtmlTitleEn}</strong><br/><br/><strong>{item.HtmlSubTitleEn}</strong><br/><br/><img src=\"{imageUrl}\" alt=\"Image\" class=\"img-fluid rounded-3\" /><br/><br/>{item.HtmlBodyEn}<br/><br/>More information:<br />Link #1: <a href=\"{item.PrimaryUrlEn}\" target=\"_blank\">{item.PrimaryUrlEn}</a><br />Link #2: <a href=\"{item.SecondaryUrlEn}\" target=\"_blank\">{item.SecondaryUrlEn}</a>"
							: $"<strong>{item.HtmlTitleEn}</strong><br/><br/><strong>{item.HtmlSubTitleEn}</strong><br/><br/><img src=\"{imageUrl}\" alt=\"Image\" class=\"img-fluid rounded-3\" /><br/><br/>{item.HtmlBodyEn}<br/><br/>More information:<br />Link: <a href=\"{item.PrimaryUrlEn}\" target=\"_blank\">{item.PrimaryUrlEn}</a>";
				syndicationItems.Add(new SyndicationItem(title, content, new Uri(url)));
			}

			// This object reflects our RSS feed root item
			var feed = new SyndicationFeed(
				"Kerry Shale News (via Kerry Shale Fanpage (unofficial))",
				"Get the latest news about Kerry Shale via RSS.",
				new Uri(url))
			{
				// You could create a list here of your blog posts for example
				Items = syndicationItems
			};

			// Create the XML Writer with it's settings
			var settings = new XmlWriterSettings
			{
				Encoding = Encoding.UTF8,
				NewLineHandling = NewLineHandling.Entitize,
				NewLineOnAttributes = true,
				Indent = true, // Makes it easier to read for humans
				Async = true, // You can omit this if you don't use the async API
			};

			using var stream = new MemoryStream();
			await using var xmlWriter = XmlWriter.Create(stream, settings);
			// Create the RSS Feed
			var rssFormatter = new Rss20FeedFormatter(feed, false);
			rssFormatter.WriteTo(xmlWriter);
			await xmlWriter.FlushAsync();

			return File(stream.ToArray(), "application/rss+xml; charset=utf-8");
		}
	}
}
