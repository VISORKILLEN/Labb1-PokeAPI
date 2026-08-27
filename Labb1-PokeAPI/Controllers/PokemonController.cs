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

        public async Task<IActionResult> Index(int offset = 0)
        {
            try
            {
                var result = await _pokemonService.GetPokemonListsAsync(offset);
                return View(result);
            }
            catch (HttpRequestException)
            {
                ViewBag.ErrorMessage = "Kunde inte hämta Pokémon-lista.just nu, Prova igen senare";
                return View("ServiceUnavailable");
            }
        }

        public async Task<IActionResult> Details(string nameOrId)
        {
            // Check if the nameOrId parameter is null or empty
            try
            {
                var pokemon = await _pokemonService.GetPokemonDetailAsync(nameOrId);
                if (pokemon == null)
                {
                    TempData["ErrorMessage"] = "Pokémon hittades inte.";
                    return RedirectToAction("Index");
                }
                return View(pokemon);
            }
            // Catch any HttpRequestException that occurs during the API call
            catch (HttpRequestException)
            {
                TempData["ErrorMessage"] = "Finns inga Pokémons i ditt område. Försök igen senare.";
                return RedirectToAction("Index");
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
