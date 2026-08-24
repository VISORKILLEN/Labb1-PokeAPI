using System.Text.Json.Serialization;

namespace Labb1_PokeAPI.Models
{
    public class PokemonListRepsonse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonResult> Results { get; set; } = new();
    }

    public class PokemonResult
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
