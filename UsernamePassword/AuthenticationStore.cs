using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace UsernamePassword
{
    class AuthenticationStore
    {
        private int count = 0;

        private Dictionary<int, User> authStore = new Dictionary<int, User>();

        //TODO: Check to see if username already exists.
        public void AddUser(string username, string password)
        {

            User user = new User(username, password);
            authStore.Add(Count++, user);
            return;
        }
        public void AuthenticateUser(string username, string password)
        {
            User validateUser = FindUser(username);
            if (validateUser.ValidatePassword(password) == true)
            {
                Console.WriteLine("You have entered valid credentials");
            }
            else Console.WriteLine("You have entered invalid credentials");
        }
        public User FindUser(string username)
        {
            for (int i = 0; i < count; i++)
            {
                if (authStore[i].Username == username) return authStore[i];
            }
            throw new KeyNotFoundException($"The user {username} does not exist.");
        }

        public void DumpCreds()
        {
            foreach (User u in authStore.Values)
            {
                Console.WriteLine($"{u.Username}||{u.Password.ToString()}");
            }
        }

        public int Count
        {
            get => count;
            set => count++;
        }

    }
}
