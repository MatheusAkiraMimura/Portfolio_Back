using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portfolio.Interfaces;
using Portfolio.Models;
using Portfolio.Models.ViewModel;
using System.Threading.Tasks;
using Portfolio.Services;

[ApiController]
[Route("api/[controller]")]

public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // POST: api/Users/register
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationViewModel userRegistrationViewModel)
    {
        var user = new User
        {
            Nome = userRegistrationViewModel.Nome,
            Email = userRegistrationViewModel.Email,
            Senha = userRegistrationViewModel.Senha // A senha será criptografada no UserService
        };

        var createdUser = await _userService.RegisterUser(user);

        var userResponseViewModel = new UserResponseViewModel
        {
            Id = createdUser.Id,
            Nome = createdUser.Nome,
            Email = createdUser.Email
        };

        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, userResponseViewModel);
       
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserById(id);
        if (user == null)
        {
            return NotFound();
        }

        var userResponseViewModel = new UserResponseViewModel
        {
            Id = user.Id,
            Nome = user.Nome,
            Email = user.Email
        };

        return Ok(userResponseViewModel);
    }

    // POST: api/Users/Login
    [HttpPost("Login")]
    public async Task<IActionResult> Auth([FromBody] UserLoginViewModel loginModel)
    {
        {
            var user = await _userService.Authenticate(loginModel.Email, loginModel.Senha);
            if (user == null)
            {
                return BadRequest("username or password invalid");
            }

            var token = TokenService.GenerateToken(user);
            return Ok(token);
        }
    }
}
