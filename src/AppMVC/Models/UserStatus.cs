using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMVC.Models
{
    public enum UserStatus
    {
        AuthenticatedAdmin,
        AuthentucatedUser,
        NonAuthenticatedUser
    }
}