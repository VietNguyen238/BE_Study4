using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using be_study4.Interfaces;
using be_study4.Models;
using Microsoft.IdentityModel.Tokens;

namespace be_study4.Service
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _config;
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration config)
        {
            _config = config;
            // Ensure the key is at least 32 bytes (256 bits) long
            var keyBytes = Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]);
            if (keyBytes.Length < 32)
            {
                // If key is too short, pad it to 32 bytes
                Array.Resize(ref keyBytes, 32);
            }
            _key = new SymmetricSecurityKey(keyBytes);
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Name, user.Name)
            };

            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds,
                Issuer = _config["JWT:Issuer"],
                Audience = _config["JWT:Audience"]
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}