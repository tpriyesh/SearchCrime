﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace NationalCrime.Service.Infrastructure
{
    public interface IMembershipService
    {
        int MinPasswordLength { get; }

        bool ValidateUser(string userName, string password);
        MembershipCreateStatus CreateUser(string userName, string password, string email);
        bool ChangePassword(string userName, string oldPassword, string newPassword);
    }
}
