using CoffeeNomad.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeNomad.WebAPI.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class MenuController : Controller
    {
        private readonly ProductMenuService _menuService;

        public MenuController(ProductMenuService menuService)
        {
            _menuService = menuService;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index() => View("index");

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCards() 
        {
            var result = await _menuService.GetAll();

            return Ok(result);
        }
    }
}
