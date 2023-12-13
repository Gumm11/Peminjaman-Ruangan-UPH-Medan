using System.Drawing;

namespace Peminjaman_Ruangan
{
    partial class frmReserve
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
            this.test = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.CLBTime = new System.Windows.Forms.CheckedListBox();
            this.selectedLoc = new System.Windows.Forms.TextBox();
            this.selectedQuantity = new System.Windows.Forms.TextBox();
            this.BtnRemove = new System.Windows.Forms.Button();
            this.lb1 = new System.Windows.Forms.ListBox();
            this.EquipQuantity = new System.Windows.Forms.NumericUpDown();
            this.CmbEquip = new System.Windows.Forms.ComboBox();
            this.BtnSubmit = new System.Windows.Forms.Button();
            this.ReserveAssc = new System.Windows.Forms.TextBox();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.ReserveDesc = new System.Windows.Forms.TextBox();
            this.UseDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel111 = new System.Windows.Forms.Panel();
            this.Img111 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.LblRoom = new System.Windows.Forms.Label();
            this.Ktk111 = new RectangleControl();
            this.test.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquipQuantity)).BeginInit();
            this.Panel111.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Img111)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.test.Controls.Add(this.button1);
            this.test.Controls.Add(this.panel2);
            this.test.Controls.Add(this.CLBTime);
            this.test.Controls.Add(this.selectedLoc);
            this.test.Controls.Add(this.selectedQuantity);
            this.test.Controls.Add(this.BtnRemove);
            this.test.Controls.Add(this.lb1);
            this.test.Controls.Add(this.EquipQuantity);
            this.test.Controls.Add(this.CmbEquip);
            this.test.Controls.Add(this.BtnSubmit);
            this.test.Controls.Add(this.ReserveAssc);
            this.test.Controls.Add(this.BtnAdd);
            this.test.Controls.Add(this.ReserveDesc);
            this.test.Controls.Add(this.UseDate);
            this.test.Controls.Add(this.label7);
            this.test.Controls.Add(this.label6);
            this.test.Controls.Add(this.label5);
            this.test.Controls.Add(this.label3);
            this.test.Controls.Add(this.label2);
            this.test.Controls.Add(this.label1);
            this.test.Controls.Add(this.Panel111);
            this.test.Dock = System.Windows.Forms.DockStyle.Fill;
            this.test.Location = new System.Drawing.Point(30, 30);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(1142, 556);
            this.test.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(587, 447);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 54);
            this.button1.TabIndex = 58;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Location = new System.Drawing.Point(589, 248);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(118, 57);
            this.panel2.TabIndex = 57;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(102, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 23);
            this.label9.TabIndex = 57;
            this.label9.Text = ":";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 23);
            this.label4.TabIndex = 56;
            this.label4.Text = "Equipment";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(3, 6);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 23);
            this.label8.TabIndex = 52;
            this.label8.Text = "Selected";
            // 
            // CLBTime
            // 
            this.CLBTime.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CLBTime.FormattingEnabled = true;
            this.CLBTime.Items.AddRange(new object[] {
            "09:00 - 10:00",
            "10:00 - 11:00",
            "11:00 - 12:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "15:00 - 16:00",
            "16:00 - 17:00",
            "17:00 - 18:00",
            "18:00 - 19:00",
            "19:00 - 20:00",
            "20:00 - 21:00"});
            this.CLBTime.Location = new System.Drawing.Point(709, 109);
            this.CLBTime.Margin = new System.Windows.Forms.Padding(2);
            this.CLBTime.Name = "CLBTime";
            this.CLBTime.Size = new System.Drawing.Size(185, 79);
            this.CLBTime.TabIndex = 54;
            this.CLBTime.SelectedIndexChanged += new System.EventHandler(this.CLBTime_SelectedIndexChanged);
            this.CLBTime.MouseCaptureChanged += new System.EventHandler(this.CLBTime_SelectedIndexChanged);
            // 
            // selectedLoc
            // 
            this.selectedLoc.Enabled = false;
            this.selectedLoc.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedLoc.Location = new System.Drawing.Point(904, 286);
            this.selectedLoc.Margin = new System.Windows.Forms.Padding(2);
            this.selectedLoc.Name = "selectedLoc";
            this.selectedLoc.ReadOnly = true;
            this.selectedLoc.Size = new System.Drawing.Size(80, 30);
            this.selectedLoc.TabIndex = 53;
            // 
            // selectedQuantity
            // 
            this.selectedQuantity.Enabled = false;
            this.selectedQuantity.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selectedQuantity.Location = new System.Drawing.Point(904, 244);
            this.selectedQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.selectedQuantity.Name = "selectedQuantity";
            this.selectedQuantity.ReadOnly = true;
            this.selectedQuantity.Size = new System.Drawing.Size(80, 30);
            this.selectedQuantity.TabIndex = 52;
            // 
            // BtnRemove
            // 
            this.BtnRemove.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnRemove.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnRemove.ForeColor = System.Drawing.Color.White;
            this.BtnRemove.Location = new System.Drawing.Point(999, 263);
            this.BtnRemove.Name = "BtnRemove";
            this.BtnRemove.Size = new System.Drawing.Size(94, 34);
            this.BtnRemove.TabIndex = 50;
            this.BtnRemove.Text = "Remove";
            this.BtnRemove.UseVisualStyleBackColor = false;
            this.BtnRemove.Click += new System.EventHandler(this.BtnRemove_Click);
            // 
            // lb1
            // 
            this.lb1.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb1.FormattingEnabled = true;
            this.lb1.ItemHeight = 22;
            this.lb1.Location = new System.Drawing.Point(709, 243);
            this.lb1.Margin = new System.Windows.Forms.Padding(2);
            this.lb1.Name = "lb1";
            this.lb1.Size = new System.Drawing.Size(183, 70);
            this.lb1.TabIndex = 49;
            this.lb1.SelectedIndexChanged += new System.EventHandler(this.lb1_SelectedIndexChanged);
            // 
            // EquipQuantity
            // 
            this.EquipQuantity.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EquipQuantity.Location = new System.Drawing.Point(920, 201);
            this.EquipQuantity.Margin = new System.Windows.Forms.Padding(2);
            this.EquipQuantity.Name = "EquipQuantity";
            this.EquipQuantity.Size = new System.Drawing.Size(37, 30);
            this.EquipQuantity.TabIndex = 48;
            // 
            // CmbEquip
            // 
            this.CmbEquip.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbEquip.FormattingEnabled = true;
            this.CmbEquip.Location = new System.Drawing.Point(709, 200);
            this.CmbEquip.Margin = new System.Windows.Forms.Padding(2);
            this.CmbEquip.Name = "CmbEquip";
            this.CmbEquip.Size = new System.Drawing.Size(185, 30);
            this.CmbEquip.TabIndex = 47;
            this.CmbEquip.SelectedIndexChanged += new System.EventHandler(this.CmbEquip_SelectedIndexChanged);
            // 
            // BtnSubmit
            // 
            this.BtnSubmit.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnSubmit.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSubmit.ForeColor = System.Drawing.Color.White;
            this.BtnSubmit.Location = new System.Drawing.Point(778, 447);
            this.BtnSubmit.Name = "BtnSubmit";
            this.BtnSubmit.Size = new System.Drawing.Size(179, 54);
            this.BtnSubmit.TabIndex = 44;
            this.BtnSubmit.Text = "Submit";
            this.BtnSubmit.UseVisualStyleBackColor = false;
            this.BtnSubmit.Click += new System.EventHandler(this.BtnSubmit_Click);
            // 
            // ReserveAssc
            // 
            this.ReserveAssc.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReserveAssc.Location = new System.Drawing.Point(709, 407);
            this.ReserveAssc.Name = "ReserveAssc";
            this.ReserveAssc.Size = new System.Drawing.Size(275, 30);
            this.ReserveAssc.TabIndex = 43;
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.BtnAdd.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(997, 202);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(96, 28);
            this.BtnAdd.TabIndex = 42;
            this.BtnAdd.Text = "Add";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // ReserveDesc
            // 
            this.ReserveDesc.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ReserveDesc.Location = new System.Drawing.Point(710, 330);
            this.ReserveDesc.Multiline = true;
            this.ReserveDesc.Name = "ReserveDesc";
            this.ReserveDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ReserveDesc.Size = new System.Drawing.Size(275, 64);
            this.ReserveDesc.TabIndex = 41;
            // 
            // UseDate
            // 
            this.UseDate.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.UseDate.Location = new System.Drawing.Point(710, 67);
            this.UseDate.Name = "UseDate";
            this.UseDate.Size = new System.Drawing.Size(184, 30);
            this.UseDate.TabIndex = 39;
            this.UseDate.ValueChanged += new System.EventHandler(this.UseDate_ValueChanged);
            this.UseDate.MouseCaptureChanged += new System.EventHandler(this.UseDate_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(590, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 23);
            this.label7.TabIndex = 36;
            this.label7.Text = "Associate:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(590, 342);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(114, 23);
            this.label6.TabIndex = 35;
            this.label6.Text = "Description:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(587, 203);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 23);
            this.label5.TabIndex = 34;
            this.label5.Text = "Equipment:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(590, 106);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 23);
            this.label3.TabIndex = 32;
            this.label3.Text = "Start Time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Roboto", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(590, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 23);
            this.label2.TabIndex = 31;
            this.label2.Text = "Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(651, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 37);
            this.label1.TabIndex = 30;
            this.label1.Text = "Reservation Form";
            // 
            // Panel111
            // 
            this.Panel111.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Panel111.BackColor = System.Drawing.Color.White;
            this.Panel111.Controls.Add(this.Img111);
            this.Panel111.Controls.Add(this.panel1);
            this.Panel111.Location = new System.Drawing.Point(82, 67);
            this.Panel111.Name = "Panel111";
            this.Panel111.Size = new System.Drawing.Size(409, 423);
            this.Panel111.TabIndex = 29;
            this.Panel111.Tag = "AD-111";
            // 
            // Img111
            // 
            this.Img111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Img111.Image = global::Peminjaman_Ruangan.Properties.Resources.Screenshot_2023_06_08_212650_1;
            this.Img111.Location = new System.Drawing.Point(0, 98);
            this.Img111.Name = "Img111";
            this.Img111.Size = new System.Drawing.Size(409, 325);
            this.Img111.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Img111.TabIndex = 6;
            this.Img111.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RosyBrown;
            this.panel1.Controls.Add(this.LblRoom);
            this.panel1.Controls.Add(this.Ktk111);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(409, 98);
            this.panel1.TabIndex = 5;
            // 
            // LblRoom
            // 
            this.LblRoom.AutoSize = true;
            this.LblRoom.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LblRoom.Font = new System.Drawing.Font("Roboto", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblRoom.ForeColor = System.Drawing.Color.White;
            this.LblRoom.Location = new System.Drawing.Point(162, 39);
            this.LblRoom.Name = "LblRoom";
            this.LblRoom.Size = new System.Drawing.Size(94, 29);
            this.LblRoom.TabIndex = 5;
            this.LblRoom.Text = "LP-503";
            this.LblRoom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Ktk111
            // 
            this.Ktk111.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Ktk111.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ktk111.Location = new System.Drawing.Point(0, 0);
            this.Ktk111.Name = "Ktk111";
            this.Ktk111.Size = new System.Drawing.Size(409, 98);
            this.Ktk111.TabIndex = 4;
            this.Ktk111.Text = "Ktk111";
            // 
            // frmReserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1202, 616);
            this.Controls.Add(this.test);
            this.Name = "frmReserve";
            this.Padding = new System.Windows.Forms.Padding(30);
            this.Text = "Peminjaman Ruangan Universitas Pelita Harapan Medan";
            this.Load += new System.EventHandler(this.frmReserve_Load);
            this.test.ResumeLayout(false);
            this.test.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EquipQuantity)).EndInit();
            this.Panel111.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Img111)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel test;
        private System.Windows.Forms.Panel Panel111;
        private System.Windows.Forms.TextBox ReserveDesc;
        private System.Windows.Forms.DateTimePicker UseDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnAdd;
        private System.Windows.Forms.TextBox ReserveAssc;
        private System.Windows.Forms.Button BtnSubmit;
        private System.Windows.Forms.ComboBox CmbEquip;
        private System.Windows.Forms.NumericUpDown EquipQuantity;
        private System.Windows.Forms.ListBox lb1;
        private System.Windows.Forms.Button BtnRemove;
        private System.Windows.Forms.TextBox selectedQuantity;
        private System.Windows.Forms.TextBox selectedLoc;
        private System.Windows.Forms.CheckedListBox CLBTime;
        private System.Windows.Forms.PictureBox Img111;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblRoom;
        private RectangleControl Ktk111;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
    }
}