
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Runtime.InteropServices;

namespace BLL
{
    public class TranslateAPI
    {
        public async Task<TranslatePostResponse> sendTranslateContent(string q, string source = "auto", string target = "en", string format = "text", int alternatives = 2)
        {
            TranslatePostContent content = new TranslatePostContent();
            content.q = q;
            content.source = source;
            content.target = target;
            content.format = format;
            content.alternatives = alternatives;
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("http://localhost:5000/translate");

            var json = JsonSerializer.Serialize(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(client.BaseAddress, data);
            var responseString = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString
            };
            TranslatePostResponse result = JsonSerializer.Deserialize<TranslatePostResponse>(responseString, options);
            return result;
        }

        public List<Languages> GetLanguages()
        {
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };
            var client = new HttpClient(handler);
            client.BaseAddress = new Uri("https://libretranslate.com/languages");
            var response = client.GetAsync(client.BaseAddress).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            var options = new JsonSerializerOptions()
            {
                NumberHandling = JsonNumberHandling.AllowReadingFromString |
                JsonNumberHandling.WriteAsString
            };
            List<Languages> result = JsonSerializer.Deserialize<List<Languages>>(responseString, options);
            return result;
        }
    }



}
