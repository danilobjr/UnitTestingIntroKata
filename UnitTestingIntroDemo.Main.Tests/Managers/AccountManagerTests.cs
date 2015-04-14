using FakeItEasy;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingIntroDemo.Main.Email;
using UnitTestingIntroDemo.Main.Managers;
using UnitTestingIntroDemo.Main.Models;
using UnitTestingIntroDemo.Main.Repositories;
using UnitTestingIntroDemo.Main.Validators;

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

        [Test]
        public void RegisterNewUser_ValidNewUser_ReturnsTrue()
        {
            // Arrange
            var validUser = new User();

            var validatorFake = A.Fake<UserValidator>();
            var repositoryFake = A.Fake<UserRepository>();
            var mailerFake = A.Fake<Mailer>();

            A.CallTo(() => validatorFake.IsValid(validUser)).Returns(true);

            var manager = new AccountManager(validatorFake, repositoryFake, mailerFake);

            // Act
            var userWasRegistered = manager.RegisterNewUser(validUser);

            // Assert
            Assert.IsTrue(userWasRegistered);
        }

        [Test]
        public void RegisterNewUser_ValidNewUser_CreateMethodOfUserRepositoryIsCalled()
        {
            // Arrange
            var validUser = new User();

            var validatorFake = A.Fake<UserValidator>();
            var repositoryFake = A.Fake<UserRepository>();
            var mailerFake = A.Fake<Mailer>();

            A.CallTo(() => validatorFake.IsValid(validUser)).Returns(true);

            var manager = new AccountManager(validatorFake, repositoryFake, mailerFake);

            // Act
            manager.RegisterNewUser(validUser);

            // Assert
            A.CallTo(() => repositoryFake.Create(validUser)).MustHaveHappened();
        }

        [Test]
        public void RegisterNewUser_ValidNewUser_SendMethodOfMailerIsCalled()
        {
            // Arrange
            var validUser = new User();

            var validatorFake = A.Fake<UserValidator>();
            var repositoryFake = A.Fake<UserRepository>();
            var mailerFake = A.Fake<Mailer>();

            A.CallTo(() => validatorFake.IsValid(validUser)).Returns(true);

            var manager = new AccountManager(validatorFake, repositoryFake, mailerFake);

            // Act
            manager.RegisterNewUser(validUser);

            // Assert
            A.CallTo(() => mailerFake.Send("no@reply", validUser.Email, "Welcome", "Welcome email message")).MustHaveHappened();
        }
    }
}
