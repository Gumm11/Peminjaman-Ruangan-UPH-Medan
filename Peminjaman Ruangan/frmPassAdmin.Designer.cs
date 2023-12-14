namespace Peminjaman_Ruangan
{
    partial class frmPassAdmin
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
            this.BackButtonAdmin = new System.Windows.Forms.Button();
            this.LoginButtonAdmin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.InputPasswordAdmin = new System.Windows.Forms.TextBox();
            this.imageButton1 = new ImageButton();
            this.SuspendLayout();
            // 
            // BackButtonAdmin
            // 
            this.BackButtonAdmin.BackColor = System.Drawing.Color.DarkBlue;
            this.BackButtonAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BackButtonAdmin.ForeColor = System.Drawing.Color.White;
            this.BackButtonAdmin.Location = new System.Drawing.Point(407, 102);
            this.BackButtonAdmin.Name = "BackButtonAdmin";
            this.BackButtonAdmin.Size = new System.Drawing.Size(75, 23);
            this.BackButtonAdmin.TabIndex = 7;
            this.BackButtonAdmin.Text = "Back";
            this.BackButtonAdmin.UseVisualStyleBackColor = false;
            this.BackButtonAdmin.Click += new System.EventHandler(this.BackButtonAdmin_Click);
            // 
            // LoginButtonAdmin
            // 
            this.LoginButtonAdmin.BackColor = System.Drawing.Color.DarkBlue;
            this.LoginButtonAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LoginButtonAdmin.ForeColor = System.Drawing.Color.White;
            this.LoginButtonAdmin.Location = new System.Drawing.Point(38, 103);
            this.LoginButtonAdmin.Name = "LoginButtonAdmin";
            this.LoginButtonAdmin.Size = new System.Drawing.Size(75, 23);
            this.LoginButtonAdmin.TabIndex = 6;
            this.LoginButtonAdmin.Text = "Login";
            this.LoginButtonAdmin.UseVisualStyleBackColor = false;
            this.LoginButtonAdmin.Click += new System.EventHandler(this.LoginButtonAdmin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Admin Password";
            // 
            // InputPasswordAdmin
            // 
            this.InputPasswordAdmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputPasswordAdmin.Location = new System.Drawing.Point(38, 66);
            this.InputPasswordAdmin.Name = "InputPasswordAdmin";
            this.InputPasswordAdmin.Size = new System.Drawing.Size(444, 31);
            this.InputPasswordAdmin.TabIndex = 4;
            // 
            // imageButton1
            // 
            this.imageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imageButton1.BackColor = System.Drawing.Color.DarkBlue;
            this.imageButton1.FlatAppearance.BorderSize = 0;
            this.imageButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.imageButton1.Image = global::Peminjaman_Ruangan.Properties.Resources.Quit;
            this.imageButton1.Location = new System.Drawing.Point(470, 12);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.Size = new System.Drawing.Size(33, 33);
            this.imageButton1.TabIndex = 38;
            this.imageButton1.UseVisualStyleBackColor = false;
            this.imageButton1.Click += new System.EventHandler(this.imageButton1_Click);
            // 
            // frmPassAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(515, 163);
            this.Controls.Add(this.imageButton1);
            this.Controls.Add(this.BackButtonAdmin);
            this.Controls.Add(this.LoginButtonAdmin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.InputPasswordAdmin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "frmPassAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPassAdmin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BackButtonAdmin;
        private System.Windows.Forms.Button LoginButtonAdmin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox InputPasswordAdmin;
        private ImageButton imageButton1;
    }
}