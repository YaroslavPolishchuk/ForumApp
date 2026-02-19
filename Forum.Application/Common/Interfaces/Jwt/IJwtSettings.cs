using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Identity.Token
{
    public interface IJwtSettings
    {
        string Issuer { get; set; }
        string Audience { get; set; }
        string Private { get; set; }
        string Public { get; set; }
        int ExpireMinutes { get; set; }
    }
}
