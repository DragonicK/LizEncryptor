using Microsoft.VisualStudio.TestTools.UnitTesting;
using LizEncryptor;
using LizEncryptor.Cryptography;

namespace LizEncryptorTest {
    [TestClass]
    public class Main {
        [TestMethod]
        public void StartKeyGenerator() {
            var generator = new CryptographyKey();

            if (!generator.IsKeyCreated()) {
                var result = generator.CanCreateKey("");

                if (!result) {
                    // A chave não foi criada, deseja usar a padrão?
                }

                var key = generator.IsKeyCreated() ? generator.GetKey() : generator.GetDefaultKey();
                var iv = generator.IsKeyCreated() ? generator.GetIv() : generator.GetDefaultIv();
            }
        }

        [TestMethod]
        public void StartEncryptAndDecrypt() {
            var generator = new CryptographyKey();

            if (!generator.IsKeyCreated()) {
                var result = generator.CanCreateKey("");

                if (!result) {
                    // A chave não foi criada, deseja usar a padrão?
                }

                var key = generator.IsKeyCreated() ? generator.GetKey() : generator.GetDefaultKey();
                var iv = generator.IsKeyCreated() ? generator.GetIv() : generator.GetDefaultIv();

                var aes = new AesCryptography {
                    CipherMode = System.Security.Cryptography.CipherMode.ECB,
                    KeySize = CryptographyKeySize.KeySize128,
                    PaddingMode = System.Security.Cryptography.PaddingMode.PKCS7
                };

                var hash = Hash.Compute("Texto para exemplo!");
                var encrypted = aes.Encrypt(hash, generator.GetKey(), generator.GetIv(), out var success);

                if (success) {
                    var decrypted = aes.Decrypt(hash, key, iv, out success);

                    if (success) {
      
                    }
                }
            }
        }

        [TestMethod]
        public void StartEncryptionHandler() {
            var generator = new CryptographyKey();
            var result = generator.CanCreateKey("datamore");

            if (result) {
                var cryptor = new EncryptionHandler(generator);
                var data = Hash.Compute("Texto de exemplo!");

                var encrypted = cryptor.Encrypt(data, out result);
                
                if (result) {
                    var decrypted = cryptor.Decrypt(data, out result);
                }
            }
        }
    }
}