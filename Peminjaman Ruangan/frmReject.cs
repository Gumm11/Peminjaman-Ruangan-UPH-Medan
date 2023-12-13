using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmReject : Form
    {
        public frmReject()
        {
            InitializeComponent();
        }
        SqlCommand CmdForm = Glb.CmdForm;
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            int formID = ((frmConfirm)this.Owner).FormID;
            string Reason = TxtReason.Text;

            UpdateRejectionReason(formID, Reason);

            // Set Room_Approval to 1 for the specified FormID
            UpdateRoomApproval(formID, 2);


            // Create a new instance of the parent form
            frmPendingForm newForm = new frmPendingForm();
            newForm.Show();

            this.Owner.Close();
            // Optionally, close or hide the current form or perform any other actions
            this.Close();
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateRejectionReason(int formID, string RejectionReason)
        {
            try
            {
                CmdForm.CommandText = @"UPDATE Form SET Rejection_Reason = @RejectionReason WHERE FormID = @FormID";
                CmdForm.Parameters.Clear();
                CmdForm.Parameters.AddWithValue("@RejectionReason", RejectionReason);
                CmdForm.Parameters.AddWithValue("@FormID", formID);
                CmdForm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Rejection_Reason: {ex.Message}");
            }
        }
        private void UpdateRoomApproval(int formID, int roomApproval)
        {
            try
            {
                CmdForm.CommandText = @"UPDATE Form SET Room_Approval = @RoomApproval WHERE FormID = @FormID";
                CmdForm.Parameters.Clear();
                CmdForm.Parameters.AddWithValue("@RoomApproval", roomApproval);
                CmdForm.Parameters.AddWithValue("@FormID", formID);
                CmdForm.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating Room_Approval: {ex.Message}");
            }
        }
    }
}
