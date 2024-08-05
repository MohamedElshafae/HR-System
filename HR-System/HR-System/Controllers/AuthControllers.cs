using HR_System.Core.DTOs;
using HR_System.Core.Models;
using HR_System.Core.ServicesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_System.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AuthControllers : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IAuthService _authService;


        public AuthControllers(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IAuthService authService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _authService = authService;
        }


        [HttpGet("secure-data")]
        [Authorize]
        public IActionResult GetSecureData()
        {
            return Ok("u got me");
        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var user = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = registerDTO.UserName,
                Email = registerDTO.Email,
                FirstName = registerDTO.FirstName,
                LastName = registerDTO.LastName,
                EmployeeId = registerDTO.employeeId
            };

            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if (!result.Succeeded)
            {
                return BadRequest(new { Message = "Error" });
            }
            return Ok(new { Message = "User register succesfully" });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(loginDTO.userName);

            if (user == null)
                return Unauthorized(new { Message = "Invalid userName" });

            if (!await _userManager.CheckPasswordAsync(user, loginDTO.Password))
                return Unauthorized(new { Message = "Invalid Password"});
            var token = await _authService.GenerateJwtToken(user);
            return Ok(new { token });
        }
    }
}
