using System.Text.Json;
using Labb1_PokeAPI.Models;

namespace Labb1_PokeAPI.Services
{
    public class PokemonService : IPokemonService
    {
        private readonly HttpClient _httpClient;

        public PokemonService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<PokemonListItem>> GetPokemonListsAsync(int limit = 20)
        {
            var response = await _httpClient.GetAsync($"pokemon?limit={limit}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PokemonListResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result?.Results ?? new List<PokemonListItem>();
        }

        public async Task<PokemonDetails?> GetPokemonDetailAsync(string nameOrId)
        {
            var response = await _httpClient.GetAsync($"pokemon/{nameOrId}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PokemonDetails>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            return result;
        }



    }
}
