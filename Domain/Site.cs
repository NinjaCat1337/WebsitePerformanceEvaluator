using System.Collections.Generic;
using System.Linq;
using Domain.Models;

namespace Domain
{
    public class Site : Entity
    {
        public string SiteUrl { get; protected set; }

        private readonly List<TestResult> _testResults = new List<TestResult>();
        public IEnumerable<TestResult> TestResults => _testResults.AsEnumerable();

        protected Site() { }

        public static Site Create(string url) => new Site { SiteUrl = url };

        public void AddTestResults(TestResult testResult) => _testResults.Add(testResult);
    }
}