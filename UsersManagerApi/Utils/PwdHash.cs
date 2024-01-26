using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace UsersManagerApi.Utils
{
    public class PwdHash
    {
        public string HashPassword(string providedPassword, byte[] pwdSalt)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                        password: providedPassword,
                        salt: pwdSalt,
                        prf: KeyDerivationPrf.HMACSHA256,
                        iterationCount: 100000,
                        numBytesRequested: 256 / 8));
        }

        public bool VerifyPassword(string providedPassword, string storedHash, byte[] pwdSalt)
        {
            string hashedPassword = HashPassword(providedPassword, pwdSalt);
            return storedHash == hashedPassword;
        }
    }
}
