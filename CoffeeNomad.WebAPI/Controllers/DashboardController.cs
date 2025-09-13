using AutoMapper;
using CoffeeNomad.Contracts.DTOs;
using CoffeeNomad.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeNomad.WebAPI.Controllers
{
    [Route("[controller]")]
    [Controller]
    public class DashboardController : Controller
    {
        private readonly OrderService _orderService;
        private readonly ProductMenuService _productMenuService;
        private readonly UserService _userService;
        private readonly IMapper _mapper;

        public DashboardController(
            OrderService orderService,
            ProductMenuService productMenuService,
            UserService userService,
            IMapper mapper)
        {
            _orderService = orderService;
            _productMenuService = productMenuService;
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Index() => View("dashboard");

        [HttpGet("totalOrders")]
        public async Task<IActionResult> GetOrders() 
        {
            var result = await _orderService.GetOrders();

            return Ok(result.Count);
        }

        [HttpGet("totalProducts")]
        public async Task<IActionResult> GetProducts() 
        {
            var result = await _productMenuService.GetAll();
            
            return Ok(result.Count);
        }

        [HttpGet("totalCostumer")]
        public async Task<IActionResult> GetCostumer() 
        {
            var result = await _userService.GetAll();

            return Ok(result.Count);
        }

        [HttpGet("latestOrders")]
        public async Task<IActionResult> GetLatestOrders() 
        {
            var result = await _orderService.GetOrders();

            return Ok(result);
        }

        [HttpGet("bestSeller")]
        public async Task<IActionResult> GetSellerItems() 
        {
            var allProducts = await _productMenuService.GetAll();

            var result = _mapper.Map<IEnumerable<CartItemsDTO>>(allProducts);

            return Ok(result);
        }
    }
}
