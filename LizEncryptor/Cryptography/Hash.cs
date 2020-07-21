using System.Text;
using System.Security.Cryptography;

namespace LizEncryptor.Cryptography {
    public static class Hash {
        /// <summary>
        /// Retorna um hash a partir dos dados fornecidos.
        /// </summary>
        /// <param name="data">dados a serem computados</param>
        /// <returns></returns>
        public static byte[] Compute(string data) {
            byte[] buffer;

            using (var sha = new SHA256Managed()) {
                buffer = sha.ComputeHash(Encoding.ASCII.GetBytes(data));
            }

            return buffer;
        }
    }
}