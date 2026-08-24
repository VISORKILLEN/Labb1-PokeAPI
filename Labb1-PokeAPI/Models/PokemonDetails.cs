using System.Text.Json.Serialization;

namespace Labb1_PokeAPI.Models
{

    // This class represents the response from the Pokemon API when fetching details of a specific Pokemon.
    public class PokemonDetails
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("height")]
        public int Height { get; set; }

        [JsonPropertyName("weight")]
        public int Weight { get; set; }

        [JsonPropertyName("sprites")]
        public PokemonSprites Sprites { get; set; } = new();

        [JsonPropertyName("types")]
        public List<PokemonTypeSlot> Types { get; set; } = new();

        [JsonPropertyName("stats")]
        public List<PokemonStat> Stats { get; set; } = new();
    }

    // This class represents a Pokemon's type in the API response.
    public class PokemonSprites
    {
        [JsonPropertyName("front_default")]
        public string? FrontDefault { get; set; }
    }

    // This class represents a Pokemon's stat in the API response.
    public class PokemonTypeSlot
    {
        [JsonPropertyName("slot")]
        public int Slot { get; set; }
        [JsonPropertyName("type")]
        public PokemonType Type { get; set; } = new();
    }
}
