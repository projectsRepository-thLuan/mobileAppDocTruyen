using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Webdoctruyen.Interface;
using Webdoctruyen.Models;
using Webdoctruyen.Models.ViewModels;

namespace Webdoctruyen.APIController
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public Taikhoan Login([FromBody] TaikhoanLogin user)
        {
            var authenticatedUser = _userService.Authenticate(user.Tentaikhoan, user.MatKhau);

            if (authenticatedUser == null)
                return null;

            return authenticatedUser;
        }

        private string GenerateJwtToken(Taikhoan user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes("diepthaibinh20dthe6dienhoadienkhanhkhanhhoa");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("tentaikhoan", user.Tentaikhoan),
                    new Claim("matkhau", user.Matkhau),
                    new Claim("phanquyen", user.Phanquyen.ToString()),
                    new Claim("email", user.Email)

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
