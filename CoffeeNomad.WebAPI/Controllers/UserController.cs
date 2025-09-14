using CoffeeNomad.Contracts.Contracts;
using CoffeeNomad.DataBase.Entities;
using CoffeeNomad.Services;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeNomad.WebAPI.Controllers
{
    [Controller]
    [Route("[Controller]")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("login")]
        public async Task<IActionResult> GetLogin() => View("login");

        [HttpGet("signup")]
        public async Task<IActionResult> GetRegister() => View("signup");

        [HttpGet("forgot-password")]
        public async Task<IActionResult> GetForgot() => View("forgot");

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterContract user)
        {
            //var email = _userService.GetByEmail(user.Email);
            //if (email.Result != null)
            //{
            //    return Ok("Вы уже зарегистрированы под этой почтой");
            //}

            await _userService.CreateUserProfile(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginContract user)
        {
            var result = await _userService.Login(user);
            if (result == null)
            {
                return Ok("Неверный пароль или вы не зарегистрированы");
            }

            Response.Cookies.Append("ass-token", result);

            return Ok(new { result });
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Delete("ass-token");
            return Redirect("/home/index");
        }

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] User user)
        {
            var token = await _userService.GetByEmail(user.Email);
            if (token == null)
            {
                return Ok("Вы не зарегистрированы");
            }
            return Ok($"Ваш пароль {token.Password}");
        }
    }
}
