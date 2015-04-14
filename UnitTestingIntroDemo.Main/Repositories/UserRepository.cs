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
            throw new NotImplementedException();
        }

        internal User FindById(int userId)
        {
            throw new NotImplementedException();
        }

        internal void Delete(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
