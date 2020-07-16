using Domain.Models;

namespace Domain
{
    public class SiteMapUrlResponseTime : Entity
    {
        public string Url { get; protected set; }
        public int ResponseTimeMilliseconds { get; protected set; }

        public TestResult TestResult { get; protected set; }

        protected SiteMapUrlResponseTime() { }

        public static SiteMapUrlResponseTime Create(string url, int response) => new SiteMapUrlResponseTime
        {
            Url = url,
            ResponseTimeMilliseconds = response
        };
    }
}