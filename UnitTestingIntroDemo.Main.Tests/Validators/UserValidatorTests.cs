using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitTestingIntroDemo.Main.Models;
using UnitTestingIntroDemo.Main.Tests.Helpers.Builders;
using UnitTestingIntroDemo.Main.Validators;

namespace UnitTestingIntroDemo.Main.Tests.Validators
{
    [TestFixture]
    public class UserValidatorTests
    {
        [Test]
        public void IsValid_EmailIsNull_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithEmail(null)
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_EmailIsEmpty_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithEmail("")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_EmailIsInvalid_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithEmail("a@a")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordIsNull_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword(null)
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordIsEmpty_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword("")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordWithLessThan6Characters_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword("12aB_")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordWithMoreThan10Characters_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword("12345678aB_")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordWithWhitespace_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword("abCD 12!_")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordWithoutLowercaseLetter_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword("ABC123!_")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordWithoutUppercaseLetter_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword("abc123!_")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordWithoutNumbers_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword("abcDEF!_")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_PasswordWithoutSymbols_ReturnsFalse()
        {
            var user = UserBuilder.AUser()
                .WithPassword("abCD1234")
                .Build();

            AssertThat(user, expectation: Is.False);
        }

        [Test]
        public void IsValid_ValidEmailAndPassword_ReturnsTrue()
        {
            var user = UserBuilder.AUser().Build();

            AssertThat(user, expectation: Is.True);
        }
        
        private static void AssertThat(User user, IResolveConstraint expectation)
        {
            var validator = new UserValidator();

            // Act
            var result = validator.IsValid(user);

            // Assert
            Assert.That(result, expectation);
        }        
    }
}
