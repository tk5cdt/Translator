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
    public class FavoriteAPI
    {
        public async Task<List<FavoriteResponse>> LoadFavoriteContent(int uid)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/getfavorite?uid=" + uid);

            var response = await client.GetAsync(client.BaseAddress);

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

        public async Task<List<FavoriteResponse>> DeleteFavoriteContent(int wordid, int uid)
        {
            FavoriteContent content = new FavoriteContent();
            content.wordid = wordid;
            content.uid = uid;
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/deletefavorite");

            var json = JsonSerializer.Serialize(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(client.BaseAddress, data).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseString = response.Content.ReadAsStringAsync().Result;
                var options = new JsonSerializerOptions()
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString
                };
                var result = JsonSerializer.Deserialize<List<FavoriteResponse>>(responseString, options);
                return result;
            }
            else
            {
                return null;
            }
        }

    }
}
