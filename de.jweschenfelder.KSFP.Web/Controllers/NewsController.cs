using Microsoft.AspNetCore.Mvc;
using de.jweschenfelder.KSFP.Web.Interfaces.BusinessLogic;
using de.jweschenfelder.KSFP.Shared.Objects;

namespace KerryShaleFanPage.Server.Controllers
{
	[ApiController]
    [Route("webapi/[controller]")]
    public class NewsController : ControllerBase
    {
        private readonly IGenericService<NewsItemDto> _newsService;

        private readonly ILogger<NewsController> _logger;

        public NewsController(ILogger<NewsController> logger, IGenericService<NewsItemDto> newsService)
        {
            _newsService = newsService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<NewsItemDto> Get()
        {
            return _newsService.GetAll();
        }
    }
}