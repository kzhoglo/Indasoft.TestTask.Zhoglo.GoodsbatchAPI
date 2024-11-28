using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data;
using Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MeasureUnitsBatchController : ControllerBase
    {
        private readonly ILogger<MeasureUnitsBatchController> _logger;
        private readonly IShaguarRepository shaguarRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MeasureUnitsBatchController(IShaguarRepository repository, ILogger<MeasureUnitsBatchController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            shaguarRepository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MeasureUnits>> GetMeasureUnits()
        {
            _logger.LogInformation($"Call to api/MeasureUnitsBatch/GetMeasureUnits. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            IEnumerable<MeasureUnits> list = shaguarRepository.GetMeasureUnits();
            return new ActionResult<IEnumerable<MeasureUnits>>(list);
        }
    }
}
