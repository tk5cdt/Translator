﻿using System;
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
                Console.WriteLine(responseString); // Kiểm tra chuỗi JSON nhận được

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString | JsonNumberHandling.WriteAsString
                };

                try
                {
                    var result = JsonSerializer.Deserialize<List<HistoryReponse>>(responseString, options);
                    return result;
                }
                catch (JsonException ex)
                {
                    Console.WriteLine("JSON Deserialization error: " + ex.Message);
                    throw;
                }
            }
            else
            {
                throw new Exception("Error: " + response.ReasonPhrase);
            }
        }


        public async Task<List<HistoryReponse>> DeleteHistoryContent(int wordid, int uid)
        {
            HistoryReponse content = new HistoryReponse();
            content.wordid = wordid;
            content.uid = uid;
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/deletehistory");

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
                var result = JsonSerializer.Deserialize<List<HistoryReponse>>(responseString, options);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<HistoryReponse>> DeleteAllHistory(int uid)
        {
            HistoryReponse content = new HistoryReponse();
            content.uid = uid;
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/deleteallhistory");

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
                var result = JsonSerializer.Deserialize<List<HistoryReponse>>(responseString, options);
                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<List<HistoryReponse>> UpdateHistory(bool isfavorite, int wordid, int uid)
        {
            HistoryReponse content = new HistoryReponse();
            content.isfavorite = isfavorite;
            content.wordid = wordid;
            content.uid = uid;
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/updatehistory");

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
                var result = JsonSerializer.Deserialize<List<HistoryReponse>>(responseString, options);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
