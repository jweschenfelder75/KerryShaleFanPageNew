using Microsoft.AspNetCore.Mvc;
using de.jweschenfelder.KSFP.Web.Interfaces.BusinessLogic;
using de.jweschenfelder.KSFP.Shared.Objects;

namespace KerryShaleFanPage.Server.Controllers
{
	[ApiController]
    [Route("webapi/[controller]")]
    public class GalleryController : ControllerBase
    {
        private readonly IGenericService<GalleryItemDto> _galleryService;

        private readonly ILogger<GalleryController> _logger;

        public GalleryController(ILogger<GalleryController> logger, IGenericService<GalleryItemDto> galleryService)
        {
            _galleryService = galleryService;
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GalleryItemDto> Get()
        {
            return _galleryService.GetAll();
        }
    }
}