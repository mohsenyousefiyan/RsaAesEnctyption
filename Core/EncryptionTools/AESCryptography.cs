using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Core.EncryptionTools
{
    public class AESCryptography
    {       
        private int KeySize;        
        private PaddingMode PaddingMode;
        private CipherMode CipherMode;

        public AESCryptography(Enums.AESKeySize keysize =Enums.AESKeySize.Key256,PaddingMode paddingmode=PaddingMode.PKCS7, CipherMode ciphermode=CipherMode.ECB)
        {
            
            this.KeySize =(int)keysize;           
            this.PaddingMode = paddingmode;
            this.CipherMode = ciphermode;
        }

        public string EncryptAsync(string base64Key,string Plaintext)
        {
            KeyValidation(base64Key);

            try
            {
                byte[] keyBytes = StringHelper.Base64ToByteArray(base64Key);
                var EncryptArray = StringHelper.StringToByteArray(Plaintext);

                var AESObject = CreateAESProvider();
                AESObject.Key = keyBytes;
                var Encryptor = AESObject.CreateEncryptor();

                var EncByte = Encryptor.TransformFinalBlock(EncryptArray, 0, EncryptArray.Length);
                var result = StringHelper.GetBase64(EncByte);
                return result;
            }
            catch
            {
                return null;
            }           
        }

        public string DecryptAsync(string base64Key, string Ciphertext)
        {
            KeyValidation(base64Key);

            try
            {
                byte[] keyBytes = StringHelper.Base64ToByteArray(base64Key);
                var DecryptArray = StringHelper.Base64ToByteArray(Ciphertext);

                var AESObject = CreateAESProvider();
                AESObject.Key = keyBytes;
                var Decryptor = AESObject.CreateDecryptor();
                var DecByte = Decryptor.TransformFinalBlock(DecryptArray, 0, DecryptArray.Length);
                var result = StringHelper.ByteArrayToString(DecByte);
                return result;
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
                KeySize = KeySize,
                BlockSize = 128,               
                Padding = PaddingMode,
                Mode = CipherMode
            };
        }

        public string GenerateKey()
        {
            #region OldCode
            /*Random Rnd = new Random();
            var RndInt = Rnd.Next(10000, 150000000);
            var dateString = RndInt.ToString()+" "+ DateTime.Now.Millisecond.ToString() + ":" + DateTime.Now.Second.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Hour.ToString() + " " + DateTime.Now.Date.ToString();
            var result = StringHelper.GetBase64(dateString);

            if (result.Length > 32)
                result = result.Substring(0, 32);

            return new SymmetricCryptographyResultDto { Key=result,ExpierDate=DateTime.Now.AddMinutes(symmetricCryptographyConfig.SymmetricKeyExpirationMinutes)};*/
            #endregion

            var AESObject = CreateAESProvider();
            byte[] keyGenerated = AESObject.Key;
            return Convert.ToBase64String(keyGenerated);          
        }

        private void KeyValidation(string base64Key)
        {
            if (StringHelper.Base64ToByteArray(base64Key).Length * 8 != this.KeySize)
                throw new Exception("Key Length And KeySize Is Not Compatible");
        }
    }
}
