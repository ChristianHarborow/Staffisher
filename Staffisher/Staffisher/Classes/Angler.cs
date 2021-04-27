using System;
using System.Collections.Generic;
using System.Text;

namespace Staffisher.Classes
{
    public class Angler
    {
        public string Email { get; }
        public string PasswordHash { get; }
        public string Username { get; }
        public bool IsAdmin { get; }

        public Angler(string email, string passwordHash, string username, bool isAdmin = false)
        {
            Email = email;
            PasswordHash = passwordHash;
            Username = username;
            IsAdmin = isAdmin;
        }

        public Angler(string username)
        {
            //TESTING PURPOSES
            Username = username;
        }

        override public string ToString()
        {
            return Username;
        }
    }
}
