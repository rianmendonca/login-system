using System.Security.Cryptography;
using System.Text;

namespace login_system.Helper
{
    public static class Cryptography
    {
        public static string GenerateHash(this string password)
        {
            var hash = SHA1.Create();

            var encoding = new ASCIIEncoding();

            var array = encoding.GetBytes(password);

            array = hash.ComputeHash(array);

            var strHexa = new StringBuilder();

            foreach (var i in array)
            {
                strHexa.Append(i.ToString("x2"));
            }

            return strHexa.ToString();
        }
    }
}

