using System.IO;
using System.Security.Cryptography;

namespace LizEncryptor.Cryptography {
    public class AesCryptography {
        public CryptographyKeySize KeySize { get; set; }
        public CipherMode CipherMode { get; set; }
        public PaddingMode PaddingMode { get; set; }

        private const int BlockSize = 128;

        public byte[] Encrypt(byte[] bytesToBeEncrypted, byte[] key, byte[] iv, out bool success) {
            byte[] encryptedBytes = null;

            try {
                using (var AES = new RijndaelManaged()) {
                    using (MemoryStream ms = new MemoryStream()) {
                        AES.KeySize = (int)KeySize;
                        AES.BlockSize = BlockSize;
                        AES.Mode = CipherMode;
                        AES.Padding = PaddingMode;

                        AES.Key = key;
                        AES.IV = iv;

                        using (var cs = new CryptoStream(ms, AES.CreateEncryptor(), CryptoStreamMode.Write)) {
                            cs.Write(bytesToBeEncrypted, 0, bytesToBeEncrypted.Length);
                            cs.Close();
                        }

                        encryptedBytes = ms.ToArray();
                        success = true;
                    }
                }
            }
            catch {
                success = false;
            }

            return encryptedBytes;
        }

        public byte[] Decrypt(byte[] bytesToBeDecrypted, byte[] key, byte[] iv, out bool success) {
            byte[] encryptedBytes = null;

            try {
                using (var AES = new RijndaelManaged()) {
                    using (MemoryStream ms = new MemoryStream()) {
                        AES.KeySize = (int)KeySize;
                        AES.BlockSize = BlockSize;
                        AES.Mode = CipherMode;
                        AES.Padding = PaddingMode;

                        AES.Key = key;
                        AES.IV = iv;

                        using (var cs = new CryptoStream(ms, AES.CreateDecryptor(), CryptoStreamMode.Write)) {
                            cs.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
                            cs.Close();
                        }

                        success = true;
                        encryptedBytes = ms.ToArray();
                    }
                }
            }
            catch {
                success = false;
            }

            return encryptedBytes;
        }
    }
}