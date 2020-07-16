using System.Threading.Tasks;
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

        [HttpGet]
        public async Task<IActionResult> Get(string url)
        {
            var siteMap = await _siteMapService.GenerateSiteMapFromUrl(url);

            return Ok(siteMap);
        }
    }
}
