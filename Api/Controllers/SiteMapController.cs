using System.Threading.Tasks;
using Api.Contracts.Requests;
using ApplicationLogic.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SiteMapController : ControllerBase
    {
        private readonly ISiteMapService _siteMapService;

        public SiteMapController(ISiteMapService siteMapService)
        {
            _siteMapService = siteMapService;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateSiteMap([FromBody] GenerateSiteMapRequest request)
        {
            var siteMap = await _siteMapService.GenerateSiteMapFromUrl(request.Url);

            return Ok(siteMap);
        }
    }
}
