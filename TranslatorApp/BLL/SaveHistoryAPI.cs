﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http;

namespace BLL
{
    public class SaveHistoryAPI
    {
        public async Task<List<HistoryReponse>> SaveHistoryContent(string originalword, string translatedword, string fromlanguage, string tolanguage, DateTime timesave, int uid, bool isfavorite)
        {
            HistoryReponse content = new HistoryReponse();
            content.originalword = originalword;
            content.translatedword = translatedword;
            content.fromlanguage = fromlanguage;
            content.tolanguage = tolanguage;
            content.timesave = timesave;
            content.uid = uid;
            content.isfavorite = isfavorite;

            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/savehistory");

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
