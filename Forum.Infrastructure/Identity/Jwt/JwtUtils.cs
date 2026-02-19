using Forum.Infrastructure.Identity.Token;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace Forum.Infrastructure.Identity.Jwt
{
    public class JwtUtils : IJwtUtils
    {
        private readonly IConfiguration _configuration;
        private readonly RsaSecurityKey _privateKey;
        private readonly RsaSecurityKey _publicKey;
        IJwtSettings _tokenSettings;


        public JwtUtils(IJwtSettings tokenSettings)
        {
            _tokenSettings = tokenSettings;

            var _private = File.ReadAllText(_tokenSettings.Private);
            using var privRsa = RSA.Create();
            privRsa.ImportFromPem(_private);            
            _privateKey = new RsaSecurityKey(privRsa);

            var _public = File.ReadAllText(_tokenSettings.Public);
            using var pubRsa = RSA.Create();
            pubRsa.ImportFromPem(_public.ToCharArray());
            _publicKey = new RsaSecurityKey(pubRsa);
        }

        public string GenerateToken(int userId, string userName, string role)
        {
            var now = DateTime.UtcNow;

            var claims = new[]
            {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.UniqueName, userName),
            new Claim(ClaimTypes.Role, role),
            new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(now).ToUnixTimeSeconds().ToString(), ClaimValueTypes.Integer64)
            };

            var creds = new SigningCredentials(_privateKey, SecurityAlgorithms.RsaSha256);

            //var token = new JwtSecurityToken(
            //    issuer: _tokenSettings.Issuer,
            //    audience: _tokenSettings.Audience,
            //    claims: claims,
            //    expires: now.AddMinutes(_tokenSettings.ExpireMinutes),
            //    signingCredentials: creds
            //);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                Issuer = _tokenSettings.Issuer,
                Audience = _tokenSettings.Audience,
                SigningCredentials = creds
            };
            var handler= new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);            
            var jwtToken = handler.WriteToken(token);

            return null;
        }

        public List<string> ValidateToken(string token)
        {
            try
            {
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    RequireSignedTokens = true,
                    IssuerSigningKey = _publicKey
                };

                var handler = new JwtSecurityTokenHandler();
                handler.ValidateToken(token, validationParameters, out _);
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        private string ComputeKeyId(RSA rsa)
        {
            // Удобный, детерминированный KeyId — sha256 публичного ключа в base64url (можно и другой)
            var parameters = rsa.ExportParameters(false);
            using var ms = new MemoryStream();
            using var bw = new BinaryWriter(ms);
            bw.Write(parameters.Modulus ?? Array.Empty<byte>());
            bw.Write(parameters.Exponent ?? Array.Empty<byte>());
            bw.Flush();
            var pubBytes = ms.ToArray();

            using var sha = SHA256.Create();
            var hash = sha.ComputeHash(pubBytes);
            return Base64UrlEncoder.Encode(hash);
        }
    }
}
