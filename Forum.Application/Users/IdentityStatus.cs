using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Users
{
    public enum IdentityStatus
    {
        Success,
        UserNotFound,
        InvalidPassword,
        UserAlreadyExists,
        NameAlreadyInUse
    }
}
