using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BLL
{
    public class HistoryAPI
    {
        public async Task<List<HistoryReponse>> LoadHistoryContent(int uid)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/gethistory?uid=" + uid);

            var response = await client.GetAsync(client.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                };
                var result = JsonSerializer.Deserialize<List<HistoryReponse>>(responseString, options);

                return result;
                
            }
            else
            {
                throw new Exception("Error: " + response.ReasonPhrase);
            }
        }



    }
}
