using Microsoft.AspNetCore.Mvc;
using Labb1_PokeAPI.Models;
using Labb1_PokeAPI.Services;

namespace Labb1_PokeAPI.Controllers
{
    public class PokemonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
