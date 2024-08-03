using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BLL
{
    public class UserAPI
    {
        public LoginPostReponse sendLoginContent(string email, string password)
        {
            LoginPostContent content = new LoginPostContent();
            content.email = email;
            content.password = password;
            HttpClientHandler handler = new HttpClientHandler()
            {
                UseDefaultCredentials = true
            };

            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:3000/api/login");

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
                var result = JsonSerializer.Deserialize<LoginPostReponse>(responseString, options);
                return result;
            }
            else
            {
                return null;
            }
        }
    }
}
