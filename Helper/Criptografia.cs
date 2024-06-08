using System.Security.Cryptography;
using System.Text;

namespace MeuSiteEmMVC.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(this string valor)
        {
            var hash = SHA1.Create();
            var encode = new ASCIIEncoding();
            var array = Encoding.ASCII.GetBytes(valor);

            array = hash.ComputeHash(array);

            var strHex = new StringBuilder();

            foreach (var c in array)
            {
                strHex.Append(c.ToString("x2"));
            }

            return strHex.ToString();
        }
    }
}
