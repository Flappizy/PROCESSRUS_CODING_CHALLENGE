using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;


namespace PROCESSRUS_CODING_CHALLENGE.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    public AuthController(UserManager<User> userManager, IJWTHandler jwtHandler)
    {
        _userManager = userManager;
        _jwtHandler = jwtHandler;
    }

    [HttpPost("signup")]
    public async Task<IActionResult> RegisterUser([FromBody] SignupDto request)
    {
        if (request == null || !ModelState.IsValid)
            return BadRequest();

        var user = CreateUser(request);
        var result = await _userManager.CreateAsync(user, request.Password);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);

            return BadRequest(new SignupResponseDto { Errors = errors });
        }

        await _userManager.AddToRoleAsync(user, request.AccountType.ToString());
        return StatusCode(201);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var user = await _userManager.FindByNameAsync(request.Email);
        if (user == null)
            return BadRequest("Invalid Request");

        
        if (!await _userManager.CheckPasswordAsync(user, request.Password))
            return Unauthorized(new LoginResponseDto { ErrorMessage = "Invalid Authentication" });

        var token = _jwtHandler.GenerateToken(user);

        return Ok(new LoginResponseDto { IsAuthSuccessful = true, Token = token });
    }

    private static User CreateUser(SignupDto signupDto)
    {
        User user = signupDto.AccountType == AccountType.Admin ?
            new Admin
            {
                FirstName = signupDto.FirstName,
                LastName = signupDto.LastName,
                UserName = signupDto.Email,
                Company = signupDto.Company,
                Email = signupDto.Email,
                AccountType = signupDto.AccountType
            } : signupDto.AccountType == AccountType.BackOffice ?
            new BackOffice
            {
                FirstName = signupDto.FirstName,
                LastName = signupDto.LastName,
                UserName = signupDto.Email,
                Company = signupDto.Company,
                Email = signupDto.Email,
                AccountType = signupDto.AccountType
            } :
            new FrontOffice
            {
                FirstName = signupDto.FirstName,
                LastName = signupDto.LastName,
                UserName = signupDto.Email,
                Company = signupDto.Company,
                Email = signupDto.Email,
                AccountType = signupDto.AccountType
            };

        return user;
    }

    private readonly UserManager<User> _userManager;
    private readonly IJWTHandler _jwtHandler;
}
