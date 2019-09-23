namespace RSAEncryption
{
    partial class Frm_AddDateToDb
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
            this.components = new System.ComponentModel.Container();
            this.timer_CurrentTime = new System.Windows.Forms.Timer(this.components);
            this.timer_BulkAdd = new System.Windows.Forms.Timer(this.components);
            this.Btn_Start = new System.Windows.Forms.Button();
            this.Btn_Stop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer_CurrentTime
            // 
            this.timer_CurrentTime.Interval = 50;
            this.timer_CurrentTime.Tick += new System.EventHandler(this.Timer_CurrentTime_Tick);
            // 
            // timer_BulkAdd
            // 
            this.timer_BulkAdd.Interval = 5000;
            this.timer_BulkAdd.Tick += new System.EventHandler(this.Timer_BulkAdd_Tick);
            // 
            // Btn_Start
            // 
            this.Btn_Start.Location = new System.Drawing.Point(50, 28);
            this.Btn_Start.Name = "Btn_Start";
            this.Btn_Start.Size = new System.Drawing.Size(75, 23);
            this.Btn_Start.TabIndex = 0;
            this.Btn_Start.Text = "Start";
            this.Btn_Start.UseVisualStyleBackColor = true;
            this.Btn_Start.Click += new System.EventHandler(this.Btn_Start_Click);
            // 
            // Btn_Stop
            // 
            this.Btn_Stop.Location = new System.Drawing.Point(50, 57);
            this.Btn_Stop.Name = "Btn_Stop";
            this.Btn_Stop.Size = new System.Drawing.Size(75, 23);
            this.Btn_Stop.TabIndex = 1;
            this.Btn_Stop.Text = "Stop";
            this.Btn_Stop.UseVisualStyleBackColor = true;
            this.Btn_Stop.Click += new System.EventHandler(this.Btn_Stop_Click);
            // 
            // Frm_AddDateToDb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 259);
            this.Controls.Add(this.Btn_Stop);
            this.Controls.Add(this.Btn_Start);
            this.Name = "Frm_AddDateToDb";
            this.Text = "Frm_AddDateToDb";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer_CurrentTime;
        private System.Windows.Forms.Timer timer_BulkAdd;
        private System.Windows.Forms.Button Btn_Start;
        private System.Windows.Forms.Button Btn_Stop;
    }
}