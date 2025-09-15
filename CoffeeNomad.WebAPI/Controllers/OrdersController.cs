using Microsoft.AspNetCore.Mvc;

namespace CoffeeNomad.WebAPI.Controllers
{
    [Controller]
    [Route("[controller]")]
    public class OrdersController : Controller
    {
        [HttpGet("Index")]
        public async Task<IActionResult> Index() => View("index");
    }
}
