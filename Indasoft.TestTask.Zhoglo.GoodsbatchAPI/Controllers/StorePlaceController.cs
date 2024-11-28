using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data;
using Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StorePlaceController : ControllerBase
    {
        private readonly ILogger<StorePlaceController> _logger;
        private readonly IShaguarRepository shaguarRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StorePlaceController(IShaguarRepository repository, ILogger<StorePlaceController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            shaguarRepository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<StorePlace>> GetStorePlaces()
        {
            _logger.LogInformation($"Call to api/StorePlace/GetStorePlaces. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            IEnumerable<StorePlace> list = shaguarRepository.GetStorePlaces();
            return new ActionResult<IEnumerable<StorePlace>>(list);
        }
    }
}
