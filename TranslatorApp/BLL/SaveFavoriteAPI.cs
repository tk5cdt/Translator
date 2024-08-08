using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Web.UI.Design;

namespace BLL
{
    public class SaveFavoriteAPI
    {
        public async Task<List<FavoriteResponse>> SaveFavoriteContent(string originalword, string translatedword, string fromlanguage, string tolanguage, DateTime timesave, int wordidhis, int uid)
        {
            FavoriteResponse content = new FavoriteResponse();
            content.originalword = originalword;
            content.translatedword = translatedword;
            content.fromlanguage = fromlanguage;
            content.tolanguage = tolanguage;
            content.timesave = timesave;
            content.wordidhis = wordidhis;
            content.uid = uid;


            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/savefavorite");

            var json = JsonSerializer.Serialize(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(client.BaseAddress, data);

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
        //public async Task<bool> SaveFavoriteContent(string originalword, string translatedword, string fromlanguage, string tolanguage, int wordidhis, int uid)
        //{
        //    var timesave = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

        //    FavoriteResponse content = new FavoriteResponse();
        //    content.originalword = originalword;
        //    content.translatedword = translatedword;
        //    content.fromlanguage = fromlanguage;
        //    content.tolanguage = tolanguage;
        //    content.timesave = Convert.ToDateTime(timesave);
        //    content.wordidhis = wordidhis;
        //    content.uid = uid;

        //    HttpClientHandler handler = new HttpClientHandler
        //    {
        //        UseDefaultCredentials = true
        //    };

        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("http://localhost:3000/api/savefavorite");

        //    var json = JsonSerializer.Serialize(content);
        //    var data = new StringContent(json, Encoding.UTF8, "application/json");

        //    var response = await client.PostAsync(client.BaseAddress, data);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string responseString = await response.Content.ReadAsStringAsync();
        //        var result = JsonSerializer.Deserialize<Dictionary<string, object>>(responseString);

        //        if (result.ContainsKey("success") && (bool)result["success"])
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            throw new Exception("Failed to save favorite.");
        //        }
        //    }
        //    else
        //    {
        //        throw new Exception("Error: " + response.ReasonPhrase);
        //    }
        //}

    }
}
