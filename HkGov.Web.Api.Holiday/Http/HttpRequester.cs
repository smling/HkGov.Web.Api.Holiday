using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HkGov.Web.Api.Holiday.Http
{
    public class HttpRequester
    {
        private static readonly HttpClient client = new HttpClient();
        
        public async Task<string> GetAsync(string url)
        {
            string result = String.Empty;
            using (HttpResponseMessage response = await client.GetAsync(url)) {
                if (response.IsSuccessStatusCode) {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return result;
        }
    }
}
