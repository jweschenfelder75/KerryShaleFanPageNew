using AutoMapper;
using de.jweschenfelder.KSFP.Shared.Configuration;
using de.jweschenfelder.KSFP.Web.Interfaces.Security;
using de.jweschenfelder.KSFP.Shared.Objects;

namespace de.jweschenfelder.KSFP.Web.Interfaces.BusinessLogic
{
	public class GalleryService : IGenericService<GalleryItemDto>
    {
        private readonly ISecuredConfigurationService _securedConfigurationService;
        private readonly Mapper _mapper;

        private readonly ILogger<GalleryService> _logger;  // TODO: Implement logging!

        public GalleryService(ILogger<GalleryService> logger, ISecuredConfigurationService securedConfigurationService)
        {
            _logger = logger;
            _securedConfigurationService = securedConfigurationService;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GalleryItemDto, GalleryItem>();
                cfg.CreateMap<GalleryItem, GalleryItemDto>();
            });
            _mapper = new Mapper(config);  // Maps properties between Dto and Object and the other way around
        }

        public IList<GalleryItemDto> GetAll()
        {
            var result = _securedConfigurationService.GetCachedGallerySettingsConfigurationFromFile();

            return (!result.GalleryItems.Any())
            ? new List<GalleryItemDto>()
                : _mapper.Map<List<GalleryItemDto>>(result.GalleryItems);
        }
    }
}
