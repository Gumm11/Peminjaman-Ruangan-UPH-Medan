namespace Peminjaman_Ruangan
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.LblPeminjaman = new System.Windows.Forms.Label();
            this.LblWelcome = new System.Windows.Forms.Label();
            this.TxtEmail = new System.Windows.Forms.TextBox();
            this.KtkEmail = new System.Windows.Forms.Panel();
            this.LblEmail = new System.Windows.Forms.Label();
            this.ImgLogo = new System.Windows.Forms.PictureBox();
            this.BtnLogin = new System.Windows.Forms.Button();
            this.PanelMain = new System.Windows.Forms.Panel();
            this.BtnQuit = new System.Windows.Forms.Button();
            this.KtkEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).BeginInit();
            this.PanelMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // LblPeminjaman
            // 
            this.LblPeminjaman.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblPeminjaman.AutoSize = true;
            this.LblPeminjaman.BackColor = System.Drawing.Color.White;
            this.LblPeminjaman.Font = new System.Drawing.Font("Roboto", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPeminjaman.ForeColor = System.Drawing.Color.MidnightBlue;
            this.LblPeminjaman.Location = new System.Drawing.Point(92, 0);
            this.LblPeminjaman.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblPeminjaman.Name = "LblPeminjaman";
            this.LblPeminjaman.Size = new System.Drawing.Size(959, 44);
            this.LblPeminjaman.TabIndex = 2;
            this.LblPeminjaman.Text = "Peminjaman Ruangan Universitas Pelita Harapan Medan";
            this.LblPeminjaman.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LblWelcome
            // 
            this.LblWelcome.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.LblWelcome.AutoSize = true;
            this.LblWelcome.Font = new System.Drawing.Font("Roboto", 16F);
            this.LblWelcome.ForeColor = System.Drawing.Color.Gray;
            this.LblWelcome.Location = new System.Drawing.Point(275, 75);
            this.LblWelcome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblWelcome.Name = "LblWelcome";
            this.LblWelcome.Size = new System.Drawing.Size(554, 33);
            this.LblWelcome.TabIndex = 3;
            this.LblWelcome.Text = "Welcome back! Please login to your account.";
            // 
            // TxtEmail
            // 
            this.TxtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtEmail.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtEmail.Location = new System.Drawing.Point(23, 42);
            this.TxtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.TxtEmail.Name = "TxtEmail";
            this.TxtEmail.Size = new System.Drawing.Size(463, 20);
            this.TxtEmail.TabIndex = 4;
            // 
            // KtkEmail
            // 
            this.KtkEmail.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.KtkEmail.Controls.Add(this.LblEmail);
            this.KtkEmail.Controls.Add(this.TxtEmail);
            this.KtkEmail.Location = new System.Drawing.Point(329, 179);
            this.KtkEmail.Margin = new System.Windows.Forms.Padding(4);
            this.KtkEmail.Name = "KtkEmail";
            this.KtkEmail.Size = new System.Drawing.Size(507, 80);
            this.KtkEmail.TabIndex = 5;
            this.KtkEmail.Paint += new System.Windows.Forms.PaintEventHandler(this.KtkEmail_Paint);
            // 
            // LblEmail
            // 
            this.LblEmail.AutoSize = true;
            this.LblEmail.Font = new System.Drawing.Font("Roboto", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblEmail.ForeColor = System.Drawing.Color.Gray;
            this.LblEmail.Location = new System.Drawing.Point(19, 16);
            this.LblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LblEmail.Name = "LblEmail";
            this.LblEmail.Size = new System.Drawing.Size(118, 20);
            this.LblEmail.TabIndex = 5;
            this.LblEmail.Text = "Email Address";
            // 
            // ImgLogo
            // 
            this.ImgLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ImgLogo.Image = ((System.Drawing.Image)(resources.GetObject("ImgLogo.Image")));
            this.ImgLogo.ImageLocation = "";
            this.ImgLogo.Location = new System.Drawing.Point(0, 0);
            this.ImgLogo.Margin = new System.Windows.Forms.Padding(4);
            this.ImgLogo.Name = "ImgLogo";
            this.ImgLogo.Size = new System.Drawing.Size(1179, 255);
            this.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.ImgLogo.TabIndex = 0;
            this.ImgLogo.TabStop = false;
            // 
            // BtnLogin
            // 
            this.BtnLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnLogin.BackColor = System.Drawing.Color.MediumBlue;
            this.BtnLogin.FlatAppearance.BorderSize = 0;
            this.BtnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnLogin.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnLogin.ForeColor = System.Drawing.Color.White;
            this.BtnLogin.Location = new System.Drawing.Point(329, 400);
            this.BtnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.BtnLogin.Name = "BtnLogin";
            this.BtnLogin.Size = new System.Drawing.Size(229, 62);
            this.BtnLogin.TabIndex = 8;
            this.BtnLogin.Text = "Login";
            this.BtnLogin.UseVisualStyleBackColor = false;
            this.BtnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.LblPeminjaman);
            this.PanelMain.Controls.Add(this.BtnQuit);
            this.PanelMain.Controls.Add(this.LblWelcome);
            this.PanelMain.Controls.Add(this.BtnLogin);
            this.PanelMain.Controls.Add(this.KtkEmail);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 255);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(4);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(1179, 534);
            this.PanelMain.TabIndex = 12;
            // 
            // BtnQuit
            // 
            this.BtnQuit.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuit.Font = new System.Drawing.Font("Roboto", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnQuit.Location = new System.Drawing.Point(607, 400);
            this.BtnQuit.Margin = new System.Windows.Forms.Padding(4);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(229, 62);
            this.BtnQuit.TabIndex = 9;
            this.BtnQuit.Text = "Quit";
            this.BtnQuit.UseVisualStyleBackColor = true;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1179, 789);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.ImgLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmLogin";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peminjaman Ruangan Universitas Pelita Harapan Medan";
            this.KtkEmail.ResumeLayout(false);
            this.KtkEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).EndInit();
            this.PanelMain.ResumeLayout(false);
            this.PanelMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImgLogo;
        private System.Windows.Forms.Label LblPeminjaman;
        private System.Windows.Forms.Label LblWelcome;
        private System.Windows.Forms.TextBox TxtEmail;
        private System.Windows.Forms.Panel KtkEmail;
        private System.Windows.Forms.Label LblEmail;
        private System.Windows.Forms.Button BtnLogin;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Button BtnQuit;
    }
}

