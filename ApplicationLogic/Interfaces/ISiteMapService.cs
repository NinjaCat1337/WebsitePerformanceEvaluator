using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationLogic.Interfaces
{
    public interface ISiteMapService
    {
        Task<IEnumerable<string>> GenerateSiteMapFromUrl(string url);
    }
}