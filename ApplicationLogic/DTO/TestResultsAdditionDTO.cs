using System.Collections.Generic;

namespace ApplicationLogic.DTO
{
    public class TestResultsAdditionDTO
    {
        public string SiteUrl { get; set; }
        public IEnumerable<UrlResponseTimeDTO> UrlResponseTimes { get; set; }
    }
}