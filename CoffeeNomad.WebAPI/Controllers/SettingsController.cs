using CoffeeNomad.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeNomad.WebAPI.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class SettingsController : Controller
    {
        [HttpGet("Index")]
        public async Task<IActionResult> Index() => View("index");

    }
}
