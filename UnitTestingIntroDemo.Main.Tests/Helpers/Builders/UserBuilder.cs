using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingIntroDemo.Main.Models;

namespace UnitTestingIntroDemo.Main.Tests.Helpers.Builders
{
    class UserBuilder
    {
        private string _email { get; set; }
        private string _password { get; set; }

        public static UserBuilder AUser()
        {
            return new UserBuilder().WithEmail("a@a.com").WithPassword("abCD12!_");
        }

        //public UserBuilder Valid()
        //{
        //    _email = "a@a.com";
        //    _password = "abCD12!_";

        //    return this;
        //}

        public UserBuilder WithEmail(string email)
        {
            _email = email;

            return this;
        }

        public UserBuilder WithPassword(string password)
        {
            _password = password;

            return this;
        }

        public User Build()
        {
            return new User
            {
                Email = _email,
                Password = _password
            };
        }
    }
}
