using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Domain
{
    public class TestResult : Entity
    {
        public DateTime TestDate { get; protected set; }

        public Site Site { get; protected set; }

        private readonly List<SiteMapUrlResponseTime> _siteMapUrlResponseTimes = new List<SiteMapUrlResponseTime>();
        public IEnumerable<SiteMapUrlResponseTime> SiteMapUrlResponseTimes => _siteMapUrlResponseTimes.AsEnumerable();

        protected TestResult() { }

        public static TestResult Create() => new TestResult
        {
            TestDate = DateTime.Now
        };

        public void AddSiteMapUrlResponse(SiteMapUrlResponseTime siteMapUrlResponse) =>
            _siteMapUrlResponseTimes.Add(siteMapUrlResponse);
    }
}