using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;

namespace BLL
{
    public class SaveFavoriteAPI
    {
        public async Task<List<FavoriteResponse>> SaveFavoriteContent(string originalword, string translatedword, string fromlanguage, string tolanguage, int uid)
        {
            FavoriteResponse content = new FavoriteResponse();
            content.originalword = originalword;
            content.translatedword = translatedword;
            content.fromlanguage = fromlanguage;
            content.tolanguage = tolanguage;
            //content.timesave = timesave;
            content.uid = uid;

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/savefavorite");

            var json = JsonSerializer.Serialize(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(client.BaseAddress, data).Result;

            if (response.IsSuccessStatusCode)
            {
                string responseString = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                };
                var result = JsonSerializer.Deserialize<List<FavoriteResponse>>(responseString, options);
                return result;
            }
            else
            {
                throw new Exception("Error: " + response.ReasonPhrase);
            }

        }
    }
}
