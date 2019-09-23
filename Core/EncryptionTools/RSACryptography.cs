using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Core.EncryptionTools.Enums;

namespace Core.EncryptionTools
{
    public class RSACryptography
    {
        private int KeySize;
        private Boolean UsePadding = false;

        public RSACryptography(RSAKeySize RsaKeySize)
        {            
            KeySize = (int)RsaKeySize;

            if (KeySize % 2 != 0 || KeySize < 1024)
                throw new Exception("Key Size should Be Multiple Of two And Greater Than 1024");            
        }

        public RSAKeyPair GenerateKeys()
        {            
            var RSAKeyPair = new RSAKeyPair();

            using (var provider = new RSACryptoServiceProvider(KeySize))
            {
                var publicKey = provider.ToXmlString(false);
                var privateKey = provider.ToXmlString(true);

                
                RSAKeyPair.PublicKey = StringHelper.GetBase64(publicKey);
                RSAKeyPair.PrivateKey = StringHelper.GetBase64(privateKey);                                  
            }

            return RSAKeyPair;
        }

        public async Task<string> EncryptAsync(string publickey,string plaintext)
        {
            try
            {
                var XmlPublicKey =await GetXmlKeyFromBase64(publickey);

                if (XmlPublicKey == null)
                    return null;

                byte[] Data = StringHelper.StringToByteArray(plaintext);

                return await Task.Run(() =>
                {
                    try
                    {
                        if (Data == null || Data.Length == 0)
                            return null;

                        int maxLength = GetMaxDataLength(this.KeySize);

                        if (Data.Length > maxLength)
                            throw new ArgumentException(String.Format("Maximum data length is {0}", maxLength), "Data");

                        if (!IsKeySizeValid(this.KeySize))
                            throw new ArgumentException("Key size is not valid", "keySize");

                        if (String.IsNullOrEmpty(XmlPublicKey))
                            throw new ArgumentException("Key is null or empty", "publicKeyXml");

                        using (var provider = new RSACryptoServiceProvider(this.KeySize))
                        {
                            provider.FromXmlString(XmlPublicKey);
                            var EncryptArray = provider.Encrypt(Data,RSAEncryptionPadding.Pkcs1);
                            return StringHelper.GetBase64(EncryptArray);
                        }
                    }
                    catch
                    {
                        return null;
                    }
                });
            }
            catch
            {
                return null;
            }
        }

        public async Task<string>DecryptAsync(string privatekey,string ciphertext)
        {
            try
            {
                var XmlPrivateKey = await GetXmlKeyFromBase64(privatekey);

                if (XmlPrivateKey == null)
                    return null;

                byte[] Data = StringHelper.Base64ToByteArray(ciphertext);

                return await Task.Run(() =>
                {
                    try
                    {
                        if (Data == null || Data.Length == 0)
                            throw new ArgumentException("Data are empty", "data");

                        if (!IsKeySizeValid(this.KeySize))
                            throw new ArgumentException("Key size is not valid", "keySize");

                        if (String.IsNullOrEmpty(XmlPrivateKey))
                            throw new ArgumentException("Key is null or empty", "publicAndPrivateKeyXml");

                        using (var provider = new RSACryptoServiceProvider(this.KeySize))
                        {
                            provider.FromXmlString(XmlPrivateKey);

                            var DecryotArray = provider.Decrypt(Data, RSAEncryptionPadding.Pkcs1);
                            return StringHelper.ByteArrayToString(DecryotArray);
                        }
                    }
                    catch
                    {
                        return null;
                    }
                });
            }
            catch
            {
                return null;
            }                                              
        }



        private async Task<string> GetXmlKeyFromBase64(string rawkey)
        {
                        
                return await Task.Run(() =>
                {
                    try
                    {
                        byte[] keyBytes = Convert.FromBase64String(rawkey);
                        var stringKey = Encoding.UTF8.GetString(keyBytes);
                        return stringKey;
                    }
                    catch
                    {
                        return null;
                    }                    
                });            

        }
        private int GetMaxDataLength(int keySize)
        {
            if (UsePadding)
            {
                return ((keySize - 384) / 8) + 7;
            }
            return ((keySize - 384) / 8) + 37;
        }
        private Boolean IsKeySizeValid(int keySize)
        {
            return keySize >= 384 && keySize <= 16384 && keySize % 8 == 0;
        }
    }
}
