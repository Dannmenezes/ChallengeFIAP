using MoneyChallenge.Data;
using MoneyChallenge.Models;
using Newtonsoft.Json;

namespace MoneyChallenge.Services
{
    public class InterpolService : IInterpolService
    {
        private readonly HttpClient _httpClient;
        private readonly FBIContext _context;

        public InterpolService(HttpClient httpClient, FBIContext fBIContext)
        {
            _httpClient = httpClient;
            _context = fBIContext;
        }

        public async Task<List<InterpolPerson>> GetWantedPeopleList()
        {
            var response = await _httpClient.GetAsync("https://ws-public.interpol.int/notices/v1/red");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<InterpolResponse>(content);

                return value.Notices;
            }

            return null;
        }

        public async Task<InterpolPerson> GetWantedPeopleById(int id)
        {
            var wanted = await _context.Interpol.FindAsync(id);

            if (wanted == null)
            {
                return null;
            }

            return wanted;
        }
    }
}
