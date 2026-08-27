using System.Text.Json.Serialization;

namespace Labb1_PokeAPI.Models
{

    // This class represents the response from the Pokemon API when fetching a list of Pokemon.
    public class PokemonListResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<PokemonListItem> Results { get; set; } = new();
    }

    // This class represents an individual Pokemon result in the list response.
    public class PokemonListItem
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }
        [JsonPropertyName("url")]
        public string? Url { get; set; }

        public string Id
        {
            get
            {
                var trimmed = Url?.TrimEnd('/') ?? "";
                return trimmed.Substring(trimmed.LastIndexOf('/') + 1);
            }
        }
    }
}
