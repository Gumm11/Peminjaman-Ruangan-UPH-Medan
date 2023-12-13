using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class PanelSecurity : UserControl
    {
        public PanelSecurity()
        {
            InitializeComponent();
        }
      
        public void SetCode(string s)
        {
            LblCode.Text = s;
        }
        public void SetDate(string s)
        {
            LblDate.Text = s;
        }
        public void SetImage(string s)
        {
            switch (s)
            {
                case "101":
                    PictureBox.Image = AdminMenu._101;
                    break;
                case "102":
                    PictureBox.Image = AdminMenu._102;
                    break;
                case "103":
                    PictureBox.Image = AdminMenu._103;
                    break;
                case "104":
                    PictureBox.Image = AdminMenu._104;
                    break;
                case "105":
                    PictureBox.Image = AdminMenu._105;
                    break;
                case "106":
                    PictureBox.Image = AdminMenu._106;
                    break;
                case "107":
                    PictureBox.Image = AdminMenu._107;
                    break;
                case "108":
                    PictureBox.Image = AdminMenu._108;
                    break;
                case "109":
                    PictureBox.Image = AdminMenu._109;
                    break;
                case "110":
                    PictureBox.Image = AdminMenu._110;
                    break;
                case "111":
                    PictureBox.Image = AdminMenu._111;
                    break;
                case "501":
                    PictureBox.Image = AdminMenu._501;
                    break;
                case "502":
                    PictureBox.Image = AdminMenu._502;
                    break;
                case "503":
                    PictureBox.Image = AdminMenu._503;
                    break;
                case "504":
                    PictureBox.Image = AdminMenu._504;
                    break;
                case "601":
                    PictureBox.Image = AdminMenu._601;
                    break;
                case "602":
                    PictureBox.Image = AdminMenu._602;
                    break;
                case "603":
                    PictureBox.Image = AdminMenu._603;
                    break;
                case "604":
                    PictureBox.Image = AdminMenu._604;
                    break;
                case "605":
                    PictureBox.Image = AdminMenu._605;
                    break;
                case "606":
                    PictureBox.Image = AdminMenu._606;
                    break;
                case "607":
                    PictureBox.Image = AdminMenu._607;
                    break;
                case "608":
                    PictureBox.Image = AdminMenu._608;
                    break;
                case "609":
                    PictureBox.Image = AdminMenu._609;
                    break;
                case "610":
                    PictureBox.Image = AdminMenu._610;
                    break;
                case "701":
                    PictureBox.Image = AdminMenu._701;
                    break;
                case "702":
                    PictureBox.Image = AdminMenu._702;
                    break;
                case "703":
                    PictureBox.Image = AdminMenu._703;
                    break;
                case "704":
                    PictureBox.Image = AdminMenu._704;
                    break;
            }
        }
        public void SetStatus(string s)
        {
            LblStatus.Text = s;
            s = s.ToLower();
            if (s == "pending") LblStatus.ForeColor = Color.Gold;
            if (s == "approved") LblStatus.ForeColor = Color.Green;
            if (s == "disapproved") LblStatus.ForeColor = Color.Red;
        }
        public void SetActive(string s)
        {
            LblActive.Text = s;
            s = s.ToLower();
            if (s == "active") LblActive.ForeColor = Color.Green;
            if (s == "inactive") LblActive.ForeColor = Color.Red;
        }
        public void SetTime(string s)
        {
            TxtTime.Text = s;
        }
        public void SetAssociation(string s)
        {
            LblAssociation.Text = s;
        }
        public int FormID { get; set; }
        private void FormDetails_Click(object sender, EventArgs e)
        {
            // Get the parent control of the button
            Control parentControl = ((Button)sender).Parent;

            // Traverse up the control hierarchy until a Requests instance is found
            while (parentControl != null && !(parentControl is PanelSecurity))
            {
                parentControl = parentControl.Parent;
            }

            if (parentControl is PanelSecurity)
            {
                // Now you can cast it safely
                PanelSecurity clickedForm = (PanelSecurity)parentControl;

                frmReservedDetail test = new frmReservedDetail();
                // Retrieve the FormID associated with this form
                test.FormID = clickedForm.FormID;
                test.Show();
            }
        }
    }
}
