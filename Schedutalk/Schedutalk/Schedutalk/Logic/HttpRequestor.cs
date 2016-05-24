using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Schedutalk.Logic
{
    class HttpRequestor
    {
        public async Task<string> getHttpRequestAsString(Func<string, HttpRequestMessage> requestTask, string input)
        {
            HttpClient httpClient = new HttpClient();
            HttpRequestMessage request = requestTask(input);
            var response = httpClient.SendAsync(request);


            var result = await response.Result.Content.ReadAsStringAsync();
            return result;
        }

    }
}
