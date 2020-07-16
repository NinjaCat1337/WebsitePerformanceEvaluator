using System;
using System.Collections.Generic;

namespace ApplicationLogic.DTO
{
    public class TestResultsGettingDTO
    {
        public int IdSite { get; set; }

        public IEnumerable<SiteMapUrlGettingDTO> SiteMapUrls { get; set; }
    }
}