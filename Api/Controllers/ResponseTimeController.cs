using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResponseTimeController : ControllerBase
    {
        private readonly IResponseTimeCheckService _responseTimeCheckService;

        public ResponseTimeController(IResponseTimeCheckService responseTimeCheckService)
        {
            _responseTimeCheckService = responseTimeCheckService;
        }

        [HttpPost]
        public async Task<IActionResult> Get([FromBody] IEnumerable<string> request)
        {
            var result = await _responseTimeCheckService.CheckResponseTimes(request);

            return Ok(result);
        }
    }
}
