using System;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmDetailRoom : Form
    {
        public frmDetailRoom()
        {
            InitializeComponent();
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
