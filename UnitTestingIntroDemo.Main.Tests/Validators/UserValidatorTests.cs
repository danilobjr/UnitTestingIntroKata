using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingIntroDemo.Main.Models;
using UnitTestingIntroDemo.Main.Validators;

namespace UnitTestingIntroDemo.Main.Tests.Validators
{
    [TestFixture]
    public class UserValidatorTests
    {
        [Test]
        public void IsValid_UserEmailIsNull_ReturnsFalse()
        {
            // Arrange
            var invalidUser = new User
            {
                Email = null
            };

            var validator = new UserValidator();

            // Act
            var userIsVaild = validator.IsValid(invalidUser);

            // Assert
            Assert.IsFalse(userIsVaild);
        }

        [Test]
        public void IsValid_UserEmailIsEmpty_ReturnsFalse()
        {
            // Arrange
            var invalidUser = new User
            {
                Email = ""
            };

            var validator = new UserValidator();

            // Act
            var userIsVaild = validator.IsValid(invalidUser);

            // Assert
            Assert.IsFalse(userIsVaild);
        }
    }
}
