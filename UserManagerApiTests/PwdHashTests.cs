namespace UserManagerApiTests
{
    [TestClass]
    public class PwdHashTests
    {
        [TestMethod]
        public void TestMHashPassword()
        {
            // Arrange
            string password = "MySecurePassword";
            PwdHash pwdHash = new PwdHash();

            // Act
            string hashedPassword = pwdHash.HashPassword(password);
            Console.WriteLine($"Password: {hashedPassword}");

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
            string hashedPassword = pwdHash.HashPassword(password);

            // Act
            bool result = pwdHash.VerifyPassword(password, hashedPassword);

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
            string hashedPassword = pwdHash.HashPassword(correctPassword);

            // Act
            bool result = pwdHash.VerifyPassword(incorrectPassword, hashedPassword);

            // Assert
            Assert.IsFalse(result);
        }
    }
}