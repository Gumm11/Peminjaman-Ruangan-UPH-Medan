namespace Peminjaman_Ruangan
{
    partial class frmOTP
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
            this.CountdownLabel = new System.Windows.Forms.Label();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.ResendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputKodeOTP = new System.Windows.Forms.TextBox();
            this.CountdownTimer = new System.Windows.Forms.Timer(this.components);
            this.BackButton = new System.Windows.Forms.Button();
            this.imageButton1 = new ImageButton();
            this.SuspendLayout();
            // 
            // CountdownLabel
            // 
            this.CountdownLabel.AutoSize = true;
            this.CountdownLabel.Location = new System.Drawing.Point(368, 128);
            this.CountdownLabel.Name = "CountdownLabel";
            this.CountdownLabel.Size = new System.Drawing.Size(0, 13);
            this.CountdownLabel.TabIndex = 9;
            // 
            // SubmitButton
            // 
            this.SubmitButton.BackColor = System.Drawing.Color.DarkBlue;
            this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SubmitButton.ForeColor = System.Drawing.Color.White;
            this.SubmitButton.Location = new System.Drawing.Point(73, 102);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(100, 23);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = false;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // ResendButton
            // 
            this.ResendButton.BackColor = System.Drawing.Color.DarkBlue;
            this.ResendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ResendButton.ForeColor = System.Drawing.Color.White;
            this.ResendButton.Location = new System.Drawing.Point(368, 102);
            this.ResendButton.Name = "ResendButton";
            this.ResendButton.Size = new System.Drawing.Size(100, 23);
            this.ResendButton.TabIndex = 7;
            this.ResendButton.Text = "Resend Code";
            this.ResendButton.UseVisualStyleBackColor = false;
            this.ResendButton.Click += new System.EventHandler(this.ResendButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(68, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Masukan Kode";
            // 
            // InputKodeOTP
            // 
            this.InputKodeOTP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InputKodeOTP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputKodeOTP.Location = new System.Drawing.Point(73, 61);
            this.InputKodeOTP.Name = "InputKodeOTP";
            this.InputKodeOTP.Size = new System.Drawing.Size(395, 31);
            this.InputKodeOTP.TabIndex = 5;
            this.InputKodeOTP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.InputKodeOTP_KeyPress);
            // 
            // CountdownTimer
            // 
            this.CountdownTimer.Interval = 4000;
            this.CountdownTimer.Tick += new System.EventHandler(this.CountdownTimer_Tick);
            // 
            // BackButton
            // 
            this.BackButton.BackColor = System.Drawing.Color.DarkBlue;
            this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButton.ForeColor = System.Drawing.Color.White;
            this.BackButton.Location = new System.Drawing.Point(12, 12);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(41, 33);
            this.BackButton.TabIndex = 10;
            this.BackButton.Text = "<--";
            this.BackButton.UseVisualStyleBackColor = false;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // imageButton1
            // 
            this.imageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButton1.BackColor = System.Drawing.Color.DarkBlue;
            this.imageButton1.FlatAppearance.BorderSize = 0;
            this.imageButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton1.Image = global::Peminjaman_Ruangan.Properties.Resources.Quit;
            this.imageButton1.Location = new System.Drawing.Point(491, 12);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.Size = new System.Drawing.Size(33, 33);
            this.imageButton1.TabIndex = 37;
            this.imageButton1.UseVisualStyleBackColor = false;
            this.imageButton1.Click += new System.EventHandler(this.imageButton1_Click);
            // 
            // frmOTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(536, 161);
            this.Controls.Add(this.imageButton1);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CountdownLabel);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.ResendButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputKodeOTP);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmOTP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Please Input The Code";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CountdownLabel;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button ResendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputKodeOTP;
        private System.Windows.Forms.Timer CountdownTimer;
        private System.Windows.Forms.Button BackButton;
        private ImageButton imageButton1;
    }
}