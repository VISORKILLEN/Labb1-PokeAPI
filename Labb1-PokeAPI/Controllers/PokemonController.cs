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

        public async Task<IActionResult> Index()
        {
            var pokemonList = await _pokemonService.GetPokemonListsAsync();
            return View(pokemonList);
        }

        public async Task<IActionResult> Details(string nameOrId)
        {
            try
            {
                var pokemon = await _pokemonService.GetPokemonDetailAsync(nameOrId);
                if (pokemon == null)
                {
                    return NotFound();
                }
                return View(pokemon);
            }
            catch (HttpRequestException)
            {
                ViewBag.ErrorMessage = "Finns inga Pokémons i ditt område. Försök igen senare.";
                return View("ServiceUnavailable");
            }
        }

        public IActionResult Search(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details", new { nameOrId = query.Trim().ToLower() });
        }
    }
}
