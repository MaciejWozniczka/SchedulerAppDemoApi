using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Scheduler.Api.Data;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Scheduler.Api.Authentication
{
    public class AuthorizationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly DataContext _db;

        public AuthorizationController(IConfiguration configuration, UserManager<User> userManager, SignInManager<User> signInManager, DataContext db)
        {
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
            _db = db;
        }
        [SwaggerResponse(StatusCodes.Status200OK, Type = typeof(AuthenticationResponse))]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] LoginModel authenticationRequestBody)
        {
            // Step1: Walidacja danych logowania
            var user = await _db.Users
                .Where(u => u.UserName == authenticationRequestBody.UserName)
                .FirstOrDefaultAsync();

            if (user == null)
                return Unauthorized();

            var validationResult = await _signInManager.CheckPasswordSignInAsync(user, authenticationRequestBody.Password, false);

            if (!validationResult.Succeeded)
            {
                return Forbid();
            }

            // Step2: Tworzenie kluczy tokenu
            var securityKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            // Step3: Tworzenie Claimów
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id)
            };

            var roles = await _userManager.GetRolesAsync(user);
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));

            // Step4: Tworzenie tokenu
            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(new AuthenticationResponse() { Token = tokenToReturn, ValidFrom = DateTime.UtcNow, ValidTo = DateTime.UtcNow.AddHours(1) });
        }
    }
}