using ChallengeIdwall.Interfaces;
using ChallengeIdwall.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ChallengeIdwall.Services
{
    public class WantedService : ControllerBase, IWantedService
    {
        private readonly HttpClient _httpClient;

        public WantedService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Fbi>> GetWantedPersonAsync()
        {
            var response = await _httpClient.GetAsync("https://api.fbi.gov/wanted/v1/list");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<FBIWantedResponse>(content);

                // Assumindo que a resposta da API tem uma propriedade "items" contendo a lista de pessoas procuradas
                return data.items;
            }

            return null;
        }

        public async Task<List<Interpol>> GetInterpolWanted()
        {
            var response = await _httpClient.GetAsync("https://ws-public.interpol.int/notices/v1/red");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<InterpolWantedResponse>(content);

                // Assumindo que a resposta da API tem uma propriedade "items" contendo a lista de pessoas procuradas
                return data.items;
            }

            return null;
        }
    }
}
