namespace RSAEncryption
{
    partial class Frm_RSA
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
            this.lbl_PublicKey = new System.Windows.Forms.Label();
            this.Txt_PublicKey = new System.Windows.Forms.TextBox();
            this.Txt_PrivateKey = new System.Windows.Forms.TextBox();
            this.lbl_PrivateKey = new System.Windows.Forms.Label();
            this.Btn_LoadPublicKey = new System.Windows.Forms.Button();
            this.Btn_LoadPrivateKey = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_PlainText = new System.Windows.Forms.TextBox();
            this.Txt_CipherText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_Encrypt = new System.Windows.Forms.Button();
            this.Btn_Decrypt = new System.Windows.Forms.Button();
            this.Btn_GenerateKeys = new System.Windows.Forms.Button();
            this.Btn_SavePublic = new System.Windows.Forms.Button();
            this.Btn_SavePrivateKey = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Rdb_RsaEncrypt = new System.Windows.Forms.RadioButton();
            this.Rdb_AesEncrypt = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lbl_PublicKey
            // 
            this.lbl_PublicKey.AutoSize = true;
            this.lbl_PublicKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_PublicKey.Location = new System.Drawing.Point(29, 29);
            this.lbl_PublicKey.Name = "lbl_PublicKey";
            this.lbl_PublicKey.Size = new System.Drawing.Size(81, 19);
            this.lbl_PublicKey.TabIndex = 0;
            this.lbl_PublicKey.Text = "Public Key";
            // 
            // Txt_PublicKey
            // 
            this.Txt_PublicKey.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Txt_PublicKey.Location = new System.Drawing.Point(113, 13);
            this.Txt_PublicKey.Multiline = true;
            this.Txt_PublicKey.Name = "Txt_PublicKey";
            this.Txt_PublicKey.Size = new System.Drawing.Size(339, 57);
            this.Txt_PublicKey.TabIndex = 1;
            // 
            // Txt_PrivateKey
            // 
            this.Txt_PrivateKey.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Txt_PrivateKey.Location = new System.Drawing.Point(113, 112);
            this.Txt_PrivateKey.Multiline = true;
            this.Txt_PrivateKey.Name = "Txt_PrivateKey";
            this.Txt_PrivateKey.Size = new System.Drawing.Size(339, 61);
            this.Txt_PrivateKey.TabIndex = 3;
            // 
            // lbl_PrivateKey
            // 
            this.lbl_PrivateKey.AutoSize = true;
            this.lbl_PrivateKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lbl_PrivateKey.Location = new System.Drawing.Point(22, 130);
            this.lbl_PrivateKey.Name = "lbl_PrivateKey";
            this.lbl_PrivateKey.Size = new System.Drawing.Size(89, 19);
            this.lbl_PrivateKey.TabIndex = 2;
            this.lbl_PrivateKey.Text = "Private Key";
            // 
            // Btn_LoadPublicKey
            // 
            this.Btn_LoadPublicKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_LoadPublicKey.Location = new System.Drawing.Point(459, 11);
            this.Btn_LoadPublicKey.Name = "Btn_LoadPublicKey";
            this.Btn_LoadPublicKey.Size = new System.Drawing.Size(135, 27);
            this.Btn_LoadPublicKey.TabIndex = 4;
            this.Btn_LoadPublicKey.Text = "Load Public Key";
            this.Btn_LoadPublicKey.UseVisualStyleBackColor = true;
            this.Btn_LoadPublicKey.Click += new System.EventHandler(this.Btn_LoadPublicKey_Click);
            // 
            // Btn_LoadPrivateKey
            // 
            this.Btn_LoadPrivateKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_LoadPrivateKey.Location = new System.Drawing.Point(459, 111);
            this.Btn_LoadPrivateKey.Name = "Btn_LoadPrivateKey";
            this.Btn_LoadPrivateKey.Size = new System.Drawing.Size(138, 27);
            this.Btn_LoadPrivateKey.TabIndex = 5;
            this.Btn_LoadPrivateKey.Text = "Load Private Key";
            this.Btn_LoadPrivateKey.UseVisualStyleBackColor = true;
            this.Btn_LoadPrivateKey.Click += new System.EventHandler(this.Btn_LoadPrivateKey_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.Location = new System.Drawing.Point(22, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 19);
            this.label1.TabIndex = 8;
            this.label1.Text = "Plain Text";
            // 
            // Txt_PlainText
            // 
            this.Txt_PlainText.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Txt_PlainText.Location = new System.Drawing.Point(113, 209);
            this.Txt_PlainText.Multiline = true;
            this.Txt_PlainText.Name = "Txt_PlainText";
            this.Txt_PlainText.Size = new System.Drawing.Size(339, 57);
            this.Txt_PlainText.TabIndex = 9;
            // 
            // Txt_CipherText
            // 
            this.Txt_CipherText.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Txt_CipherText.Location = new System.Drawing.Point(113, 291);
            this.Txt_CipherText.Multiline = true;
            this.Txt_CipherText.Name = "Txt_CipherText";
            this.Txt_CipherText.Size = new System.Drawing.Size(339, 57);
            this.Txt_CipherText.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(15, 308);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cipher Text";
            // 
            // Btn_Encrypt
            // 
            this.Btn_Encrypt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Encrypt.Location = new System.Drawing.Point(458, 226);
            this.Btn_Encrypt.Name = "Btn_Encrypt";
            this.Btn_Encrypt.Size = new System.Drawing.Size(126, 26);
            this.Btn_Encrypt.TabIndex = 12;
            this.Btn_Encrypt.Text = "Encrypt Data";
            this.Btn_Encrypt.UseVisualStyleBackColor = true;
            this.Btn_Encrypt.Click += new System.EventHandler(this.Btn_Encrypt_ClickAsync);
            // 
            // Btn_Decrypt
            // 
            this.Btn_Decrypt.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_Decrypt.Location = new System.Drawing.Point(458, 308);
            this.Btn_Decrypt.Name = "Btn_Decrypt";
            this.Btn_Decrypt.Size = new System.Drawing.Size(126, 26);
            this.Btn_Decrypt.TabIndex = 13;
            this.Btn_Decrypt.Text = "Decrypt Data";
            this.Btn_Decrypt.UseVisualStyleBackColor = true;
            this.Btn_Decrypt.Click += new System.EventHandler(this.Btn_Decrypt_Click);
            // 
            // Btn_GenerateKeys
            // 
            this.Btn_GenerateKeys.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_GenerateKeys.Location = new System.Drawing.Point(458, 44);
            this.Btn_GenerateKeys.Name = "Btn_GenerateKeys";
            this.Btn_GenerateKeys.Size = new System.Drawing.Size(135, 27);
            this.Btn_GenerateKeys.TabIndex = 14;
            this.Btn_GenerateKeys.Text = "GenerateKey";
            this.Btn_GenerateKeys.UseVisualStyleBackColor = true;
            this.Btn_GenerateKeys.Click += new System.EventHandler(this.Btn_GenerateKeys_Click);
            // 
            // Btn_SavePublic
            // 
            this.Btn_SavePublic.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_SavePublic.Location = new System.Drawing.Point(595, 45);
            this.Btn_SavePublic.Name = "Btn_SavePublic";
            this.Btn_SavePublic.Size = new System.Drawing.Size(52, 26);
            this.Btn_SavePublic.TabIndex = 15;
            this.Btn_SavePublic.Text = "Save";
            this.Btn_SavePublic.UseVisualStyleBackColor = true;
            this.Btn_SavePublic.Click += new System.EventHandler(this.Btn_SavePublic_Click);
            // 
            // Btn_SavePrivateKey
            // 
            this.Btn_SavePrivateKey.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Btn_SavePrivateKey.Location = new System.Drawing.Point(459, 144);
            this.Btn_SavePrivateKey.Name = "Btn_SavePrivateKey";
            this.Btn_SavePrivateKey.Size = new System.Drawing.Size(138, 25);
            this.Btn_SavePrivateKey.TabIndex = 16;
            this.Btn_SavePrivateKey.Text = "Save";
            this.Btn_SavePrivateKey.UseVisualStyleBackColor = true;
            this.Btn_SavePrivateKey.Click += new System.EventHandler(this.Btn_SavePrivateKey_Click);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "*.Txt|*.Txt";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "*.Txt|*.Txt";
            // 
            // Rdb_RsaEncrypt
            // 
            this.Rdb_RsaEncrypt.AutoSize = true;
            this.Rdb_RsaEncrypt.Checked = true;
            this.Rdb_RsaEncrypt.Location = new System.Drawing.Point(461, 185);
            this.Rdb_RsaEncrypt.Name = "Rdb_RsaEncrypt";
            this.Rdb_RsaEncrypt.Size = new System.Drawing.Size(47, 17);
            this.Rdb_RsaEncrypt.TabIndex = 17;
            this.Rdb_RsaEncrypt.TabStop = true;
            this.Rdb_RsaEncrypt.Text = "RSA";
            this.Rdb_RsaEncrypt.UseVisualStyleBackColor = true;
            // 
            // Rdb_AesEncrypt
            // 
            this.Rdb_AesEncrypt.AutoSize = true;
            this.Rdb_AesEncrypt.Location = new System.Drawing.Point(514, 185);
            this.Rdb_AesEncrypt.Name = "Rdb_AesEncrypt";
            this.Rdb_AesEncrypt.Size = new System.Drawing.Size(46, 17);
            this.Rdb_AesEncrypt.TabIndex = 18;
            this.Rdb_AesEncrypt.TabStop = true;
            this.Rdb_AesEncrypt.Text = "AES";
            this.Rdb_AesEncrypt.UseVisualStyleBackColor = true;
            // 
            // Frm_RSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 390);
            this.Controls.Add(this.Rdb_AesEncrypt);
            this.Controls.Add(this.Rdb_RsaEncrypt);
            this.Controls.Add(this.Btn_SavePrivateKey);
            this.Controls.Add(this.Btn_SavePublic);
            this.Controls.Add(this.Btn_GenerateKeys);
            this.Controls.Add(this.Btn_Decrypt);
            this.Controls.Add(this.Btn_Encrypt);
            this.Controls.Add(this.Txt_CipherText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Txt_PlainText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Btn_LoadPrivateKey);
            this.Controls.Add(this.Btn_LoadPublicKey);
            this.Controls.Add(this.Txt_PrivateKey);
            this.Controls.Add(this.lbl_PrivateKey);
            this.Controls.Add(this.Txt_PublicKey);
            this.Controls.Add(this.lbl_PublicKey);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_RSA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RSA";
            this.Load += new System.EventHandler(this.Frm_RSA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_PublicKey;
        private System.Windows.Forms.TextBox Txt_PublicKey;
        private System.Windows.Forms.TextBox Txt_PrivateKey;
        private System.Windows.Forms.Label lbl_PrivateKey;
        private System.Windows.Forms.Button Btn_LoadPublicKey;
        private System.Windows.Forms.Button Btn_LoadPrivateKey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_PlainText;
        private System.Windows.Forms.TextBox Txt_CipherText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_Encrypt;
        private System.Windows.Forms.Button Btn_Decrypt;
        private System.Windows.Forms.Button Btn_GenerateKeys;
        private System.Windows.Forms.Button Btn_SavePublic;
        private System.Windows.Forms.Button Btn_SavePrivateKey;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RadioButton Rdb_RsaEncrypt;
        private System.Windows.Forms.RadioButton Rdb_AesEncrypt;
    }
}

