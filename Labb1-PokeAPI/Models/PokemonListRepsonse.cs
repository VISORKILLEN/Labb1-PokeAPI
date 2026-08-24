using System.Text.Json.Serialization;

namespace Labb1_PokeAPI.Models
{

    // This class represents the response from the Pokemon API when fetching a list of Pokemon.
    public class PokemonListRepsonse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonResult> Results { get; set; } = new();
    }

    // This class represents an individual Pokemon result in the list response.
    public class PokemonResult
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
