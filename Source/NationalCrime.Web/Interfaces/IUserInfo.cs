using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NationalCrime.Web.Interfaces
{
    interface IUserInfo
    {
        string UserId { get; }
        string UserToken { get; }
    }
}
