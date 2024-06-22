using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tejedor.Infrastructure.DTO.AuthDTO;
using Tejedor.Infrastructure.Entity;
using Tejedor.Infrastructure.Repository.Interfaces;


[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    // private readonly IConfiguration _configuration;

    private readonly string _jwtSecret = "YourVeryLongAndSecureSecretKey12345";
    private readonly int _jwtLifespan = 24 * 60; // En minutos

    public AuthController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginDTO userCredentials)
    {
        try
        {
            var user = await _userRepository.LoginUser(
                userCredentials.UserName, userCredentials.UserPassword
                );

            if (user == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            // Aquí puedes generar el token JWT y devolverlo como parte de la respuesta
            var token = GenerateJwtToken(user);

            return Ok(new { token });
        }
        catch
        {
            return StatusCode(500, new { message = "Internal server error" });
        }
    }

    private string GenerateJwtToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSecret);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
        };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(_jwtLifespan),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }

    [HttpPost("register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterDTO userInfo)
    {
        try
        {
            var newUser = await _userRepository.RegisterUser(
                    userInfo.UserName, userInfo.UserPassword, userInfo.UserEmail,
                    userInfo.Address, userInfo.BillingAddress, userInfo.Phone
                    );

            if (newUser == null)
            {
                return Unauthorized(new { message = "Invalid username or password" });
            };

            var userCredentials = (LoginDTO)newUser;
            var logged = await LoginUser(userCredentials);


            return logged;
        }
        catch
        {
            return StatusCode(500, new { message = "Internal server error" });
        }
    }
}
