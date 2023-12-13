using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmPassAdmin : Form
    {
        public frmPassAdmin()
        {
            InitializeComponent();
        }

        private SqlCommand CmdStaff = Glb.CmdStaff;
        private void LoginButtonAdmin_Click(object sender, EventArgs e)
        {
            CmdStaff.CommandText = @"SELECT Staff_Password, Staff_Role FROM Staff 
            WHERE Staff_Email = @StaffEmail;";
            CmdStaff.Parameters.Clear();
            CmdStaff.Parameters.AddWithValue("@StaffEmail", frmLogin.UserEmail);

            try
            {
                using (SqlDataReader RdStaff = CmdStaff.ExecuteReader())
                {
                    if (RdStaff.HasRows)
                    {
                        RdStaff.Read();
                        string StaffPW = RdStaff["Staff_Password"].ToString();

                        if (InputPasswordAdmin.Text == StaffPW)
                        {
                            string jabatan = RdStaff["Staff_Role"].ToString();
                            RdStaff.Close();
                            if (jabatan == "Admin")
                            {
                                frmAdminMenu frm = new frmAdminMenu();
                                frm.Show();
                            }
                            else if (jabatan == "Security")
                            {
                                frmSecurity frm = new frmSecurity();
                                frm.Show();
                            }
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong password, please try again!", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                } 
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void BackButtonAdmin_Click(object sender, EventArgs e)
        {
            frmLogin.UserEmail = "";
            frmLogin BalikLogin = new frmLogin();
            BalikLogin.Show();
            this.Close();
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            Program.CloseAllForms();
        }
    }
}
