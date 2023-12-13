namespace Peminjaman_Ruangan
{
    partial class frmDetailRoom
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
            this.ImgRoom = new System.Windows.Forms.PictureBox();
            this.test = new System.Windows.Forms.Panel();
            this.PanelRoom = new System.Windows.Forms.Panel();
            this.LblRoom = new System.Windows.Forms.Label();
            this.Ktk111 = new RectangleControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblType = new System.Windows.Forms.Label();
            this.LblCapacity = new System.Windows.Forms.Label();
            this.LblLocation = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl1 = new System.Windows.Forms.Label();
            this.BtnBack = new System.Windows.Forms.Button();
            this.LblDetail = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ImgRoom)).BeginInit();
            this.test.SuspendLayout();
            this.PanelRoom.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImgRoom
            // 
            this.ImgRoom.Image = global::Peminjaman_Ruangan.Properties.Resources.Screenshot_2023_06_08_212650_1;
            this.ImgRoom.Location = new System.Drawing.Point(0, 78);
            this.ImgRoom.Name = "ImgRoom";
            this.ImgRoom.Size = new System.Drawing.Size(406, 333);
            this.ImgRoom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImgRoom.TabIndex = 1;
            this.ImgRoom.TabStop = false;
            // 
            // test
            // 
            this.test.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.test.Controls.Add(this.PanelRoom);
            this.test.Controls.Add(this.panel1);
            this.test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.test.Location = new System.Drawing.Point(0, 0);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(1202, 597);
            this.test.TabIndex = 1;
            // 
            // PanelRoom
            // 
            this.PanelRoom.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PanelRoom.BackColor = System.Drawing.Color.White;
            this.PanelRoom.Controls.Add(this.LblRoom);
            this.PanelRoom.Controls.Add(this.ImgRoom);
            this.PanelRoom.Controls.Add(this.Ktk111);
            this.PanelRoom.Location = new System.Drawing.Point(117, 93);
            this.PanelRoom.Name = "PanelRoom";
            this.PanelRoom.Size = new System.Drawing.Size(409, 414);
            this.PanelRoom.TabIndex = 29;
            this.PanelRoom.Tag = "AD-111";
            // 
            // LblRoom
            // 
            this.LblRoom.AutoSize = true;
            this.LblRoom.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LblRoom.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRoom.ForeColor = System.Drawing.Color.White;
            this.LblRoom.Location = new System.Drawing.Point(157, 21);
            this.LblRoom.Name = "LblRoom";
            this.LblRoom.Size = new System.Drawing.Size(94, 29);
            this.LblRoom.TabIndex = 3;
            this.LblRoom.Text = "LP-702";
            // 
            // Ktk111
            // 
            this.Ktk111.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Ktk111.Location = new System.Drawing.Point(0, 0);
            this.Ktk111.Name = "Ktk111";
            this.Ktk111.Size = new System.Drawing.Size(406, 81);
            this.Ktk111.TabIndex = 2;
            this.Ktk111.Text = "Ktk111";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.LblType);
            this.panel1.Controls.Add(this.LblCapacity);
            this.panel1.Controls.Add(this.LblLocation);
            this.panel1.Controls.Add(this.lbl3);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.lbl1);
            this.panel1.Controls.Add(this.BtnBack);
            this.panel1.Controls.Add(this.LblDetail);
            this.panel1.Location = new System.Drawing.Point(689, 93);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 411);
            this.panel1.TabIndex = 45;
            // 
            // LblType
            // 
            this.LblType.AutoSize = true;
            this.LblType.Font = new System.Drawing.Font("Roboto", 15.75F);
            this.LblType.Location = new System.Drawing.Point(141, 253);
            this.LblType.Name = "LblType";
            this.LblType.Size = new System.Drawing.Size(113, 25);
            this.LblType.TabIndex = 51;
            this.LblType.Text = "Classroom";
            // 
            // LblCapacity
            // 
            this.LblCapacity.AutoSize = true;
            this.LblCapacity.Font = new System.Drawing.Font("Roboto", 15.75F);
            this.LblCapacity.Location = new System.Drawing.Point(141, 208);
            this.LblCapacity.Name = "LblCapacity";
            this.LblCapacity.Size = new System.Drawing.Size(36, 25);
            this.LblCapacity.TabIndex = 50;
            this.LblCapacity.Text = "29";
            // 
            // LblLocation
            // 
            this.LblLocation.AutoSize = true;
            this.LblLocation.Font = new System.Drawing.Font("Roboto", 15.75F);
            this.LblLocation.Location = new System.Drawing.Point(141, 161);
            this.LblLocation.Name = "LblLocation";
            this.LblLocation.Size = new System.Drawing.Size(183, 25);
            this.LblLocation.TabIndex = 49;
            this.LblLocation.Text = "AryaDuta Campus";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Font = new System.Drawing.Font("Roboto", 15.75F);
            this.lbl3.Location = new System.Drawing.Point(35, 253);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(104, 25);
            this.lbl3.TabIndex = 48;
            this.lbl3.Text = "Type        :";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Font = new System.Drawing.Font("Roboto", 15.75F);
            this.lbl2.Location = new System.Drawing.Point(35, 208);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(105, 25);
            this.lbl2.TabIndex = 47;
            this.lbl2.Text = "Capacity :";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Font = new System.Drawing.Font("Roboto", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Location = new System.Drawing.Point(35, 161);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(105, 25);
            this.lbl1.TabIndex = 45;
            this.lbl1.Text = "Location :";
            // 
            // BtnBack
            // 
            this.BtnBack.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnBack.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBack.ForeColor = System.Drawing.Color.White;
            this.BtnBack.Location = new System.Drawing.Point(-10, 355);
            this.BtnBack.Name = "BtnBack";
            this.BtnBack.Size = new System.Drawing.Size(375, 59);
            this.BtnBack.TabIndex = 44;
            this.BtnBack.Text = "Back";
            this.BtnBack.UseVisualStyleBackColor = false;
            this.BtnBack.Click += new System.EventHandler(this.BtnBack_Click);
            // 
            // LblDetail
            // 
            this.LblDetail.AutoSize = true;
            this.LblDetail.Font = new System.Drawing.Font("Roboto", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDetail.Location = new System.Drawing.Point(92, 60);
            this.LblDetail.Name = "LblDetail";
            this.LblDetail.Size = new System.Drawing.Size(177, 33);
            this.LblDetail.TabIndex = 30;
            this.LblDetail.Text = "Room Details";
            // 
            // frmDetailRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1202, 597);
            this.Controls.Add(this.test);
            this.Name = "frmDetailRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Peminjaman Ruangan Universitas Pelita Harapan Medan";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.ImgRoom)).EndInit();
            this.test.ResumeLayout(false);
            this.PanelRoom.ResumeLayout(false);
            this.PanelRoom.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox ImgRoom;
        private System.Windows.Forms.Panel test;
        private System.Windows.Forms.Button BtnBack;
        private System.Windows.Forms.Label LblDetail;
        private System.Windows.Forms.Panel PanelRoom;
        public System.Windows.Forms.Label LblRoom;
        private RectangleControl Ktk111;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
        public System.Windows.Forms.Label LblType;
        public System.Windows.Forms.Label LblCapacity;
        public System.Windows.Forms.Label LblLocation;
    }
}