using System.Security.Cryptography;
using System.Text;

namespace Autentication.Extension
{
    public static class StringExtension
    {
        public static string MD5Hash(this string text)
        {
            var md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            var strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++) { strBuilder.Append(result[i].ToString("x2")); }

            return strBuilder.ToString();
        }
    }
}
