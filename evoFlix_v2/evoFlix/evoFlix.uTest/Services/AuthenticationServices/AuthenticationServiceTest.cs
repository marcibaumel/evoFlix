using NUnit.Framework;
using System;
using System.Collections.Generic;
using evoFlix.Services;
using evoFlix.Services.AuthenticationServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.AspNet.Identity;
using evoFlix.Models.Users;
using evoFlix.Services.Exceptions;

namespace evoFlix.uTest.Services.AuthenticationServices
{
    [TestFixture]
    public class AuthenticationServiceTest
    {
        private AuthenticationService authenticationService;
        private Mock<IMainUserService> mockMainUserService;
        private Mock<IPasswordHasher> mockPasswordHasher;
        private string expectedUsername = "testuser";
        private string password = "Testpassword123";
        private string actualUsername;
        private RegistrationResult expected;
        private RegistrationResult actual;
        private string usernameForRegister = "userNameForRegister";
        private string emailForRegister = "emailForRegister";

        [SetUp]
        public void AuthenticationServiceTestSetup()
        {
            mockMainUserService = new Mock<IMainUserService>();
            mockPasswordHasher = new Mock<IPasswordHasher>();
            authenticationService = new AuthenticationService(mockMainUserService.Object, mockPasswordHasher.Object);
        }

        // Login Test

        [Test]
        public void Login_CorrectPasswordWithUsername_ReturnsAccount()
        {
            mockMainUserService.Setup(x => x.GetByUsername(expectedUsername)).Returns(new MainUserTableModel() { Username = expectedUsername });
            mockPasswordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Success);

            MainUserTableModel mainUser = authenticationService.Login(expectedUsername, password);


            actualUsername = mainUser.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public void Login_InCorrectPasswordWithUsername_ThrowsInvalidPasswordException()
        {
            mockMainUserService.Setup(x => x.GetByUsername(expectedUsername)).Returns(new MainUserTableModel() { Username = expectedUsername });
            mockPasswordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            InvalidPasswordException exception = Assert.Throws<InvalidPasswordException>(() => authenticationService.Login(expectedUsername, password));

            actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        [Test]
        public void Login_WithNonExistingUsername_ThrowsInvalidPasswordException()
        {
            mockPasswordHasher.Setup(x => x.VerifyHashedPassword(It.IsAny<string>(), password)).Returns(PasswordVerificationResult.Failed);

            UserNotFoundException exception = Assert.Throws<UserNotFoundException>(() => authenticationService.Login(expectedUsername, password));

            actualUsername = exception.Username;
            Assert.AreEqual(expectedUsername, actualUsername);
        }

        //Registration test

        [Test]
        public void Register_PasswordsNotMatching_ReturnsPasswordsDoNotMatch()
        {
            string confirmedPassword = "confirmedtestpassword";

            expected = RegistrationResult.PasswordsDoNotMatch;
            actual = authenticationService.Register(usernameForRegister, emailForRegister, password, confirmedPassword, It.IsNotNull<DateTime>());

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Register_WeakPassword_ReturnsWeakPassword()
        {
            string weakpassword = "weaktestpass";

            expected = RegistrationResult.WeakPassword;

            actual = authenticationService.Register(usernameForRegister, emailForRegister, weakpassword, weakpassword, It.IsNotNull<DateTime>());

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Register_AlreadyExistingEmail_ReturnsEmailAddressIsAlreadyUsed()
        {
            string email = "test@teszt.com";

            mockMainUserService.Setup(x => x.GetByEmail(email)).Returns(new MainUserTableModel());

            expected = RegistrationResult.EmailAddressIsAlreadyUsed;
            actual = authenticationService.Register(usernameForRegister, email, password, password, It.IsNotNull<DateTime>());

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Register_AlreadyExistingUsername_ReturnsUsernameIsAlreadyUsed()
        {
            string username = "testuser";

            mockMainUserService.Setup(x => x.GetByUsername(username)).Returns(new MainUserTableModel());

            expected = RegistrationResult.UsernameIsAlreadyUsed;
            actual = authenticationService.Register(username, emailForRegister, password, password,DateTime.Now);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Register_WithNewGoodUser_ReturnsSuccess()
        {

            expected = RegistrationResult.Success;
            actual = authenticationService.Register(usernameForRegister, emailForRegister, password, password, DateTime.Now);

            Assert.AreEqual(expected, actual);
        }
    }
}
