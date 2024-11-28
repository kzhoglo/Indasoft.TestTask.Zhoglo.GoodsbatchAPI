using Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Data;
using Indasoft.Zhoglo.TestTask.GoodsbatchAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Indasoft.TestTask.Zhoglo.GoodsbatchAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GoodsBatchController : ControllerBase
    {
        private readonly ILogger<GoodsBatchController> _logger;
        private readonly IShaguarRepository shaguarRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public GoodsBatchController(IShaguarRepository repository, ILogger<GoodsBatchController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            shaguarRepository = repository;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GoodsBatch>> GetGoodsBatch()
        {
            _logger.LogInformation($"Call to api/GoodsBatch/GetGoodsBatch. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            IEnumerable<GoodsBatch> list = shaguarRepository.GetGoodsBatches();
            return new ActionResult<IEnumerable<GoodsBatch>>(list);
        }

        [HttpGet("{id}")]
        public ActionResult<GoodsBatch> GetGoodsBatch(long id)
        {
            _logger.LogInformation($"Call to api/GoodsBatch/GetGoodsBatch. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            var goodsBatch = shaguarRepository.GetGoodsBatch(id);
            if (goodsBatch == null)
            {
                return NotFound();
            }
            return new ActionResult<GoodsBatch>(goodsBatch);
        }

        [HttpPost]
        public ActionResult<GoodsBatch> CreateGoodsBatch(GoodsBatch goodsBatch)
        {
            _logger.LogInformation($"Call to api/GoodsBatch/CreateGoodsBatch. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            if (goodsBatch == null || !GoodsBatch.Validate(goodsBatch))
            {
                return BadRequest();
            }
            var id = shaguarRepository.Add(goodsBatch);
            return CreatedAtAction("GetGoodsBatch", new { id = id }, goodsBatch);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGoodsBatch(long id, GoodsBatch goodsBatch)
        {
            _logger.LogInformation($"Call to api/GoodsBatch/UpdateGoodsBatch. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            if (id == 0 || goodsBatch == null || !GoodsBatch.Validate(goodsBatch))
            {
                return BadRequest();
            }
            shaguarRepository.Update(id, goodsBatch);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBatch(long id)
        {
            _logger.LogInformation($"Call to api/GoodsBatch/DeleteBatch. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            if (id == 0)
            {
                return BadRequest();
            }
            shaguarRepository.Delete(id);
            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchGoodsBatch(long id, PatchGoodsBatch patchGoodsBatch)
        {
            _logger.LogInformation($"Call to api/GoodsBatch/PatchGoodsBatch. Caller IP: {_httpContextAccessor?.HttpContext?.Connection.RemoteIpAddress}");
            if (id == 0 || patchGoodsBatch == null)
            {
                return BadRequest();
            }
            shaguarRepository.Patch(id, patchGoodsBatch);
            return NoContent();
        }
    }
}
