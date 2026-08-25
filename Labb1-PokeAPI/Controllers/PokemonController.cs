using Microsoft.AspNetCore.Mvc;
using Labb1_PokeAPI.Models;
using Labb1_PokeAPI.Services;

namespace Labb1_PokeAPI.Controllers
{
    public class PokemonController : Controller
    {
        private readonly IPokemonService _pokemonService;

        // Constructor that takes an IPokemonService as a dependency
        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        public IActionResult Index()
        {

            return View();
        }
    }
}
