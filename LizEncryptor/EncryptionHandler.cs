using LizEncryptor.Cryptography;

namespace LizEncryptor {
    public class EncryptionHandler {
        private readonly AesCryptography aes;
        private readonly CryptographyKey key;

        public EncryptionHandler(CryptographyKey generator) {
            aes = new AesCryptography() { 
                KeySize = CryptographyKeySize.KeySize128,
                CipherMode = System.Security.Cryptography.CipherMode.CBC,
                PaddingMode = System.Security.Cryptography.PaddingMode.PKCS7
            };

            key = generator;
        }

        public byte[] Encrypt(byte[] data, out bool success) {
            return aes.Encrypt(data, GetKey(), GetIv(), out success);
        }

        public byte[] Decrypt(byte[] data, out bool success) {
            return aes.Decrypt(data, GetKey(), GetIv(), out success);
        }

        private byte[] GetKey() {
            return key.IsKeyCreated() ? key.GetKey() : key.GetDefaultKey();
        }

        private byte[] GetIv() {
            return key.IsKeyCreated() ? key.GetIv() : key.GetDefaultIv(); 
        }
    }
}