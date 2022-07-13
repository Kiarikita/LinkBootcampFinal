using FinalProject.Core.DTOs;
using FinalProject.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AuthController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> CreateUser()
        {
            await _roleManager.CreateAsync(new() { Name = "admin" });
            await _roleManager.CreateAsync(new() { Name = "editor" });

            //var user = new AppUser() { UserName = "ahmet", City = "Ankara"};
            //await _userManager.CreateAsync(user, "Password12*");

            var editor = new AppUser() { UserName = "editor", City = "Antalya" };
            await _userManager.CreateAsync(editor, "Password12*");

            //await _userManager.AddToRoleAsync(user, "admin");
            await _userManager.AddToRoleAsync(editor, "editor");
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetToken(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);
            
            if (user == null)
            {
                return BadRequest("Username veya password yanlış.");
            }

            if (!await _userManager.CheckPasswordAsync(user, password))
            {
                return BadRequest("Username veya password yanlış.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var accessTokenExpiration = DateTime.Now.AddMinutes(60);
            //var refreshTokenExpiration = DateTime.Now.AddMinutes(360);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("asdfghjklşiasdfghjklşisdfghjklştopsecretkey1234***"));

            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new List<Claim>() { new Claim("city", user.City) };

            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            claims.Add(new Claim(JwtRegisteredClaimNames.Aud, "www.myapi.com"));

            userRoles.ToList().ForEach( x => 
            {
                claims.Add(new Claim(ClaimTypes.Role, x));
            });

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: "www.myapi.com",
                expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: claims,
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            return Ok(new 
            {
                AccessToken = token
                //RefreshToken = CreateRefreshToken(),
                //AccessTokenExpiration = accessTokenExpiration,
                //RefreshTokenExpiration = refreshTokenExpiration
            });

            
        }
    }
}
