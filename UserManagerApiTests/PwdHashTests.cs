using System.Security.Cryptography;

namespace UserManagerApiTests
{
    [TestClass]
    public class PwdHashTests
    {
        byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);

        [TestMethod]
        public void TestMHashPassword()
        {
            // Arrange
            string password = "MySecurePassword";
            PwdHash pwdHash = new PwdHash();

            // Act
            string hashedPassword = pwdHash.HashPassword(password, salt);

            // Assert
            Assert.IsNotNull(hashedPassword);
            Assert.AreNotEqual(password, hashedPassword);
        }

        [TestMethod]
        public void VerifyPassword_ValidPassword_ReturnsTrue()
        {
            // Arrange
            string password = "MySecurePassword";
            PwdHash pwdHash = new PwdHash();
            string hashedPassword = pwdHash.HashPassword(password, salt);

            // Act
            bool result = pwdHash.VerifyPassword(password, hashedPassword, salt);

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void VerifyPassword_InvalidPassword_ReturnsFalse()
        {
            // Arrange
            string correctPassword = "MySecurePassword";
            string incorrectPassword = "IncorrectPassword";
            PwdHash pwdHash = new PwdHash();
            string hashedPassword = pwdHash.HashPassword(correctPassword, salt);

            // Act
            bool result = pwdHash.VerifyPassword(incorrectPassword, hashedPassword, salt);

            // Assert
            Assert.IsFalse(result);
        }
    }
}