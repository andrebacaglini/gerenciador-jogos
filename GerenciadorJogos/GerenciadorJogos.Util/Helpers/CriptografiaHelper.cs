using System;
using System.Security.Cryptography;
using System.Text;

namespace GerenciadorJogos.Util.Helpers
{
    public class CriptografiaHelper
    {
        public static string Criptografar(string value)
        {
            var hash = SHA1.Create();
            var codificador = new ASCIIEncoding();
            var bytes = codificador.GetBytes(value ?? "");
            return BitConverter.ToString(hash.ComputeHash(bytes)).ToLower().Replace("-", "");
        }
    }
}
