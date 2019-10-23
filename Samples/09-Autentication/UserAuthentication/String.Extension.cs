using System.Security.Cryptography;
using System.Text;

namespace Authentication.UserAuthentication
{
    public static class StringExtension
    {
        public static string MD5Hash(this string text)
        {
            if (string.IsNullOrEmpty(text)) { return text; }

            var md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            var strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++) { strBuilder.Append(result[i].ToString("x2")); }

            return strBuilder.ToString();
        }
    }
}
