using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NationalCrime.Utilities
{
    public static class PasswordHelper
    {
        public static string GenerateHashedPassword(string userPassword, string randomCode)
        {
            var hashedPassword = HashExtensions.GetMD5Hash(string.Format("{0}{1}", userPassword, randomCode));
            return hashedPassword;
        }
    }
}
