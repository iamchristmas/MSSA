using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace UsernamePassword
{
    class User
    {
        public string Username { get; set; }
        public byte[] Password { get; set; }
        public User (string username,string password)
        {
            Username = username;
            Password = Util.HashString(password);
        }
        public bool ValidatePassword(string stringToCheck)
        {
            byte[] passwordToCheck = Util.HashString(stringToCheck);
            if (passwordToCheck.ToString() == this.Password.ToString()) return true;
            else return false;
        }

    }
}
