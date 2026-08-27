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

        // Get a list of Pokemon with a specified limit
        public async Task<PokemonListResult> GetPokemonListsAsync(int offset = 0,int limit = 20)
        {
            var response = await _httpClient.GetAsync($"pokemon?offset={offset}&limit={limit}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<PokemonListResponse>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return new PokemonListResult
            {
                Items = result?.Results ?? new List<PokemonListItem>(),
                Offset = offset,
                Limit = limit,
                TotalCount = result?.Count ?? 0
            };
        }

        // Get details of a specific Pokemon by name or ID
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
