namespace RSAEncryption
{
    partial class Frm_BouncyCastle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Btn_GenerateKeys = new System.Windows.Forms.Button();
            this.Btn_Encrypt = new System.Windows.Forms.Button();
            this.Btn_Decrypt = new System.Windows.Forms.Button();
            this.Txt_CipherText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_PlainText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_PrivateKey = new System.Windows.Forms.TextBox();
            this.lbl_PrivateKey = new System.Windows.Forms.Label();
            this.Txt_PublicKey = new System.Windows.Forms.TextBox();
            this.lbl_PublicKey = new System.Windows.Forms.Label();
            this.Rdb_AesEncrypt = new System.Windows.Forms.RadioButton();
            this.Rdb_RsaEncrypt = new System.Windows.Forms.RadioButton();
            this.Btn_GetBase64 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_GenerateKeys
            // 
            this.Btn_GenerateKeys.Location = new System.Drawing.Point(12, 21);
            this.Btn_GenerateKeys.Name = "Btn_GenerateKeys";
            this.Btn_GenerateKeys.Size = new System.Drawing.Size(106, 23);
            this.Btn_GenerateKeys.TabIndex = 1;
            this.Btn_GenerateKeys.Text = "Generate Key";
            this.Btn_GenerateKeys.UseVisualStyleBackColor = true;
            this.Btn_GenerateKeys.Click += new System.EventHandler(this.Btn_GenerateKeys_Click);
            // 
            // Btn_Encrypt
            // 
            this.Btn_Encrypt.Location = new System.Drawing.Point(12, 50);
            this.Btn_Encrypt.Name = "Btn_Encrypt";
            this.Btn_Encrypt.Size = new System.Drawing.Size(106, 23);
            this.Btn_Encrypt.TabIndex = 2;
            this.Btn_Encrypt.Text = "Encrypt";
            this.Btn_Encrypt.UseVisualStyleBackColor = true;
            this.Btn_Encrypt.Click += new System.EventHandler(this.Btn_Encrypt_Click);
            // 
            // Btn_Decrypt
            // 
            this.Btn_Decrypt.Location = new System.Drawing.Point(12, 79);
            this.Btn_Decrypt.Name = "Btn_Decrypt";
            this.Btn_Decrypt.Size = new System.Drawing.Size(106, 23);
            this.Btn_Decrypt.TabIndex = 3;
            this.Btn_Decrypt.Text = "Decrypt";
            this.Btn_Decrypt.UseVisualStyleBackColor = true;
            this.Btn_Decrypt.Click += new System.EventHandler(this.Btn_Decrypt_Click);
            // 
            // Txt_CipherText
            // 
            this.Txt_CipherText.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Txt_CipherText.Location = new System.Drawing.Point(219, 294);
            this.Txt_CipherText.Multiline = true;
            this.Txt_CipherText.Name = "Txt_CipherText";
            this.Txt_CipherText.Size = new System.Drawing.Size(339, 57);
            this.Txt_CipherText.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(121, 311);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 18;
            this.label2.Text = "Cipher Text";
            // 
            // Txt_PlainText
            // 
            this.Txt_PlainText.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Txt_PlainText.Location = new System.Drawing.Point(219, 212);
            this.Txt_PlainText.Multiline = true;
            this.Txt_PlainText.Name = "Txt_PlainText";
            this.Txt_PlainText.Size = new System.Drawing.Size(339, 57);
            this.Txt_PlainText.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(128, 229);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 16;
            this.label1.Text = "Plain Text";
            // 
            // Txt_PrivateKey
            // 
            this.Txt_PrivateKey.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Txt_PrivateKey.Location = new System.Drawing.Point(219, 115);
            this.Txt_PrivateKey.Multiline = true;
            this.Txt_PrivateKey.Name = "Txt_PrivateKey";
            this.Txt_PrivateKey.Size = new System.Drawing.Size(339, 61);
            this.Txt_PrivateKey.TabIndex = 15;
            // 
            // lbl_PrivateKey
            // 
            this.lbl_PrivateKey.AutoSize = true;
            this.lbl_PrivateKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_PrivateKey.Location = new System.Drawing.Point(128, 133);
            this.lbl_PrivateKey.Name = "lbl_PrivateKey";
            this.lbl_PrivateKey.Size = new System.Drawing.Size(89, 19);
            this.lbl_PrivateKey.TabIndex = 14;
            this.lbl_PrivateKey.Text = "Private Key";
            // 
            // Txt_PublicKey
            // 
            this.Txt_PublicKey.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Txt_PublicKey.Location = new System.Drawing.Point(219, 16);
            this.Txt_PublicKey.Multiline = true;
            this.Txt_PublicKey.Name = "Txt_PublicKey";
            this.Txt_PublicKey.Size = new System.Drawing.Size(339, 57);
            this.Txt_PublicKey.TabIndex = 13;
            // 
            // lbl_PublicKey
            // 
            this.lbl_PublicKey.AutoSize = true;
            this.lbl_PublicKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_PublicKey.Location = new System.Drawing.Point(135, 32);
            this.lbl_PublicKey.Name = "lbl_PublicKey";
            this.lbl_PublicKey.Size = new System.Drawing.Size(81, 19);
            this.lbl_PublicKey.TabIndex = 12;
            this.lbl_PublicKey.Text = "Public Key";
            // 
            // Rdb_AesEncrypt
            // 
            this.Rdb_AesEncrypt.AutoSize = true;
            this.Rdb_AesEncrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rdb_AesEncrypt.Location = new System.Drawing.Point(65, 113);
            this.Rdb_AesEncrypt.Name = "Rdb_AesEncrypt";
            this.Rdb_AesEncrypt.Size = new System.Drawing.Size(46, 17);
            this.Rdb_AesEncrypt.TabIndex = 21;
            this.Rdb_AesEncrypt.TabStop = true;
            this.Rdb_AesEncrypt.Text = "AES";
            this.Rdb_AesEncrypt.UseVisualStyleBackColor = true;
            this.Rdb_AesEncrypt.CheckedChanged += new System.EventHandler(this.Rdb_AesEncrypt_CheckedChanged);
            // 
            // Rdb_RsaEncrypt
            // 
            this.Rdb_RsaEncrypt.AutoSize = true;
            this.Rdb_RsaEncrypt.Checked = true;
            this.Rdb_RsaEncrypt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Rdb_RsaEncrypt.Location = new System.Drawing.Point(12, 113);
            this.Rdb_RsaEncrypt.Name = "Rdb_RsaEncrypt";
            this.Rdb_RsaEncrypt.Size = new System.Drawing.Size(47, 17);
            this.Rdb_RsaEncrypt.TabIndex = 20;
            this.Rdb_RsaEncrypt.TabStop = true;
            this.Rdb_RsaEncrypt.Text = "RSA";
            this.Rdb_RsaEncrypt.UseVisualStyleBackColor = true;
            this.Rdb_RsaEncrypt.CheckedChanged += new System.EventHandler(this.Rdb_RsaEncrypt_CheckedChanged);
            // 
            // Btn_GetBase64
            // 
            this.Btn_GetBase64.Location = new System.Drawing.Point(219, 79);
            this.Btn_GetBase64.Name = "Btn_GetBase64";
            this.Btn_GetBase64.Size = new System.Drawing.Size(75, 23);
            this.Btn_GetBase64.TabIndex = 22;
            this.Btn_GetBase64.Text = "Base64";
            this.Btn_GetBase64.UseVisualStyleBackColor = true;
            this.Btn_GetBase64.Click += new System.EventHandler(this.Btn_GetBase64_Click);
            // 
            // Frm_BouncyCastle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 419);
            this.Controls.Add(this.Btn_GetBase64);
            this.Controls.Add(this.Rdb_AesEncrypt);
            this.Controls.Add(this.Rdb_RsaEncrypt);
            this.Controls.Add(this.Txt_CipherText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_PlainText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Txt_PrivateKey);
            this.Controls.Add(this.lbl_PrivateKey);
            this.Controls.Add(this.Txt_PublicKey);
            this.Controls.Add(this.lbl_PublicKey);
            this.Controls.Add(this.Btn_Decrypt);
            this.Controls.Add(this.Btn_Encrypt);
            this.Controls.Add(this.Btn_GenerateKeys);
            this.Name = "Frm_BouncyCastle";
            this.Text = "Frm_BouncyCastle";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Btn_GenerateKeys;
        private System.Windows.Forms.Button Btn_Encrypt;
        private System.Windows.Forms.Button Btn_Decrypt;
        private System.Windows.Forms.TextBox Txt_CipherText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_PlainText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_PrivateKey;
        private System.Windows.Forms.Label lbl_PrivateKey;
        private System.Windows.Forms.TextBox Txt_PublicKey;
        private System.Windows.Forms.Label lbl_PublicKey;
        private System.Windows.Forms.RadioButton Rdb_AesEncrypt;
        private System.Windows.Forms.RadioButton Rdb_RsaEncrypt;
        private System.Windows.Forms.Button Btn_GetBase64;
    }
}