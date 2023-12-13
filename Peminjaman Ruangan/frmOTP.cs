using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmOTP : Form
    {
        private int CooldownSeconds = 40;
        private SqlCommand CmdStaff = Glb.CmdStaff;
        private SqlDataReader RdStaff;
        private string email = frmLogin.UserEmail;
        public frmOTP()
        {
            InitializeComponent();
            this.Visible = false;
            InputKodeOTP.KeyPress += InputKodeOTP_KeyPress; // Untuk menerima angka aja
            CountdownTimer.Tick += CountdownTimer_Tick;
            ResendButton.Enabled = true;
        }

        private void InputKodeOTP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)
            {
                e.Handled = true;
            }
        }

        private void SubmitButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (InputKodeOTP.Text != frmLogin.Kode)
                {
                    MessageBox.Show("Kode Salah!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                CmdStaff.CommandText = @"SELECT Staff_Email, Staff_Role FROM Staff WHERE Staff_Email=@Staff_Email";
                CmdStaff.Parameters.Clear();
                CmdStaff.Parameters.AddWithValue("@Staff_Email", email);

                using (RdStaff = CmdStaff.ExecuteReader())
                {
                    if (RdStaff.HasRows)
                    {
                        // If the user is in the Staff table
                        // Close the reader before opening the form
                        RdStaff.Close();

                        frmPassAdmin WindowVerifAdmin = new frmPassAdmin();
                        WindowVerifAdmin.Show();
                    }
                    else
                    {
                        // If the user is not in the Staff table
                        // Close the reader before opening the form
                        RdStaff.Close();

                        frmMenu WindowMenu = new frmMenu();
                        WindowMenu.Show();
                    }
                }
                this.Close();
            }
            catch (Exception ex)
            {
                // Handle exceptions as needed
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResendButton_Click(object sender, EventArgs e)
        {
            try
            {
                string fromEmail = "testugasjoshua@gmail.com";
                string toEmail = frmLogin.UserEmail;
                string subject = "Kode OTP";
                frmLogin.Kode = frmLogin.ArrayToString(frmLogin.RandomNumbers(6));
                string body = frmLogin.Kode;

                using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                {
                    smtpClient.Port = 587;
                    smtpClient.Credentials = new NetworkCredential(fromEmail, "puhq ingt cxve sydv");
                    smtpClient.EnableSsl = true;

                    using (MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body))
                    {
                        smtpClient.Send(mailMessage);
                        MessageBox.Show("Email sent successfully!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error Sending Email!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ResendButton.Enabled = false;
            CooldownSeconds = 40;
            CountdownTimer.Start();
            CountdownLabel.Text = $"Cooldown: {CooldownSeconds} seconds";
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            CooldownSeconds--;
            CountdownLabel.Text = $"Available in: {CooldownSeconds}s";

            if (CooldownSeconds == 0)
            {
                ResendButton.Enabled = true;
                CountdownTimer.Stop();
                CountdownLabel.Text = "";
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            ResendButton.Enabled = true;
            CountdownTimer.Stop();
            CountdownLabel.Text = "";

            frmLogin.UserEmail = "";
            this.Hide();
            frmLogin BalikLogin = new frmLogin();
            BalikLogin.Show();
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            Program.CloseAllForms();
        }
    }
}
