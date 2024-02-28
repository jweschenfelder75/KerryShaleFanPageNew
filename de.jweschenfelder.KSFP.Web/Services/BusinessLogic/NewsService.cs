using AutoMapper;
using de.jweschenfelder.KSFP.Shared.Configuration;
using de.jweschenfelder.KSFP.Shared.Objects;
using de.jweschenfelder.KSFP.Web.Interfaces.Security;

namespace de.jweschenfelder.KSFP.Web.Interfaces.BusinessLogic
{
	public class NewsService : IGenericService<NewsItemDto>
    {
        private readonly ISecuredConfigurationService _securedConfigurationService;
        private readonly Mapper _mapper;

        private readonly ILogger<NewsService> _logger;  // TODO: Implement logging!

        public NewsService(ILogger<NewsService> logger, ISecuredConfigurationService securedConfigurationService)
        {
            _logger = logger;
            _securedConfigurationService = securedConfigurationService;
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NewsItemDto, NewsItem>();
                cfg.CreateMap<NewsItem, NewsItemDto>();
            });
            _mapper = new Mapper(config);  // Maps properties between Dto and Object and the other way around
        }

        public IList<NewsItemDto> GetAll()
        {
            var result = _securedConfigurationService.GetCurrentNewsSettingsConfigurationFromFile();

            return (!result.NewsItems.Any())
            ? new List<NewsItemDto>()
                : _mapper.Map<List<NewsItemDto>>(result.NewsItems);
        }
    }
}
