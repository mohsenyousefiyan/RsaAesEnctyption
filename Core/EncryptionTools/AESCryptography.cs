using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.EncryptionTools
{
    public class AESCryptography
    {
        private string Key;
        private int KeySize;        
        private PaddingMode PaddingMode;
        private CipherMode CipherMode;

        public AESCryptography(string Key, Enums.AESKeySize keysize =Enums.AESKeySize.Key256,PaddingMode paddingmode=PaddingMode.PKCS7, CipherMode ciphermode=CipherMode.ECB)
        {
            this.Key = Key;
            this.KeySize =(int)keysize;

            if (Key.Length * 8 != this.KeySize)
                throw new Exception("Key Length And KeySize Is Not Compatible");
            
            this.PaddingMode = paddingmode;
            this.CipherMode = ciphermode;
        }

        public async Task<string> EncryptAsync(string Plaintext)
        {

            return await Task.Run(() =>
            {
                try
                {
                    byte[] key = StringHelper.StringToByteArray(Key);
                    var EncryptArray = StringHelper.StringToByteArray(Plaintext);

                    var AESObject = CreateAESProvider(key);
                    var Encryptor = AESObject.CreateEncryptor();

                    var EncByte = Encryptor.TransformFinalBlock(EncryptArray, 0, EncryptArray.Length);
                    var result = StringHelper.GetBase64(EncByte);
                    return result;
                }
                catch
                {
                    return null;
                }
            });
        }

        public async Task<string> DecryptAsync(string Ciphertext)
        {

            return await Task.Run(() =>
            {
                try
                {
                    byte[] key = StringHelper.StringToByteArray(Key);
                    var DecryptArray = StringHelper.Base64ToByteArray(Ciphertext);

                    var AESObject = CreateAESProvider(key);

                    var Decryptor = AESObject.CreateDecryptor();
                    var DecByte = Decryptor.TransformFinalBlock(DecryptArray, 0, DecryptArray.Length);
                    var result = StringHelper.ByteArrayToString(DecByte);
                    return result;
                }
                catch
                {
                    return null;
                }
            });
        }

        private AesCryptoServiceProvider CreateAESProvider(byte[] key)
        {
            return new AesCryptoServiceProvider
            {
                KeySize = KeySize,
                BlockSize = 128,
                Key = key,
                Padding = PaddingMode,
                Mode = CipherMode
            };
        }
    }
}
