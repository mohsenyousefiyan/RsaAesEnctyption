using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core.EncryptionTools
{
    public class AESFileCryptographyService 
    {
        private int KeySize;
        private PaddingMode PaddingMode;
        private CipherMode CipherMode;

        public AESFileCryptographyService()
        {
            KeySize = 256;
            PaddingMode = PaddingMode.PKCS7;
            CipherMode = CipherMode.ECB;
        }

        public byte[] EncryptFile(byte[] fileContent, string base64Key)
        {
            KeyValidation(base64Key);

            try
            {
                byte[] encrypted;
                byte[] IV;
                byte[] keyByte = StringHelper.Base64ToByteArray(base64Key);

                using (Aes aesAlg = Aes.Create())
                {
                    IV = GenerateRandomNumber(aesAlg.BlockSize / 8);
                    aesAlg.Key = keyByte;
                    aesAlg.IV = IV;
                    aesAlg.Mode = CipherMode.CBC;

                    var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    using (var memStream = new MemoryStream())
                    {
                        CryptoStream cryptoStream = new CryptoStream(memStream, encryptor, CryptoStreamMode.Write);

                        cryptoStream.Write(fileContent, 0, fileContent.Length);
                        cryptoStream.FlushFinalBlock();
                        encrypted = memStream.ToArray();
                    }
                }

                var combinedIvCt = new byte[IV.Length + encrypted.Length];
                Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
                Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

                return combinedIvCt;
            }
            catch
            {
                return null;
            }
        }

        public byte[] DecryptFile(byte[] fileContent, string base64Key)
        {
            KeyValidation(base64Key);

            try
            {
                byte[] keyByte = StringHelper.Base64ToByteArray(base64Key);
                var cipherTextCombined = fileContent;

                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = keyByte;

                    byte[] IV = new byte[aesAlg.BlockSize / 8];
                    byte[] cipherText = new byte[cipherTextCombined.Length - IV.Length];

                    Array.Copy(cipherTextCombined, IV, IV.Length);
                    Array.Copy(cipherTextCombined, IV.Length, cipherText, 0, cipherText.Length);

                    aesAlg.IV = IV;

                    aesAlg.Mode = CipherMode.CBC;

                    var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    using (var memStream = new MemoryStream())
                    {
                        CryptoStream cryptoStream = new CryptoStream(memStream, decryptor,
                            CryptoStreamMode.Write);

                        cryptoStream.Write(cipherText, 0, cipherText.Length);
                        cryptoStream.FlushFinalBlock();
                        return memStream.ToArray();
                    }
                }
            }
            catch
            {
                return null;
            }
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
            if (StringHelper.Base64ToByteArray(base64Key).Length * 8 != this.KeySize)
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
