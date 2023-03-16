using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;


namespace Netflix_Data_Analysis.Core
{
    public class APIHandler
    {
        public async Task<string> GetApiResponseAsync(string apiUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        return responseContent;
                    }
                    else
                    {
                        return null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    return "Error connecting to API: " + ex.Message;
                }
            }
        }
    }
}
