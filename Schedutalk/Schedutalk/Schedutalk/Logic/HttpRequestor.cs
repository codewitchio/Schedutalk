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

        public string getJSONAsString(Func<string, HttpRequestMessage> requestTask, string placeName)
        {
            Task<string> task = getHttpRequestAsString(requestTask, placeName);

            task.Wait();
            //Format string
            string replacement = task.Result;
            if (0 == replacement[0].CompareTo('[')) replacement = replacement.Substring(1);
            if (0 == replacement[replacement.Length - 1].CompareTo(']')) replacement = replacement.Remove(replacement.Length - 1);

            return replacement;
        }
    }
}
