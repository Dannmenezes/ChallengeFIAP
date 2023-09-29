using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoneyChallenge.Data;
using MoneyChallenge.Interfaces;
using MoneyChallenge.Models;
using Newtonsoft.Json;

namespace MoneyChallenge.Services
{
    public class FBIService : ControllerBase, IFBIService
    {
        private readonly HttpClient _httpClient;
        private readonly FBIContext _context;

        public FBIService(HttpClient httpClient, FBIContext fBIContext)
        {
            _httpClient = httpClient;
            _context = fBIContext;
        }

        public async Task<List<FBIPerson>> GetWantedPeopleList()
        {
            var response = await _httpClient.GetAsync("https://api.fbi.gov/wanted/list");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<FBIResponse>(content);

                return value.Items;
            }

            return null;
        }

        public async Task<FBIPerson> GetWantedPeopleById(int id)
        {
            var wanted = await _context.FBI.FindAsync(id);

            if (wanted == null)
            {
                return null;
            }

            return wanted;
        }
    }
}
