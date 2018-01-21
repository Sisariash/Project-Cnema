using System;
using System.Security.Cryptography;

using Microsoft.AspNet.Identity;

namespace Komponenten.Util
{
    public class Utils
    {

        // Password Hashing gemäß RFC 2898

        public static string HashPassword(string password)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            return passwordHasher.HashPassword(password);
        }

        public static bool VerifyPassword(string hashedPassword, string passwordToCompare)
        {
            PasswordHasher passwordHasher = new PasswordHasher();
            PasswordVerificationResult result = passwordHasher.VerifyHashedPassword(hashedPassword, passwordToCompare);
            return result == PasswordVerificationResult.Success;
        }
    }
}
