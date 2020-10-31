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
    public class GeocodingService
    {
        public GeocodingService()
        {

        }
        public string GetGeocodingURL(PersonalTrainer personalTrainer)
        {
            return $"https://maps.googleapis.com/maps/api/geocode/json?address={personalTrainer.AddressLine}+{personalTrainer.State}+{personalTrainer.ZipCode}&key=" + PrivateAPIKey.GoogleAPIKey; /*{API Key}&callback=initMap*/
        }

        public async Task<PersonalTrainer> GetGeocoding(PersonalTrainer personalTrainer)
        {
            string apiUrl = GetGeocodingURL(personalTrainer);

            using (HttpClient trainer = new HttpClient())
            {
                trainer.BaseAddress = new Uri(apiUrl);
                trainer.DefaultRequestHeaders.Accept.Clear();
                trainer.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await trainer.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string data = await response.Content.ReadAsStringAsync();
                    JObject jsonResults = JsonConvert.DeserializeObject<JObject>(data);
                    JToken results = jsonResults["results"][0];
                    JToken location = results["geometry"]["location"];

                    personalTrainer.Lat = (double)location["lat"];
                    personalTrainer.Long = (double)location["long"];
                }
            }
            return personalTrainer;
        }
    }
}
