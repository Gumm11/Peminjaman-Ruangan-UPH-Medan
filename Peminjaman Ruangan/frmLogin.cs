using System;
using System.Drawing;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        public static string Kode;
        public static string UserEmail;

        private void KtkEmail_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black);

            // Draw a rectangle
            g.DrawRectangle(pen, 0, 0, 379, 64);
        }

        public static int[] RandomNumbers(int a)
        {
            Random random = new Random();
            int[] randomNumbers = new int[a];

            for (int i = 0; i < a; i++)
            {
                randomNumbers[i] = random.Next(10);
            }

            return randomNumbers;
        }

        public static string ArrayToString(int[] array)
        {
            return string.Join("", array);
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            //Get email, place in UserEmail for use throughout program. 
            string email = TxtEmail.Text.Trim();
            UserEmail = email;

            //Email pattern is __.__@uph.edu
             string emailPattern = @"^[^@\s]+@[^@\s]*uph\.edu$";
             if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, emailPattern))
             {
                 MessageBox.Show("Invalid email format, not a part of institution!", "Error!",
                     MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                 return;
             }

             try
             {
                 try
                 {
                     // Send OTP from testugasjoshua@gmail.com
                     string fromEmail = "testugasjoshua@gmail.com";
                     string toEmail = UserEmail;
                     string subject = "Kode OTP";
                     Kode = ArrayToString(RandomNumbers(6));
                     string body = Kode;

                     using (SmtpClient smtpClient = new SmtpClient("smtp.gmail.com"))
                     {
                         smtpClient.Port = 587;
                        MessageBox.Show("OTP tidak dapat dikirimkan karena password email pengirim dihilangkan untuk alasan security. Tolong WA saya.")
                         smtpClient.Credentials = new NetworkCredential(fromEmail, /*Password tidak ada karena alasan security.*/);
                         smtpClient.EnableSsl = true;

                         using (MailMessage mailMessage = new MailMessage(fromEmail, toEmail, subject, body))
                         {
                             smtpClient.Send(mailMessage);
                             MessageBox.Show("OTP sent successfully! Please check your email.");
                         }
                     }
                 }
                 catch (Exception ex)
                 {
                     MessageBox.Show($"Error: {ex.Message}", "Error Sending Email!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     return;
                 }

                 // Open OTP Form. 
                 frmOTP WindowOtp = new frmOTP();
                 WindowOtp.Show();
                 this.Hide();
             }
             catch (Exception ex)
             {
                 MessageBox.Show("Error: " + ex.Message);
             } 

        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Program.CloseAllForms();
        }
    }
}
