using Application.SchoolManagement.DTO;
using Application.SchoolManagement.Interface.IUserOperation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.SchoolManagement2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAllUserOperation _userService;

        public UsersController(IAllUserOperation userService)
        {
            _userService = userService;
        }

        // POST: api/users/register
        [HttpPost("register")]
        [AllowAnonymous] // Anyone can register
        public async Task<IActionResult> Register([FromBody] CreateUserDto createUserDto)
        {
            var response = await _userService.RegisterAsync(createUserDto);
            if (!response.Succeeded)
                return BadRequest(new { message = response.Message });

            return Ok(new { message = response.Message });
        }

        // POST: api/users/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var response = await _userService.LoginAsync(loginDto);
            if (!response.Succeeded)
                return Unauthorized(new { message = response.Message });

            return Ok(response.Data);
        }

        // GET: api/users
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            if (!User.IsInRole("Admin"))
                return Forbid("🚫 لا يمكنك عرض المستخدمين، هذه الصفحة للمسؤول فقط");

            var response = await _userService.GetAllUsersAsync();
            if (!response.Succeeded)
                return StatusCode(500, new { message = response.Message });

            return Ok(response.Data);
        }


        // GET: api/users/{userId}
        [HttpGet("{userId}")]
        [Authorize]
        public async Task<IActionResult> GetUserDetail(string userId)
        {
            var response = await _userService.GetUserDetailAsync(userId);
            if (!response.Succeeded)
                return NotFound(new { message = response.Message });

            return Ok(response.Data);
        }
    }
}
