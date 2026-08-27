using Labb1_PokeAPI.Models;

namespace Labb1_PokeAPI.Services
{
    public interface IPokemonService
    {
        Task<PokemonListResult> GetPokemonListsAsync(int offset = 0, int limit = 20);
        Task<PokemonDetails?> GetPokemonDetailAsync(string nameOrId);

    }
}
