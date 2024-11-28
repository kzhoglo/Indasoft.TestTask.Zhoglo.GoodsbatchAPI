using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data;
using Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsController : ControllerBase
    {
        private readonly ILogger<GoodsController> _logger;
        private readonly IShaguarRepository shaguarRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GoodsController(IShaguarRepository repository, ILogger<GoodsController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            shaguarRepository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Goods>> GetGoods()
        {
            _logger.LogInformation($"Call to api/Goods/GetGoods. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            IEnumerable<Goods> list = shaguarRepository.GetGoods();
            return new ActionResult<IEnumerable<Goods>>(list);
        }       
    }
}
