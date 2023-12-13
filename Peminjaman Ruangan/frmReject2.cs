using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmReject2 : Form
    {
        private int formID;
        public frmReject2(int formID)
        {
            InitializeComponent();
            this.formID = formID;
        }
        SqlCommand CmdForm = Glb.CmdForm;
        private void SubmitButton_Click(object sender, EventArgs e)
        {
            // Implement the code to update the database with cancel reason
            UpdateRejectionReason(formID, TxtReason.Text); // Replace with actual method
            UpdateRoomApproval(formID, 2);

            // Close frmReject2
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
