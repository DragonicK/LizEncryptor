namespace LizEncryptor.Cryptography {
    public class CryptographyKey {
        private readonly byte[] defaultKey;
        private readonly byte[] defaultIv;

        private byte[] key;
        private byte[] iv;

        public CryptographyKey() {
            defaultKey = new byte[CryptographyKeyLength.Key];
            defaultIv = new byte[CryptographyKeyLength.Iv];

            for (var i = 0; i < CryptographyKeyLength.Key; i++) {
                defaultKey[i] = (byte)i;
            }

            for (var i = 0; i < CryptographyKeyLength.Iv; i++) {
                defaultIv[i] = (byte)i;
            }
        }

        public bool IsKeyCreated() {
            if (key != null && iv != null) {
                return true;
            }

            return false;
        }

        public byte[] GetKey() {
            return key;
        }

        public byte[] GetIv() {
            return iv;
        }

        public byte[] GetDefaultKey() {
            return defaultKey;
        }

        public byte[] GetDefaultIv() {
            return defaultIv;
        }

        public bool CanCreateKey(string password) {
            if (string.IsNullOrEmpty(password)) {
                return false;
            }

            key = new byte[CryptographyKeyLength.Key];
            iv = new byte[CryptographyKeyLength.Iv];

            var hash = Hash.Compute(password);

            for (var i = 0; i < CryptographyKeyLength.Key; i++) {
                key[i] = hash[i % hash.Length];
            }

            for (var i = (CryptographyKeyLength.Iv - 1); i >= 0; i--) {
                iv[i] = hash[i % hash.Length];
            }

            return true;
        } 
    }
}