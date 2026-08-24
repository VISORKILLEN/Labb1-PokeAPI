using Labb1_PokeAPI.Models;

namespace Labb1_PokeAPI.Services
{
    public interface IPokemonService
    {
        Task<List<PokemonListItem>> GetPokemonListsAsync(int limit = 20);
        Task<PokemonDetails?> GetPokemonDetailAsync(string nameOrId);

    }
}
