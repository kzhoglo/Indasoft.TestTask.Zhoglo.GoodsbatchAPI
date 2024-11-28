using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data;
using Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsBatchStatesController : ControllerBase
    {
        private readonly ILogger<GoodsBatchStatesController> _logger;
        private readonly IShaguarRepository shaguarRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GoodsBatchStatesController(IShaguarRepository repository, ILogger<GoodsBatchStatesController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            shaguarRepository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GoodsBatchStates>> GetGoodsBatchStates()
        {
            _logger.LogInformation($"Call to api/GoodsBatchStates/GetGoodsBatchStates. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            IEnumerable<GoodsBatchStates> list = shaguarRepository.GetGoodsBatchStates();
            return new ActionResult<IEnumerable<GoodsBatchStates>>(list);
        }
    }
}
