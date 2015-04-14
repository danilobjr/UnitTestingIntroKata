using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingIntroDemo.Main.Managers;
using UnitTestingIntroDemo.Main.Models;

namespace UnitTestingIntroDemo.Main
{
    class Program
    {
        static void Main(string[] args)
        {
            User newUser = GetUserInfoFromInputData();

            try
            {
                var accountManager = new AccountManager();
                accountManager.RegisterNewUser(newUser);

                ShowSuccessMessageOnConsole(newUser);
            }
            catch (Exception e)
            {
                Console.WriteLine(string.Format("ERROR: {0}", e.Message));
                Console.ReadKey();
            }
        }

        private static User GetUserInfoFromInputData()
        {
            Console.Write("Email: ");
            var email = Console.ReadLine();
            Console.Write("Password: ");
            var password = Console.ReadLine();

            var newUser = new User
            {
                Email = email,
                Password = password
            };

            return newUser;
        }

        private static void ShowSuccessMessageOnConsole(User newUser)
        {
            Console.WriteLine("");
            Console.WriteLine("User created with the following credentials:");
            Console.Write(string.Format("Email: {0}; Password: {1}.", newUser.Email, newUser.Password));

            Console.ReadKey();
        }
    }
}
