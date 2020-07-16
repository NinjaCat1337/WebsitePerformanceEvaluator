using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLogic.DTO;

namespace ApplicationLogic.Interfaces
{
    public interface ITestHistoryService
    {
        Task<IEnumerable<SiteGettingDTO>> GetAllSites();
        Task<int> AddTestResults(TestResultsAdditionDTO dto);
        Task<TestResultsGettingDTO> GetTestResultsForSite(int idSite);
    }
}