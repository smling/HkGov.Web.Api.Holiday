using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace HkGov.Web.Api.Holiday.Http
{
    /// <summary>
    /// HTTP request class to resolve HTTP request and response.
    /// </summary>
    public class HttpRequester
    {
        private static readonly HttpClient _client = new HttpClient();
        /// <summary>
        /// Send HTTP GET request to target URL.
        /// </summary>
        /// <param name="url">Target URL.</param>
        /// <returns>HTTP response in string format</returns>
        public async Task<string> GetResponseAsStringAsync(string url)
        {
            string result = String.Empty;
            using (HttpResponseMessage response = await _client.GetAsync(url))
            {
                if (!response.IsSuccessStatusCode)
                    throw new HttpRequestException($"Error occurred when sending HTTP GET to target URL {url}.");
                result = await response.Content.ReadAsStringAsync();

            }
            return result;
        }
    }
}
