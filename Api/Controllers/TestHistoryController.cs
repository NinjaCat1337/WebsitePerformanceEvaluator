using System.Threading.Tasks;
using ApplicationLogic.DTO;
using ApplicationLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ITestHistoryService _testHistoryService;

        public TestController(ITestHistoryService testHistoryService)
        {
            _testHistoryService = testHistoryService;
        }

        [HttpGet("site", Name = "GetAllSites")]
        public async Task<IActionResult> GetAllSites()
        {
            var response = await _testHistoryService.GetAllSites();

            return Ok(response);
        }

        [HttpGet("testResults", Name = "GetSiteTestResults")]
        public async Task<IActionResult> GetSiteTestResults(int idSite)
        {
            var response = await _testHistoryService.GetTestResultsForSite(idSite);

            return Ok(response);
        }

        [HttpPost("testResults", Name = "AddTestResults")]
        public async Task<IActionResult> CreateTestResults([FromBody] TestResultsAdditionDTO request)
        {
            await _testHistoryService.AddTestResults(request);

            return Ok();
        }
    }
}
