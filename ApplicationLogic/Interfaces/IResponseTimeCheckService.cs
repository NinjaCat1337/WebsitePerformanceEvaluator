using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLogic.DTO;

namespace ApplicationLogic.Interfaces
{
    public interface IResponseTimeCheckService
    {
        //Task<IEnumerable<UrlResponseTime>> CheckResponseTime(IEnumerable<string> urls);
        Task<IEnumerable<UrlResponseTimeDTO>> CheckResponseTimes(IEnumerable<string> urls);
    }
}