
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;

namespace BLL
{
    public class TranslateAPI
    {
        public TranslatePostResponse sendTranslateContent(string q, string source = "auto", string target = "en", string format = "text", int alternatives = 2)
        {
            TranslatePostContent content = new TranslatePostContent();
            content.Q = q;
            content.Source = source;
            content.Target = target;
            content.Format = format;
            content.Alternatives = alternatives;
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://127.0.0.1:8080/translate");

            var json = JsonSerializer.Serialize(content);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = client.PostAsync(client.BaseAddress, data).Result;
            var responseString = response.Content.ReadAsStringAsync().Result;
            TranslatePostResponse result = JsonSerializer.Deserialize<TranslatePostResponse>(responseString);
            return result;
        }
    }
}
