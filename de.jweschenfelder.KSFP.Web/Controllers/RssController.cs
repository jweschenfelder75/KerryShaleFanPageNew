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
        // GET: webapi/<RssController>
        [ResponseCache(Duration = 1200)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            // Get the current url
            var url = $"{Request.Scheme}://{Request.Host}{Request.PathBase}";

            // This object reflects our RSS feed root item
            var feed = new SyndicationFeed(
                "Title",
                "This is a sample title",
                new Uri(url))
                {
                    // You could create a list here of your blog posts for example
                    Items = new[]
                    {
                        new SyndicationItem(
                            "A Blog Post",
                            "Somecontent",
                            new Uri(url + "/url-to-your-sub-item"))
                    }
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
