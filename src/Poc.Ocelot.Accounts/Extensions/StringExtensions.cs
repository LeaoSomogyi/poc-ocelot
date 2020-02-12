using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace Poc.Ocelot.Accounts.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Encript string using hashbytes
        /// </summary>
        /// <param name="password">string not cripted</param>
        /// <returns>The current string cript in hashbytes</returns>
        public static string Cript(this string password)
        {
            if (string.IsNullOrEmpty(password))
                return password;

            var encoding = new UnicodeEncoding();

            byte[] hashBytes;

            using (HashAlgorithm hash = SHA1.Create())
            {
                hashBytes = hash.ComputeHash(encoding.GetBytes(password));
            }

            var passwordCript = new StringBuilder();

            foreach (byte b in hashBytes)
            {
                passwordCript.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
            }

            return passwordCript.ToString();
        }
    }
}
