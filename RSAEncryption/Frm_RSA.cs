using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Windows.Forms;
using Core.EncryptionTools;
using System.Threading.Tasks;
using System.IO;

namespace RSAEncryption
{
    public partial class Frm_RSA : Form
    {
        RSACryptography Rsa = null;
        public Frm_RSA()
        {
            InitializeComponent();
        }

        private async void Btn_Encrypt_ClickAsync(object sender, EventArgs e)
        {
            if (Rdb_RsaEncrypt.Checked)
            {
                var Enc = await Rsa.EncryptAsync(Txt_PublicKey.Text, Txt_PlainText.Text);
                Txt_CipherText.Text = Enc;
            }
            else
            {
                try
                {
                    AESCryptography Aes = new AESCryptography(Key: Txt_PublicKey.Text);
                    var Enc = await Aes.EncryptAsync(Txt_PlainText.Text);
                    Txt_CipherText.Text = Enc;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.GetErrorMessage());
                }
                
            }

        }

        private void Btn_GenerateKeys_Click(object sender, EventArgs e)
        {
            Rsa = new RSACryptography(Enums.RSAKeySize.Key2048);
            var keys = Rsa.GenerateKeys();
            Txt_PublicKey.Text = keys.PublicKey;
            Txt_PrivateKey.Text = keys.PrivateKey;
        }

        private async void Btn_Decrypt_Click(object sender, EventArgs e)
        {
            if (Rdb_RsaEncrypt.Checked)
            {
                var Dec = await Rsa.DecryptAsync(Txt_PrivateKey.Text, Txt_CipherText.Text);
                Txt_PlainText.Text = Dec;
            }
            else
            {
                try
                {
                    AESCryptography Aes = new AESCryptography(Key: Txt_PublicKey.Text);
                    var Dec = await Aes.DecryptAsync(Txt_CipherText.Text);
                    Txt_PlainText.Text = Dec;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.GetErrorMessage());
                }
            }
        }

        private void Btn_SavePublic_Click(object sender, EventArgs e)
        {
            if (Txt_PublicKey.Text.Trim().Length > 0)
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName,Txt_PublicKey.Text);
                }
        }

        private void Btn_SavePrivateKey_Click(object sender, EventArgs e)
        {
            if (Txt_PrivateKey.Text.Trim().Length > 0)
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog1.FileName, Txt_PrivateKey.Text);
                }
        }

        private void Btn_LoadPublicKey_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                Txt_PublicKey.Text = File.ReadAllText(openFileDialog1.FileName);
        }

        private void Btn_LoadPrivateKey_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Txt_PrivateKey.Text = File.ReadAllText(openFileDialog1.FileName);
            }
        }

        private void Frm_RSA_Load(object sender, EventArgs e)
        {
            Rsa = new RSACryptography(Enums.RSAKeySize.Key2048);
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var d = DateTime.Now.ToString();
            var t = StringHelper.GetBase64(d);
            MessageBox.Show(t);
        }
    }
}
