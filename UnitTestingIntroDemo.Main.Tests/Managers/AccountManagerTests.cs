using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingIntroDemo.Main.Managers;
using UnitTestingIntroDemo.Main.Models;

namespace UnitTestingIntroDemo.Main.Tests.Managers
{
    [TestFixture]
    public class AccountManagerTests
    {
        [Test]
        public void RegisterNewUser_InvalidNewUser_ReturnsFalse()
        {
            // Arrange
            var invalidUser = new User();
            var manager = new AccountManager();

            // Act
            var userWasRegistered = manager.RegisterNewUser(invalidUser);

            // Assert
            Assert.IsFalse(userWasRegistered);
        }
    }
}
