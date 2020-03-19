using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PokemonLib
{
    internal class SimpleHttp
    {
        public static async Task<T> Get<T>(string url, string queryString = null)
        {
            if (queryString != null)
                url += "?" + Base64Encode(queryString);

            var request = WebRequest.Create(url);
            string json = await ReadJson(request);
            var result = JsonConvert.DeserializeObject<T>(json);

            return result;
        }

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        private static async Task<string> ReadJson(WebRequest webRequest)
        {
            string json;
            using (var response = await webRequest.GetResponseAsync())
            using (var reader = new StreamReader(response.GetResponseStream()))
                json = await reader.ReadToEndAsync();

            return json;
        }
    }
}
