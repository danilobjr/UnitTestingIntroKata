using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingIntroDemo.Main.Models;

namespace UnitTestingIntroDemo.Main.Repositories
{
    public class UserRepository
    {
        public virtual void Create(User newUser)
        {
            Console.WriteLine(string.Format("EXTERNAL DEPENDENCY - Inserting user in DB {0}...", newUser.Email));
        }

        internal User FindById(int userId)
        {
            Console.WriteLine(string.Format("EXTERNAL DEPENDENCY - Inserting user in DB. Id: {0}...", userId));

            return new User
            {
                Id = userId,
                Email = "founduser@email.com",
                Password = "f0undU$3r"
            };
        }

        internal void Delete(int userId)
        {
            Console.WriteLine(string.Format("EXTERNAL DEPENDENCY - Deleting user from DB. Id: {0}...", userId));
        }
    }
}
