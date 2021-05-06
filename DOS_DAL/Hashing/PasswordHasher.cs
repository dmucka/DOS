using System;
using System.Linq;
using System.Security.Cryptography;

namespace DOS_DAL.Hashing
{
    // https://medium.com/dealeron-dev/storing-passwords-in-net-core-3de29a3da4d2
    /// <summary>
    /// Provides hashing services.
    /// </summary>
    public static class PasswordHasher
    {
        private const int SaltSize = 16; // 128 bit 
        private const int KeySize = 32; // 256 bit
        private const int Iterations = 1000; // 1ms

        public static string Hash(string password)
        {
            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              SaltSize,
              Iterations,
              HashAlgorithmName.SHA256))
            {
                string key = Convert.ToBase64String(algorithm.GetBytes(KeySize));
                string salt = Convert.ToBase64String(algorithm.Salt);

                return $"{salt}.{key}";
            }
        }

        public static bool Check(string hash, string password)
        {
            string[] parts = hash.Split('.', 2);

            if (parts.Length != 2)
            {
                throw new FormatException("Unexpected hash format.");
            }

            byte[] salt = Convert.FromBase64String(parts[0]);
            byte[] key = Convert.FromBase64String(parts[1]);

            using (var algorithm = new Rfc2898DeriveBytes(
              password,
              salt,
              Iterations,
              HashAlgorithmName.SHA256))
            {
                byte[] keyToCheck = algorithm.GetBytes(KeySize);
                return keyToCheck.SequenceEqual(key);
            }
        }
    }
}
