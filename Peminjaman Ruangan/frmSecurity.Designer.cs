namespace Peminjaman_Ruangan
{
    partial class frmSecurity
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
            this.RequestPanel = new System.Windows.Forms.Panel();
            this.ImgLogo = new System.Windows.Forms.PictureBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.KtkSearch = new RectangleControl();
            this.RectangleSearchBar = new RectangleControl();
            this.rectangleControl1 = new RectangleControl();
            this.BtnQuit = new ImageButton();
            this.BtnProfile = new ImageButton();
            this.Rectangle = new RectangleControl();
            this.PanelAccount = new System.Windows.Forms.Panel();
            this.buttonLogOut = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).BeginInit();
            this.PanelAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // RequestPanel
            // 
            this.RequestPanel.AutoScroll = true;
            this.RequestPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.RequestPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestPanel.Location = new System.Drawing.Point(0, 281);
            this.RequestPanel.Name = "RequestPanel";
            this.RequestPanel.Size = new System.Drawing.Size(1350, 396);
            this.RequestPanel.TabIndex = 116;
            // 
            // ImgLogo
            // 
            this.ImgLogo.BackColor = System.Drawing.Color.White;
            this.ImgLogo.Image = global::Peminjaman_Ruangan.Properties.Resources.logoSmall;
            this.ImgLogo.Location = new System.Drawing.Point(0, 92);
            this.ImgLogo.Name = "ImgLogo";
            this.ImgLogo.Size = new System.Drawing.Size(191, 89);
            this.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgLogo.TabIndex = 114;
            this.ImgLogo.TabStop = false;
            // 
            // TxtSearch
            // 
            this.TxtSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.TxtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtSearch.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtSearch.ForeColor = System.Drawing.Color.Gray;
            this.TxtSearch.Location = new System.Drawing.Point(318, 215);
            this.TxtSearch.Name = "TxtSearch";
            this.TxtSearch.Size = new System.Drawing.Size(671, 29);
            this.TxtSearch.TabIndex = 119;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // BtnSearch
            // 
            this.BtnSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.BtnSearch.FlatAppearance.BorderSize = 0;
            this.BtnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSearch.Image = global::Peminjaman_Ruangan.Properties.Resources.Search2;
            this.BtnSearch.Location = new System.Drawing.Point(1004, 204);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(54, 52);
            this.BtnSearch.TabIndex = 118;
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // KtkSearch
            // 
            this.KtkSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.KtkSearch.BackColor = System.Drawing.Color.White;
            this.KtkSearch.Location = new System.Drawing.Point(305, 204);
            this.KtkSearch.Name = "KtkSearch";
            this.KtkSearch.Size = new System.Drawing.Size(701, 52);
            this.KtkSearch.TabIndex = 117;
            this.KtkSearch.Text = "rectangleControl2";
            // 
            // RectangleSearchBar
            // 
            this.RectangleSearchBar.BackColor = System.Drawing.Color.MidnightBlue;
            this.RectangleSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.RectangleSearchBar.Location = new System.Drawing.Point(0, 181);
            this.RectangleSearchBar.Name = "RectangleSearchBar";
            this.RectangleSearchBar.Size = new System.Drawing.Size(1350, 100);
            this.RectangleSearchBar.TabIndex = 113;
            this.RectangleSearchBar.Text = "rectangleControl1";
            // 
            // rectangleControl1
            // 
            this.rectangleControl1.BackColor = System.Drawing.Color.White;
            this.rectangleControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rectangleControl1.Location = new System.Drawing.Point(0, 92);
            this.rectangleControl1.Name = "rectangleControl1";
            this.rectangleControl1.Size = new System.Drawing.Size(1350, 89);
            this.rectangleControl1.TabIndex = 115;
            this.rectangleControl1.Text = "rectangleControl1";
            // 
            // BtnQuit
            // 
            this.BtnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnQuit.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnQuit.FlatAppearance.BorderSize = 0;
            this.BtnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuit.Image = global::Peminjaman_Ruangan.Properties.Resources.Quit;
            this.BtnQuit.Location = new System.Drawing.Point(1281, 27);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(45, 45);
            this.BtnQuit.TabIndex = 112;
            this.BtnQuit.UseVisualStyleBackColor = false;
            this.BtnQuit.Click += new System.EventHandler(this.BtnQuit_Click);
            // 
            // BtnProfile
            // 
            this.BtnProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnProfile.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnProfile.FlatAppearance.BorderSize = 0;
            this.BtnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnProfile.Image = global::Peminjaman_Ruangan.Properties.Resources.user;
            this.BtnProfile.Location = new System.Drawing.Point(1220, 27);
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.Size = new System.Drawing.Size(45, 45);
            this.BtnProfile.TabIndex = 111;
            this.BtnProfile.UseVisualStyleBackColor = false;
            this.BtnProfile.Click += new System.EventHandler(this.BtnProfile_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.BackColor = System.Drawing.Color.MidnightBlue;
            this.Rectangle.Dock = System.Windows.Forms.DockStyle.Top;
            this.Rectangle.Location = new System.Drawing.Point(0, 0);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(1350, 92);
            this.Rectangle.TabIndex = 108;
            this.Rectangle.Text = "rectangleControl1";
            // 
            // PanelAccount
            // 
            this.PanelAccount.BackColor = System.Drawing.Color.White;
            this.PanelAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelAccount.Controls.Add(this.buttonLogOut);
            this.PanelAccount.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelAccount.Location = new System.Drawing.Point(976, 92);
            this.PanelAccount.Name = "PanelAccount";
            this.PanelAccount.Size = new System.Drawing.Size(289, 57);
            this.PanelAccount.TabIndex = 120;
            this.PanelAccount.Visible = false;
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.BackColor = System.Drawing.Color.Navy;
            this.buttonLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLogOut.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLogOut.ForeColor = System.Drawing.Color.White;
            this.buttonLogOut.Location = new System.Drawing.Point(26, 8);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(234, 38);
            this.buttonLogOut.TabIndex = 0;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = false;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // frmSecurity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 677);
            this.Controls.Add(this.PanelAccount);
            this.Controls.Add(this.ImgLogo);
            this.Controls.Add(this.RequestPanel);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.KtkSearch);
            this.Controls.Add(this.RectangleSearchBar);
            this.Controls.Add(this.rectangleControl1);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnProfile);
            this.Controls.Add(this.Rectangle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmSecurity";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peminjaman Ruangan Universitas Pelita Harapan Medan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSecurity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).EndInit();
            this.PanelAccount.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel RequestPanel;
        private RectangleControl rectangleControl1;
        private ImageButton BtnProfile;
        private RectangleControl Rectangle;
        private RectangleControl RectangleSearchBar;
        private ImageButton BtnQuit;
        private System.Windows.Forms.PictureBox ImgLogo;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Button BtnSearch;
        private RectangleControl KtkSearch;
        private System.Windows.Forms.Panel PanelAccount;
        private System.Windows.Forms.Button buttonLogOut;
    }
}