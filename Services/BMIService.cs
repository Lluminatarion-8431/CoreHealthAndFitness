using Core_Health_and_Fitness.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core_Health_and_Fitness.Services
{
    public class BMIService
    {
        public BMIService()
        {

        }

        public string GetBMIURL(Client client)
        {
            return $"https://bmi.p.rapidapi.com/" + PrivateAPIKey.BMIAPIKey;
        }

        public async Task<Client> GetBMI(Client client)
        {
            string apiUrl = GetBMIURL(client);

            using (HttpClient clients = new HttpClient())
            {
                clients.BaseAddress = new Uri(apiUrl);
                clients.DefaultRequestHeaders.Accept.Clear();
                clients.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await clients.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
                    JToken results = jsonResults["bmi"][1];
                    //JToken location = results["geometry"]["location"];
                }
            }
            return client;
        }
    }
}
