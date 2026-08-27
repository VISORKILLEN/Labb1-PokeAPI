namespace Labb1_PokeAPI.Models
{

    // This class represents the result of a paginated list of Pokemon from the API.
    public class PokemonListResult
    {
        public List<PokemonListItem> Items { get; set; } = new();
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int TotalCount { get; set; }

        public bool HasNext => Offset + Limit < TotalCount;
        public bool HasPrevious => Offset > 0;

        public int NextOffset => Offset + Limit;
        public int PreviousOffset => Math.Max(0, Offset - Limit);

    }
}
