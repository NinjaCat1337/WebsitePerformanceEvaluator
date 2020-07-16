using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogic.DTO;
using ApplicationLogic.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Domain;
using Microsoft.Extensions.Configuration;

namespace ApplicationLogic.Services
{
    public class TestHistoryService : ITestHistoryService
    {
        private readonly IRepository<Site> _siteRepository;

        public TestHistoryService(IConfiguration configuration)
        {
            _siteRepository = new SiteRepository(configuration);
        }

        public async Task<int> AddTestResults(TestResultsAdditionDTO dto)
        {
            var site = (await _siteRepository.GetByAsync(s => s.SiteUrl == dto.SiteUrl)).FirstOrDefault();

            if (site == null)
            {
                var newSite = Site.Create(dto.SiteUrl);

                await _siteRepository.CreateAsync(newSite);

                var testResults = TestResult.Create();
                newSite.AddTestResults(testResults);

                foreach (var urlResponseTime in dto.UrlResponseTimes)
                {
                    var siteMapUrl = SiteMapUrlResponseTime.Create(urlResponseTime.Url, urlResponseTime.ResponseTimeMilliseconds);
                    testResults.AddSiteMapUrlResponse(siteMapUrl);
                }

                await _siteRepository.SaveChangesAsync();

                return newSite.Id;
            }
            else
            {
                var testResults = TestResult.Create();
                site.AddTestResults(testResults);

                foreach (var urlResponseTime in dto.UrlResponseTimes)
                {
                    var siteMapUrl = SiteMapUrlResponseTime.Create(urlResponseTime.Url, urlResponseTime.ResponseTimeMilliseconds);
                    testResults.AddSiteMapUrlResponse(siteMapUrl);
                }

                await _siteRepository.SaveChangesAsync();

                return site.Id;
            }
        }

        public async Task<IEnumerable<SiteGettingDTO>> GetAllSites()
        {
            var sites = await _siteRepository.GetAllAsync();

            return sites.Select(SiteGettingDTO.MapFromSiteEntity);
        }

        public async Task<TestResultsGettingDTO> GetTestResultsForSite(int idSite)
        {
            var site = (await _siteRepository.GetByAsync(s => s.Id == idSite)).FirstOrDefault();

            if (site == null)
                throw new Exception($"Site with id: {idSite} is not found.");

            var testResults = new TestResultsGettingDTO { IdSite = site.Id };

            var allSiteUrlResponseTimes =
                (from testResult in site.TestResults
                 from siteMapUrlResponseTime in testResult.SiteMapUrlResponseTimes
                 select new UrlResponseTimeDTO
                 {
                     Url = siteMapUrlResponseTime.Url,
                     ResponseTimeMilliseconds = siteMapUrlResponseTime.ResponseTimeMilliseconds
                 })
                .ToList();

            var uniqueUrls = allSiteUrlResponseTimes.Select(urt => urt.Url).Distinct();

            var uniqueUrlsStatistic = uniqueUrls.Select(uniqueUrl => new SiteMapUrlGettingDTO
            {
                Url = uniqueUrl,
                MinValue = allSiteUrlResponseTimes.Where(urt => urt.Url == uniqueUrl)
                        .Min(urt => urt.ResponseTimeMilliseconds),
                MaxValue = allSiteUrlResponseTimes.Where(urt => urt.Url == uniqueUrl)
                        .Max(urt => urt.ResponseTimeMilliseconds)
            })
                .OrderByDescending(urt => urt.MinValue).ToList();

            testResults.SiteMapUrls = uniqueUrlsStatistic;

            return testResults;
        }
    }
}