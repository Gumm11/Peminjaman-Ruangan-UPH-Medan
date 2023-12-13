namespace Peminjaman_Ruangan
{
    partial class Requests
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.PictureBox = new System.Windows.Forms.PictureBox();
            this.LblCode = new System.Windows.Forms.Label();
            this.LblDate = new System.Windows.Forms.Label();
            this.LblStatus = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.FormDetails = new System.Windows.Forms.Button();
            this.FormDelete = new System.Windows.Forms.Button();
            this.TxtTime = new System.Windows.Forms.TextBox();
            this.Ktk111 = new RectangleControl();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(338, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "Time:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(338, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(338, 53);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Status:";
            // 
            // PictureBox
            // 
            this.PictureBox.Location = new System.Drawing.Point(54, 64);
            this.PictureBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PictureBox.Name = "PictureBox";
            this.PictureBox.Size = new System.Drawing.Size(191, 137);
            this.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PictureBox.TabIndex = 6;
            this.PictureBox.TabStop = false;
            // 
            // LblCode
            // 
            this.LblCode.AutoSize = true;
            this.LblCode.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.LblCode.ForeColor = System.Drawing.Color.White;
            this.LblCode.Location = new System.Drawing.Point(113, 33);
            this.LblCode.Name = "LblCode";
            this.LblCode.Size = new System.Drawing.Size(72, 20);
            this.LblCode.TabIndex = 14;
            this.LblCode.Text = "AD - 101";
            // 
            // LblDate
            // 
            this.LblDate.AutoSize = true;
            this.LblDate.Location = new System.Drawing.Point(468, 20);
            this.LblDate.Name = "LblDate";
            this.LblDate.Size = new System.Drawing.Size(72, 20);
            this.LblDate.TabIndex = 15;
            this.LblDate.Text = "Put Date";
            // 
            // LblStatus
            // 
            this.LblStatus.AutoSize = true;
            this.LblStatus.Location = new System.Drawing.Point(468, 53);
            this.LblStatus.Name = "LblStatus";
            this.LblStatus.Size = new System.Drawing.Size(84, 20);
            this.LblStatus.TabIndex = 17;
            this.LblStatus.Text = "Put Status";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.FormDetails);
            this.panel1.Controls.Add(this.FormDelete);
            this.panel1.Controls.Add(this.LblDate);
            this.panel1.Controls.Add(this.TxtTime);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblStatus);
            this.panel1.Controls.Add(this.LblCode);
            this.panel1.Controls.Add(this.PictureBox);
            this.panel1.Controls.Add(this.Ktk111);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(980, 233);
            this.panel1.TabIndex = 18;
            // 
            // FormDetails
            // 
            this.FormDetails.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.FormDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormDetails.ForeColor = System.Drawing.Color.White;
            this.FormDetails.Location = new System.Drawing.Point(693, 34);
            this.FormDetails.Margin = new System.Windows.Forms.Padding(4);
            this.FormDetails.Name = "FormDetails";
            this.FormDetails.Size = new System.Drawing.Size(272, 63);
            this.FormDetails.TabIndex = 20;
            this.FormDetails.Text = "FORM DETAILS";
            this.FormDetails.UseVisualStyleBackColor = false;
            this.FormDetails.Click += new System.EventHandler(this.FormDetails_Click);
            // 
            // FormDelete
            // 
            this.FormDelete.BackColor = System.Drawing.Color.Crimson;
            this.FormDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormDelete.ForeColor = System.Drawing.Color.White;
            this.FormDelete.Location = new System.Drawing.Point(693, 138);
            this.FormDelete.Margin = new System.Windows.Forms.Padding(4);
            this.FormDelete.Name = "FormDelete";
            this.FormDelete.Size = new System.Drawing.Size(272, 63);
            this.FormDelete.TabIndex = 19;
            this.FormDelete.Text = "DELETE FORM";
            this.FormDelete.UseVisualStyleBackColor = false;
            this.FormDelete.Click += new System.EventHandler(this.FormDelete_Click);
            // 
            // TxtTime
            // 
            this.TxtTime.Location = new System.Drawing.Point(470, 101);
            this.TxtTime.Multiline = true;
            this.TxtTime.Name = "TxtTime";
            this.TxtTime.ReadOnly = true;
            this.TxtTime.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TxtTime.Size = new System.Drawing.Size(130, 100);
            this.TxtTime.TabIndex = 18;
            this.TxtTime.Text = "13:00 - 15:00";
            // 
            // Ktk111
            // 
            this.Ktk111.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.Ktk111.Location = new System.Drawing.Point(54, 18);
            this.Ktk111.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Ktk111.Name = "Ktk111";
            this.Ktk111.Size = new System.Drawing.Size(191, 49);
            this.Ktk111.TabIndex = 7;
            this.Ktk111.Text = "Ktk111";
            // 
            // Requests
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Requests";
            this.Size = new System.Drawing.Size(980, 233);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private RectangleControl Ktk111;
        private System.Windows.Forms.PictureBox PictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label LblCode;
        private System.Windows.Forms.Label LblDate;
        private System.Windows.Forms.Label LblStatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox TxtTime;
        private System.Windows.Forms.Button FormDelete;
        private System.Windows.Forms.Button FormDetails;
    }
}
