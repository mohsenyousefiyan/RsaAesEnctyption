using Core.EncryptionTools;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RSAEncryption
{
    public partial class Frm_BouncyCastle : Form
    {
        public Frm_BouncyCastle()
        {
            InitializeComponent();
        }

        private void Btn_GenerateKeys_Click(object sender, EventArgs e)
        {
            if (Rdb_RsaEncrypt.Checked)
            {
                var keyPair = GenerateKeys();


                Txt_PublicKey.Text = GetStringKey(keyPair, false);
                Txt_PrivateKey.Text = GetStringKey(keyPair, true);
            }
            else if(Rdb_AesECBEncrypt.Checked)
            {
                Txt_PublicKey.Text = GenerateAesKey(true);
                Txt_PrivateKey.Clear();
            }
            else if (Rdb_AesCBCEncrypt.Checked)
            {
                Txt_PublicKey.Text = GenerateAesKey(false);
                Txt_PrivateKey.Clear();
            }

        }

        private  void Btn_Encrypt_Click(object sender, EventArgs e)
        {
            if(Rdb_RsaEncrypt.Checked)
                Txt_CipherText.Text = encrypt1(Txt_PlainText.Text,Txt_PublicKey.Text);
            else if(Rdb_AesECBEncrypt.Checked)
            {
                try
                {
                    AESCryptography Aes = new AESCryptography();
                    var Enc =  Aes.EncryptAsync(Txt_PublicKey.Text ,Txt_PlainText.Text);
                    Txt_CipherText.Text = Enc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetErrorMessage());
                }
            }
            else if(Rdb_AesCBCEncrypt.Checked)
            {
                try
                {
                    AESCBCModeCryptography Aes = new AESCBCModeCryptography();
                    var Enc = Aes.Encrypt(Txt_PublicKey.Text, Txt_PlainText.Text);
                    Txt_CipherText.Text = Enc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetErrorMessage());
                }
            }
        }

        private  void Btn_Decrypt_Click(object sender, EventArgs e)
        {
            if (Rdb_RsaEncrypt.Checked)
                Txt_PlainText.Text = decrypt1(Txt_CipherText.Text, Txt_PrivateKey.Text);
            else if(Rdb_AesECBEncrypt.Checked)
            {
                try
                {
                    AESCryptography Aes = new AESCryptography();
                    var Dec =  Aes.DecryptAsync(Txt_PublicKey.Text ,Txt_CipherText.Text);
                    Txt_PlainText.Text = Dec;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetErrorMessage());
                }
            }
            else if (Rdb_AesCBCEncrypt.Checked)
            {
                try
                {
                    AESCBCModeCryptography Aes = new AESCBCModeCryptography();
                    var Dec = Aes.Decrypt(Txt_PublicKey.Text, Txt_CipherText.Text);
                    Txt_PlainText.Text = Dec;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetErrorMessage());
                }
            }
        }


        private AsymmetricCipherKeyPair GenerateKeys()
        {
            var kpgen = new RsaKeyPairGenerator();
            kpgen.Init(new KeyGenerationParameters(new SecureRandom(new CryptoApiRandomGenerator()), 2048));


            var keyPair = kpgen.GenerateKeyPair();
            return keyPair;
        }

        private string EncryptData(string plaintext)
        {
            var bytesToEncrypt = StringHelper.StringToByteArray(plaintext);
            var keyPair = GetPublicKey(Txt_PublicKey.Text);


            var engine = new RsaEngine();
            engine.Init(true, keyPair);


            var encrypted = engine.ProcessBlock(bytesToEncrypt, 0, bytesToEncrypt.Length);
            var cryptMessage = StringHelper.GetBase64(encrypted);

            return cryptMessage;
        }

        private string DecryptData(string ciphertext)
        {
            var bytesToDecrypt = StringHelper.Base64ToByteArray(ciphertext);
            var keyPair = GetPrivateKey(Txt_PrivateKey.Text);



            var decryptEngine = new RsaEngine();
            decryptEngine.Init(false, keyPair.Private);

            var decrypted = decryptEngine.ProcessBlock(bytesToDecrypt, 0, bytesToDecrypt.Length);
            var decryptedMessage = StringHelper.ByteArrayToString(decrypted);
            return decryptedMessage;
        }

        public String GetStringKey(AsymmetricCipherKeyPair keys, bool isprivate)
        {
            TextWriter textWriter = new StringWriter();
            PemWriter pemWriter = new PemWriter(textWriter);
            if (isprivate)
                pemWriter.WriteObject(keys.Private);
            else
                pemWriter.WriteObject(keys.Public);

            pemWriter.Writer.Flush();
            return textWriter.ToString();
        }


        private AsymmetricCipherKeyPair GetPrivateKey(string key)
        {
            try
            {
                var bytearray = StringHelper.StringToByteArray(key);
                MemoryStream stream = new MemoryStream(bytearray);
                StreamReader reader = new StreamReader(stream);
                var keyPair = (AsymmetricCipherKeyPair)new Org.BouncyCastle.OpenSsl.PemReader(reader).ReadObject();

                return keyPair;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        private AsymmetricKeyParameter GetPublicKey(string key)
        {
            try
            {
                var bytearray = StringHelper.StringToByteArray(key);
                MemoryStream stream = new MemoryStream(bytearray);
                StreamReader reader = new StreamReader(stream);
                var keyPair = (AsymmetricKeyParameter)new Org.BouncyCastle.OpenSsl.PemReader(reader).ReadObject();
                return keyPair;
            }
            catch
            {
                return null;
            }
        }

        ///
        private string encrypt(string plainText, string filepath)
        {
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);

            PemReader pr = new PemReader(
                (StreamReader)File.OpenText(filepath)
            );
            RsaKeyParameters keys = (RsaKeyParameters)pr.ReadObject();


            OaepEncoding eng = new OaepEncoding(new RsaEngine());
            eng.Init(true, keys);

            int length = plainTextBytes.Length;
            int blockSize = eng.GetInputBlockSize();
            List<byte> cipherTextBytes = new List<byte>();
            for (int chunkPosition = 0;
                chunkPosition < length;
                chunkPosition += blockSize)
            {
                int chunkSize = Math.Min(blockSize, length - chunkPosition);
                cipherTextBytes.AddRange(eng.ProcessBlock(
                    plainTextBytes, chunkPosition, chunkSize
                ));
            }
            return Convert.ToBase64String(cipherTextBytes.ToArray());
        }

        private string decrypt(string cipherText, string filepath)
        {
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);

            PemReader pr = new PemReader(
                (StreamReader)File.OpenText(filepath)
            );
            AsymmetricCipherKeyPair keys = (AsymmetricCipherKeyPair)pr.ReadObject();


            OaepEncoding eng = new OaepEncoding(new RsaEngine());
            eng.Init(false, keys.Private);

            int length = cipherTextBytes.Length;
            int blockSize = eng.GetInputBlockSize();
            List<byte> plainTextBytes = new List<byte>();
            for (int chunkPosition = 0;
                chunkPosition < length;
                chunkPosition += blockSize)
            {
                int chunkSize = Math.Min(blockSize, length - chunkPosition);
                plainTextBytes.AddRange(eng.ProcessBlock(
                    cipherTextBytes, chunkPosition, chunkSize
                ));
            }
            return Encoding.UTF8.GetString(plainTextBytes.ToArray());
        }


        private string encrypt1(string plainText, string key)
        {           
            var plainTextBytes = StringHelper.StringToByteArray(plainText);
            var reader = StringHelper.StringToStreamReader(key);

            PemReader pr = new PemReader(reader);
            RsaKeyParameters keys = (RsaKeyParameters)pr.ReadObject();

            Pkcs1Encoding eng = new Pkcs1Encoding(new RsaEngine());
            // OaepEncoding eng = new OaepEncoding(new RsaEngine());
            eng.Init(true, keys);

            int length = plainTextBytes.Length;
            int blockSize = eng.GetInputBlockSize();
            List<byte> cipherTextBytes = new List<byte>();
            for (int chunkPosition = 0;
                chunkPosition < length;
                chunkPosition += blockSize)
            {
                int chunkSize = Math.Min(blockSize, length - chunkPosition);
                cipherTextBytes.AddRange(eng.ProcessBlock(
                    plainTextBytes, chunkPosition, chunkSize
                ));
            }
            return StringHelper.GetBase64(cipherTextBytes.ToArray());
        }

        private string decrypt1(string cipherText, string key)
        {
            byte[] cipherTextBytes = StringHelper.Base64ToByteArray(cipherText);
            var reader = StringHelper.StringToStreamReader(key);

            PemReader pr = new PemReader(reader);
            AsymmetricCipherKeyPair keys = (AsymmetricCipherKeyPair)pr.ReadObject();


            Pkcs1Encoding eng = new Pkcs1Encoding(new RsaEngine());

            //OaepEncoding eng = new OaepEncoding(new RsaEngine());
            eng.Init(false, keys.Private);

            int length = cipherTextBytes.Length;
            int blockSize = eng.GetInputBlockSize();
            List<byte> plainTextBytes = new List<byte>();
            for (int chunkPosition = 0;
                chunkPosition < length;
                chunkPosition += blockSize)
            {
                int chunkSize = Math.Min(blockSize, length - chunkPosition);
                plainTextBytes.AddRange(eng.ProcessBlock(
                    cipherTextBytes, chunkPosition, chunkSize
                ));
            }
            return StringHelper.ByteArrayToString(plainTextBytes.ToArray());
        }

        private string GenerateAesKey(bool isEcb)
        {
            if(isEcb)
            {
                AESCryptography aESCryptography = new AESCryptography();
                return aESCryptography.GenerateKey();
            }
            else
            {
                AESCBCModeCryptography aESCBCMode = new AESCBCModeCryptography();
                return aESCBCMode.GenerateKey();
            }
        }

        private void Rdb_RsaEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            Btn_GenerateKeys.PerformClick();
        }

        private void Rdb_AesEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            Btn_GenerateKeys.PerformClick();
        }

        private void Btn_GetBase64_Click(object sender, EventArgs e)
        {
            Txt_PublicKey.Text = StringHelper.GetBase64(Txt_PublicKey.Text);
        }

        private void Rdb_AesCCBEncrypt_CheckedChanged(object sender, EventArgs e)
        {
            Btn_GenerateKeys.PerformClick();
        }

        private void Frm_BouncyCastle_Load(object sender, EventArgs e)
        {
            Btn_GenerateKeys.PerformClick();
        }
    }

}

