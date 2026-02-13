using KDWalks.API.Models.DTO;
using KDWalks.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace KDWalks.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly ITokenHandler tokenHandler;

        public AuthController(IUserRepository userRepository,
                              ITokenHandler tokenHandler)
        {
            this.userRepository = userRepository;
            this.tokenHandler = tokenHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await userRepository
                .AuthenticateAsync(loginRequest.Username, loginRequest.Password);

            if (user == null)
                return Unauthorized("Invalid username or password");

            var token = await tokenHandler.CreateTokenAsync(user);

            return Ok(token);
        }
    }
}
