using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LizEncryptor;
using LizEncryptor.Cryptography;

namespace LizEncryptorTest {
    [TestClass]
    public class Main {

        [TestMethod]
        public void ShouldGenerateKeys() {
            var generator = new CryptographyKey();
            Assert.IsTrue(generator.CanCreateKey("passphrase"), "A chave deveria ser criada.");
        }

        [TestMethod]
        public void ShouldNotGenerateKeys() {
            var generator = new CryptographyKey();
            Assert.IsFalse(generator.CanCreateKey(""), "A chave não deveria ser criada.");
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("username")]
        [DataRow("你好吗？")]
        public void ShouldEncryptAndDecrypt(string data) {
            var generator = new CryptographyKey();

            var result = generator.CanCreateKey("");

            Assert.IsFalse(result, "A chave não deveria ser criada.");

            var key = generator.IsKeyCreated() ? generator.GetKey() : generator.GetDefaultKey();
            var iv = generator.IsKeyCreated() ? generator.GetIv() : generator.GetDefaultIv();

            var aes = new AesCryptography {
                CipherMode = System.Security.Cryptography.CipherMode.ECB,
                KeySize = CryptographyKeySize.KeySize128,
                PaddingMode = System.Security.Cryptography.PaddingMode.PKCS7
            };

            var hash = Hash.Compute(data);

            var encrypted = aes.Encrypt(hash, key, iv,  out var success);

            Assert.IsNotNull(encrypted, "Os dados criptografados não deveriam ser nulos.");

            var decrypted = aes.Decrypt(encrypted, key, iv, out success);

            Assert.IsNotNull(decrypted, "Os dados descriptografados não deveriam ser nulos.");
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("username")]
        [DataRow("你好吗？")]
        public void ShouldHandlerEncryptData(string data) {
            var generator = new CryptographyKey();
            var result = generator.CanCreateKey("passphrase");

            Assert.IsTrue(result, "A chave deveria ser criada.");

            var cryptor = new EncryptionHandler(generator);
            var buffer = Encoding.UTF8.GetBytes(data);

            Assert.IsNotNull(cryptor.Encrypt(buffer, out result), "O retorno não deveria ser nulo.");
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("username")]
        [DataRow("你好吗？")]
        public void ShouldHandlerEncryptAndDecryptData(string data) {
            var generator = new CryptographyKey();
            var result = generator.CanCreateKey("passphrase");

            Assert.IsTrue(result, "A chave deveria ser criada.");

            var cryptor = new EncryptionHandler(generator);
            var buffer = Encoding.UTF8.GetBytes(data);

            var encrytped = cryptor.Encrypt(buffer, out result);

            Assert.IsNotNull(encrytped, "Os dados criptografados não deveriam ser nulos.");

            var decrypted = cryptor.Decrypt(encrytped, out result);

            Assert.IsNotNull(decrypted, "Os dados descriptografados não deveriam ser nulos.");

            var text = Encoding.UTF8.GetString(decrypted);
           
            Assert.IsTrue(text.CompareTo(data) == 0, $"O texto obtido não bate com os dados fornecido.");
        }
    }
}