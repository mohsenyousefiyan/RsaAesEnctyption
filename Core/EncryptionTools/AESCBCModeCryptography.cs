using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core.EncryptionTools
{
    public class AESCBCModeCryptography
    {
        private int KeySize;
        private PaddingMode PaddingMode;
        private CipherMode CipherMode;

        public AESCBCModeCryptography()
        {
            KeySize = 256;
            PaddingMode = PaddingMode.PKCS7;
            CipherMode = CipherMode.ECB;
        }

        public string Decrypt(string base64Key, string ciphertext)
        {
            KeyValidation(base64Key);
            string plaintext = null;

            try
            {
                byte[] keyBytes = StringHelper.Base64ToByteArray(base64Key);
                var cipherTextCombined = StringHelper.Base64ToByteArray(ciphertext);

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyBytes;
                    byte[] IV = new byte[aesAlg.BlockSize / 8];
                    byte[] cipherArray = new byte[cipherTextCombined.Length - IV.Length];

                    Array.Copy(cipherTextCombined, IV, IV.Length);
                    Array.Copy(cipherTextCombined, IV.Length, cipherArray, 0, cipherArray.Length);

                    aesAlg.IV = IV;
                    aesAlg.Mode = CipherMode.CBC;

                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (var msDecrypt = new MemoryStream(cipherArray))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch
            {

            }

            return plaintext;
        }

        public string Encrypt(string base64Key, string plainText)
        {
            KeyValidation(base64Key);

            try
            {
                byte[] keyBytes = StringHelper.Base64ToByteArray(base64Key);
                byte[] encrypted;
                byte[] IV;

                using (Aes aesAlg = Aes.Create())
                {
                    IV = GenerateRandomNumber(aesAlg.BlockSize / 8);
                    aesAlg.Key = keyBytes;
                    aesAlg.IV = IV;
                    aesAlg.Mode = CipherMode.CBC;

                    var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }

                var combinedIvCt = new byte[IV.Length + encrypted.Length];
                Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
                Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

                return StringHelper.GetBase64(combinedIvCt);
            }
            catch
            {
                return null;
            }
        }

        public string GenerateKey()
        {
            var AESObject = CreateAESProvider();
            AESObject.Key = GenerateRandomNumber(KeySize / 8);
            byte[] keyGenerated = AESObject.Key;
            var Key = Convert.ToBase64String(keyGenerated);
            return Key;
        }

        private AesCryptoServiceProvider CreateAESProvider()
        {
            return new AesCryptoServiceProvider
            {
                KeySize = 256,
                BlockSize = 128,
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.ECB
            };
        }

        private void KeyValidation(string base64Key)
        {
            if (StringHelper.Base64ToByteArray(base64Key).Length * 8 != KeySize)
                throw new Exception("Key Length And KeySize Is Not Compatible");
        }

        private byte[] GenerateRandomNumber(int size)
        {
            var random = new RNGCryptoServiceProvider();
            var number = new byte[size];
            random.GetBytes(number);
            return number;
        }
    }
}
