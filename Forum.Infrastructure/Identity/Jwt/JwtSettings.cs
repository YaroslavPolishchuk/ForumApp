using Forum.Infrastructure.Identity.Token;

namespace Forum.Infrastructure.Identity.Jwt
{
    public class JwtSettings : IJwtSettings
    {
        public const string SectionName = "JwtSettings";
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Private { get; set; } = string.Empty;
        public string Public { get; set; } = string.Empty;
        public int ExpireMinutes { get; set; }        
    }
}
