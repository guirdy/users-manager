using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace UsersManagerApi.Utils
{
    public class PwdHash
    {
        private byte[] Salt = RandomNumberGenerator.GetBytes(128 / 8);

        public string HashPassword(string providedPassword)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: providedPassword,
                        salt: Salt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8));
        }

        public bool VerifyPassword(string providedPassword, string storedHash)
        {
            string hashedPassword = HashPassword(providedPassword);
            return storedHash == hashedPassword;
        }
    }
}
