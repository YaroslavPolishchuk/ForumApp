using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure.Identity.Token
{
    public interface IJwtUtils
    {
        string GenerateToken(int userId, string userName, string role);
        List<string> ValidateToken(string token);
    }
}
