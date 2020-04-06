using System;


namespace UsernamePassword
{
    class Program
    {
        static void Main(string[] args)
        {
            bool running = true;
            AuthenticationStore SampleAuthStore = new AuthenticationStore();
            Console.WriteLine("Welcome to this week's assignment \n");
            while (running)
            {
                Console.WriteLine("What would you like to do? :");
                Console.WriteLine("1. Establish an account ");
                Console.WriteLine("2. Authenticate a user ");
                Console.WriteLine("3. Exit the system ");
                Console.WriteLine("Enter Selection ");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter new username:");
                        string newusername = Console.ReadLine();
                        Console.WriteLine("Enter new password:");
                        string newpassword = Console.ReadLine();
                        SampleAuthStore.AddUser(newusername, newpassword);
                        break;
                    case 2:
                        Console.WriteLine("Enter your username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter your password:");
                        string password = Console.ReadLine();
                        SampleAuthStore.AuthenticateUser(username,password);
                        break;
                    case 3:
                        running = false;
                        SampleAuthStore.DumpCreds();
                        break;
                }
            }
        }
    }
}
