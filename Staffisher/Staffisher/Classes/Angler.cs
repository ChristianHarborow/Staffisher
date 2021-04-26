using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class Angler
    {
        string Email { get; }
        string Username { get; }
        bool IsAdmin { get; }

        public Angler(string email, string username, bool isAdmin)
        {
            Email = email;
            Username = username;
            IsAdmin = isAdmin;
        }
    }
}
