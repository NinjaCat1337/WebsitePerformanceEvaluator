using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogic.Interfaces;
using HtmlAgilityPack;

namespace ApplicationLogic.Services
{
    public class SiteMapService : ISiteMapService
    {
        public async Task<IEnumerable<string>> GenerateSiteMapFromUrl(string url)
        {
            var generateSiteMap = new Task<IEnumerable<string>>(() =>
            {
                var htmlDocument = new HtmlWeb().Load(url);
                var linkedPages = htmlDocument.DocumentNode.Descendants("a")
                    .Select(a => a.GetAttributeValue("href", null))
                    .Where(u => !string.IsNullOrEmpty(u)).ToList();
                var fullLinks = linkedPages.Where(l => l.Contains("http")).ToList();
                var formattedRelativeLinks = linkedPages.Where(l => !l.Contains("http")).Select(l => url + l).ToList();
                fullLinks.AddRange(formattedRelativeLinks);

                return fullLinks;
            });
            generateSiteMap.Start();

            return await generateSiteMap;
        }
    }
}