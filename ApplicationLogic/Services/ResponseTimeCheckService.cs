using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using ApplicationLogic.DTO;
using ApplicationLogic.Interfaces;

namespace ApplicationLogic.Services
{
    public class ResponseTimeCheckService : IResponseTimeCheckService
    {
        public async Task<IEnumerable<UrlResponseTimeDTO>> CheckResponseTimes(IEnumerable<string> urls)
        {
            var checkResponseTimes = new Task<IEnumerable<UrlResponseTimeDTO>>(() =>
            {
                var urlResponseTimes = new List<UrlResponseTimeDTO>();
                foreach (var url in urls)
                {
                    var request = (HttpWebRequest)WebRequest.Create(url);
                    var timer = new Stopwatch();

                    timer.Start();

                    var response = (HttpWebResponse)request.GetResponse();
                    response.Close();

                    timer.Stop();

                    var timeTaken = timer.Elapsed;

                    var urlResponseTime = new UrlResponseTimeDTO
                    {
                        Url = url,
                        ResponseTimeMilliseconds = timeTaken.Milliseconds
                    };

                    urlResponseTimes.Add(urlResponseTime);
                }
                return urlResponseTimes;
            });

            checkResponseTimes.Start();
            return await checkResponseTimes;
        }
    }
}