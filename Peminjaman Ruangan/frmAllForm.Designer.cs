namespace Peminjaman_Ruangan
{
    partial class frmAllForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.BtnApplyFilter = new System.Windows.Forms.Button();
            this.LblApproval = new System.Windows.Forms.Label();
            this.LabelStatus = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbRejected = new System.Windows.Forms.CheckBox();
            this.cbAccepted = new System.Windows.Forms.CheckBox();
            this.cbPending = new System.Windows.Forms.CheckBox();
            this.PanelStatus = new System.Windows.Forms.Panel();
            this.cbInactive = new System.Windows.Forms.CheckBox();
            this.cbActive = new System.Windows.Forms.CheckBox();
            this.PanelSideBar = new System.Windows.Forms.Panel();
            this.BtnAllReservation = new System.Windows.Forms.Button();
            this.BtnPendingForm = new System.Windows.Forms.Button();
            this.BtnHomeSide = new System.Windows.Forms.Button();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.ImgLogo = new System.Windows.Forms.PictureBox();
            this.TxtSearch = new System.Windows.Forms.TextBox();
            this.KtkSearch = new RectangleControl();
            this.RectangleSearchBar = new RectangleControl();
            this.rectangleControl1 = new RectangleControl();
            this.BtnQuit = new ImageButton();
            this.BtnProfile = new ImageButton();
            this.BtnHome = new ImageButton();
            this.BtnMenu1 = new ImageButton();
            this.Rectangle = new RectangleControl();
            this.BtnNotif = new ImageButton();
            this.PanelAccount = new System.Windows.Forms.Panel();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.RequestPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PanelStatus.SuspendLayout();
            this.PanelSideBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).BeginInit();
            this.PanelAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // RequestPanel
            // 
            this.RequestPanel.AutoScroll = true;
            this.RequestPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.RequestPanel.Controls.Add(this.panel1);
            this.RequestPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestPanel.Location = new System.Drawing.Point(0, 281);
            this.RequestPanel.Name = "RequestPanel";
            this.RequestPanel.Size = new System.Drawing.Size(1350, 396);
            this.RequestPanel.TabIndex = 56;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.BtnApplyFilter);
            this.panel1.Controls.Add(this.LblApproval);
            this.panel1.Controls.Add(this.LabelStatus);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.PanelStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(426, 396);
            this.panel1.TabIndex = 2;
            // 
            // BtnApplyFilter
            // 
            this.BtnApplyFilter.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnApplyFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnApplyFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnApplyFilter.ForeColor = System.Drawing.Color.White;
            this.BtnApplyFilter.Location = new System.Drawing.Point(24, 328);
            this.BtnApplyFilter.Name = "BtnApplyFilter";
            this.BtnApplyFilter.Size = new System.Drawing.Size(379, 56);
            this.BtnApplyFilter.TabIndex = 4;
            this.BtnApplyFilter.Text = "Apply Filter";
            this.BtnApplyFilter.UseVisualStyleBackColor = false;
            this.BtnApplyFilter.Click += new System.EventHandler(this.BtnApplyFilter_Click);
            // 
            // LblApproval
            // 
            this.LblApproval.AutoSize = true;
            this.LblApproval.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblApproval.Location = new System.Drawing.Point(37, 169);
            this.LblApproval.Name = "LblApproval";
            this.LblApproval.Size = new System.Drawing.Size(71, 20);
            this.LblApproval.TabIndex = 3;
            this.LblApproval.Text = "Approval";
            // 
            // LabelStatus
            // 
            this.LabelStatus.AutoSize = true;
            this.LabelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelStatus.Location = new System.Drawing.Point(37, 40);
            this.LabelStatus.Name = "LabelStatus";
            this.LabelStatus.Size = new System.Drawing.Size(56, 20);
            this.LabelStatus.TabIndex = 1;
            this.LabelStatus.Text = "Status";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbRejected);
            this.panel2.Controls.Add(this.cbAccepted);
            this.panel2.Controls.Add(this.cbPending);
            this.panel2.Location = new System.Drawing.Point(24, 178);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(379, 121);
            this.panel2.TabIndex = 2;
            // 
            // cbRejected
            // 
            this.cbRejected.AutoSize = true;
            this.cbRejected.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRejected.Location = new System.Drawing.Point(16, 82);
            this.cbRejected.Name = "cbRejected";
            this.cbRejected.Size = new System.Drawing.Size(117, 24);
            this.cbRejected.TabIndex = 2;
            this.cbRejected.Text = "Disapproved";
            this.cbRejected.UseVisualStyleBackColor = true;
            // 
            // cbAccepted
            // 
            this.cbAccepted.AutoSize = true;
            this.cbAccepted.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAccepted.Location = new System.Drawing.Point(16, 52);
            this.cbAccepted.Name = "cbAccepted";
            this.cbAccepted.Size = new System.Drawing.Size(96, 24);
            this.cbAccepted.TabIndex = 1;
            this.cbAccepted.Text = "Approved";
            this.cbAccepted.UseVisualStyleBackColor = true;
            // 
            // cbPending
            // 
            this.cbPending.AutoSize = true;
            this.cbPending.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPending.Location = new System.Drawing.Point(16, 22);
            this.cbPending.Name = "cbPending";
            this.cbPending.Size = new System.Drawing.Size(86, 24);
            this.cbPending.TabIndex = 0;
            this.cbPending.Text = "Pending";
            this.cbPending.UseVisualStyleBackColor = true;
            // 
            // PanelStatus
            // 
            this.PanelStatus.BackColor = System.Drawing.Color.Transparent;
            this.PanelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelStatus.Controls.Add(this.cbInactive);
            this.PanelStatus.Controls.Add(this.cbActive);
            this.PanelStatus.Location = new System.Drawing.Point(24, 50);
            this.PanelStatus.Name = "PanelStatus";
            this.PanelStatus.Size = new System.Drawing.Size(379, 88);
            this.PanelStatus.TabIndex = 0;
            // 
            // cbInactive
            // 
            this.cbInactive.AutoSize = true;
            this.cbInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInactive.Location = new System.Drawing.Point(16, 52);
            this.cbInactive.Name = "cbInactive";
            this.cbInactive.Size = new System.Drawing.Size(83, 24);
            this.cbInactive.TabIndex = 1;
            this.cbInactive.Text = "Inactive";
            this.cbInactive.UseVisualStyleBackColor = true;
            // 
            // cbActive
            // 
            this.cbActive.AutoSize = true;
            this.cbActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbActive.Location = new System.Drawing.Point(16, 22);
            this.cbActive.Name = "cbActive";
            this.cbActive.Size = new System.Drawing.Size(71, 24);
            this.cbActive.TabIndex = 0;
            this.cbActive.Text = "Active";
            this.cbActive.UseVisualStyleBackColor = true;
            // 
            // PanelSideBar
            // 
            this.PanelSideBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.PanelSideBar.BackColor = System.Drawing.Color.White;
            this.PanelSideBar.Controls.Add(this.BtnAllReservation);
            this.PanelSideBar.Controls.Add(this.BtnPendingForm);
            this.PanelSideBar.Controls.Add(this.BtnHomeSide);
            this.PanelSideBar.Location = new System.Drawing.Point(0, 92);
            this.PanelSideBar.Name = "PanelSideBar";
            this.PanelSideBar.Size = new System.Drawing.Size(57, 637);
            this.PanelSideBar.TabIndex = 87;
            this.PanelSideBar.Visible = false;
            // 
            // BtnAllReservation
            // 
            this.BtnAllReservation.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnAllReservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAllReservation.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAllReservation.ForeColor = System.Drawing.Color.White;
            this.BtnAllReservation.Location = new System.Drawing.Point(-6, 176);
            this.BtnAllReservation.Name = "BtnAllReservation";
            this.BtnAllReservation.Size = new System.Drawing.Size(540, 89);
            this.BtnAllReservation.TabIndex = 4;
            this.BtnAllReservation.Text = "All Reservation";
            this.BtnAllReservation.UseVisualStyleBackColor = false;
            // 
            // BtnPendingForm
            // 
            this.BtnPendingForm.BackColor = System.Drawing.Color.White;
            this.BtnPendingForm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnPendingForm.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnPendingForm.ForeColor = System.Drawing.Color.DimGray;
            this.BtnPendingForm.Location = new System.Drawing.Point(0, 88);
            this.BtnPendingForm.Name = "BtnPendingForm";
            this.BtnPendingForm.Size = new System.Drawing.Size(534, 89);
            this.BtnPendingForm.TabIndex = 3;
            this.BtnPendingForm.Text = "Pending Form";
            this.BtnPendingForm.UseVisualStyleBackColor = false;
            this.BtnPendingForm.Click += new System.EventHandler(this.BtnPendingForm_Click_1);
            // 
            // BtnHomeSide
            // 
            this.BtnHomeSide.BackColor = System.Drawing.Color.White;
            this.BtnHomeSide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHomeSide.Font = new System.Drawing.Font("Roboto", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnHomeSide.ForeColor = System.Drawing.Color.DimGray;
            this.BtnHomeSide.Location = new System.Drawing.Point(0, 0);
            this.BtnHomeSide.Name = "BtnHomeSide";
            this.BtnHomeSide.Size = new System.Drawing.Size(534, 89);
            this.BtnHomeSide.TabIndex = 5;
            this.BtnHomeSide.Text = "Home";
            this.BtnHomeSide.UseVisualStyleBackColor = false;
            this.BtnHomeSide.Click += new System.EventHandler(this.BtnHomeSide_Click);
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
            this.BtnSearch.TabIndex = 91;
            this.BtnSearch.UseVisualStyleBackColor = true;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // ImgLogo
            // 
            this.ImgLogo.BackColor = System.Drawing.Color.White;
            this.ImgLogo.Image = global::Peminjaman_Ruangan.Properties.Resources.logoSmall;
            this.ImgLogo.Location = new System.Drawing.Point(0, 92);
            this.ImgLogo.Name = "ImgLogo";
            this.ImgLogo.Size = new System.Drawing.Size(191, 89);
            this.ImgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImgLogo.TabIndex = 54;
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
            this.TxtSearch.TabIndex = 92;
            this.TxtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TxtSearch_KeyDown);
            // 
            // KtkSearch
            // 
            this.KtkSearch.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.KtkSearch.BackColor = System.Drawing.Color.White;
            this.KtkSearch.Location = new System.Drawing.Point(305, 204);
            this.KtkSearch.Name = "KtkSearch";
            this.KtkSearch.Size = new System.Drawing.Size(701, 52);
            this.KtkSearch.TabIndex = 90;
            this.KtkSearch.Text = "rectangleControl2";
            // 
            // RectangleSearchBar
            // 
            this.RectangleSearchBar.BackColor = System.Drawing.Color.MidnightBlue;
            this.RectangleSearchBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.RectangleSearchBar.Location = new System.Drawing.Point(0, 181);
            this.RectangleSearchBar.Name = "RectangleSearchBar";
            this.RectangleSearchBar.Size = new System.Drawing.Size(1350, 100);
            this.RectangleSearchBar.TabIndex = 53;
            this.RectangleSearchBar.Text = "rectangleControl1";
            // 
            // rectangleControl1
            // 
            this.rectangleControl1.BackColor = System.Drawing.Color.White;
            this.rectangleControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.rectangleControl1.Location = new System.Drawing.Point(0, 92);
            this.rectangleControl1.Name = "rectangleControl1";
            this.rectangleControl1.Size = new System.Drawing.Size(1350, 89);
            this.rectangleControl1.TabIndex = 55;
            this.rectangleControl1.Text = "rectangleControl1";
            // 
            // BtnQuit
            // 
            this.BtnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnQuit.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnQuit.FlatAppearance.BorderSize = 0;
            this.BtnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnQuit.Image = global::Peminjaman_Ruangan.Properties.Resources.Quit;
            this.BtnQuit.Location = new System.Drawing.Point(1280, 23);
            this.BtnQuit.Name = "BtnQuit";
            this.BtnQuit.Size = new System.Drawing.Size(45, 45);
            this.BtnQuit.TabIndex = 52;
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
            this.BtnProfile.Location = new System.Drawing.Point(1219, 23);
            this.BtnProfile.Name = "BtnProfile";
            this.BtnProfile.Size = new System.Drawing.Size(45, 45);
            this.BtnProfile.TabIndex = 50;
            this.BtnProfile.UseVisualStyleBackColor = false;
            this.BtnProfile.Click += new System.EventHandler(this.BtnProfile_Click);
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnHome.FlatAppearance.BorderSize = 0;
            this.BtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnHome.Image = global::Peminjaman_Ruangan.Properties.Resources.home;
            this.BtnHome.Location = new System.Drawing.Point(94, 23);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(45, 45);
            this.BtnHome.TabIndex = 49;
            this.BtnHome.UseVisualStyleBackColor = false;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // BtnMenu1
            // 
            this.BtnMenu1.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnMenu1.FlatAppearance.BorderSize = 0;
            this.BtnMenu1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnMenu1.Image = global::Peminjaman_Ruangan.Properties.Resources.menu;
            this.BtnMenu1.Location = new System.Drawing.Point(24, 23);
            this.BtnMenu1.Name = "BtnMenu1";
            this.BtnMenu1.Size = new System.Drawing.Size(45, 45);
            this.BtnMenu1.TabIndex = 48;
            this.BtnMenu1.UseVisualStyleBackColor = false;
            this.BtnMenu1.Click += new System.EventHandler(this.BtnMenu1_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.BackColor = System.Drawing.Color.MidnightBlue;
            this.Rectangle.Dock = System.Windows.Forms.DockStyle.Top;
            this.Rectangle.Location = new System.Drawing.Point(0, 0);
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(1350, 92);
            this.Rectangle.TabIndex = 47;
            this.Rectangle.Text = "rectangleControl1";
            // 
            // BtnNotif
            // 
            this.BtnNotif.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnNotif.BackColor = System.Drawing.Color.MidnightBlue;
            this.BtnNotif.FlatAppearance.BorderSize = 0;
            this.BtnNotif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnNotif.Image = global::Peminjaman_Ruangan.Properties.Resources.bell;
            this.BtnNotif.Location = new System.Drawing.Point(1159, 23);
            this.BtnNotif.Name = "BtnNotif";
            this.BtnNotif.Size = new System.Drawing.Size(45, 45);
            this.BtnNotif.TabIndex = 93;
            this.BtnNotif.UseVisualStyleBackColor = false;
            // 
            // PanelAccount
            // 
            this.PanelAccount.BackColor = System.Drawing.Color.White;
            this.PanelAccount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PanelAccount.Controls.Add(this.buttonLogOut);
            this.PanelAccount.Font = new System.Drawing.Font("Roboto", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelAccount.Location = new System.Drawing.Point(975, 92);
            this.PanelAccount.Name = "PanelAccount";
            this.PanelAccount.Size = new System.Drawing.Size(289, 57);
            this.PanelAccount.TabIndex = 81;
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
            // frmAllForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 677);
            this.Controls.Add(this.PanelAccount);
            this.Controls.Add(this.BtnNotif);
            this.Controls.Add(this.PanelSideBar);
            this.Controls.Add(this.TxtSearch);
            this.Controls.Add(this.BtnSearch);
            this.Controls.Add(this.KtkSearch);
            this.Controls.Add(this.RequestPanel);
            this.Controls.Add(this.ImgLogo);
            this.Controls.Add(this.RectangleSearchBar);
            this.Controls.Add(this.rectangleControl1);
            this.Controls.Add(this.BtnQuit);
            this.Controls.Add(this.BtnProfile);
            this.Controls.Add(this.BtnHome);
            this.Controls.Add(this.BtnMenu1);
            this.Controls.Add(this.Rectangle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmAllForm";
            this.Text = "Peminjaman Ruangan Universitas Pelita Harapan Medan";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmAllForm_Load);
            this.RequestPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PanelStatus.ResumeLayout(false);
            this.PanelStatus.PerformLayout();
            this.PanelSideBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImgLogo)).EndInit();
            this.PanelAccount.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel RequestPanel;
        private System.Windows.Forms.PictureBox ImgLogo;
        private RectangleControl rectangleControl1;
        private ImageButton BtnQuit;
        private ImageButton BtnProfile;
        private ImageButton BtnHome;
        private ImageButton BtnMenu1;
        private RectangleControl Rectangle;
        private System.Windows.Forms.Panel PanelSideBar;
        private System.Windows.Forms.Button BtnAllReservation;
        private System.Windows.Forms.Button BtnPendingForm;
        private System.Windows.Forms.Button BtnHomeSide;
        private RectangleControl RectangleSearchBar;
        private RectangleControl KtkSearch;
        private System.Windows.Forms.Button BtnSearch;
        private System.Windows.Forms.TextBox TxtSearch;
        private System.Windows.Forms.Label LabelStatus;
        private System.Windows.Forms.Panel PanelStatus;
        private System.Windows.Forms.CheckBox cbActive;
        private System.Windows.Forms.CheckBox cbInactive;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblApproval;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox cbAccepted;
        private System.Windows.Forms.CheckBox cbPending;
        private System.Windows.Forms.CheckBox cbRejected;
        private System.Windows.Forms.Button BtnApplyFilter;
        private ImageButton BtnNotif;
        private System.Windows.Forms.Panel PanelAccount;
        private System.Windows.Forms.Button buttonLogOut;
    }
}