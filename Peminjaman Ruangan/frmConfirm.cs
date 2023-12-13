using System;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmConfirm : Form
    {
        public frmConfirm()
        {
            InitializeComponent();
        }
        public int FormID { get; set; }
        SqlCommand CmdForm = Glb.CmdForm, CmdFormTime = Glb.CmdFormTime, CmdFormEquipment = Glb.CmdFormEquipment;

        private void BtnReject_Click(object sender, EventArgs e)
        {
            frmReject rejectForm = new frmReject();
            rejectForm.Owner = this;
            rejectForm.Show();
        }

        private void BtnAccept_Click(object sender, EventArgs e)
        {
            if (FormID >= 0)
            {
                // Get the parent control of the button
                Control parentControl = ((Button)sender).Parent;

                // Traverse up the control hierarchy until a Form instance is found
                while (parentControl != null && !(parentControl is Form))
                {
                    parentControl = parentControl.Parent;
                }

                if (parentControl is Form)
                {
                    Form parentForm = (Form)parentControl;

                    // Set Room_Approval to 1 for the specified FormID
                    UpdateRoomApproval(FormID, 1);

                    // Close the parent form
                    parentForm.Close();

                    // Create a new instance of the parent form
                    frmPendingForm newForm = new frmPendingForm();
                    newForm.Show();

                    this.Close();
                }
            }
        }

        private void frmConfirm_Load(object sender, EventArgs e)
        {
            if (FormID >= 0)
            {
                //Place information from Form table using FormID.
                CmdForm.CommandText = @"Select * From Form Where FormID = @FormID";
                CmdForm.Parameters.Clear();
                CmdForm.Parameters.AddWithValue("@FormID", FormID);
                SqlDataReader RdForm = CmdForm.ExecuteReader();
                while (RdForm.Read())
                {
                    UseDate.Value = Convert.ToDateTime(RdForm["Form_Date"]);
                    ReserveDesc.Text = RdForm["Form_Description"].ToString();
                    ReserveAssc.Text = RdForm["User_Associate"].ToString();
                    Txt_Email.Text = RdForm["User_Email"].ToString();
                }

                //From FormID, get all timeslots.
                CmdFormTime.CommandText = @"SELECT TimeStart, TimeEnd FROM Form_Time WHERE FormID = @FormID";
                CmdFormTime.Parameters.Clear();
                CmdFormTime.Parameters.AddWithValue("@FormID", FormID);
                RdForm.Close();
                SqlDataReader RdFormTime = CmdFormTime.ExecuteReader();
                StringBuilder timeStringBuilder = new StringBuilder();

                while (RdFormTime.Read())
                {
                    TimeSpan timeStart = RdFormTime.GetTimeSpan(0);
                    TimeSpan timeEnd = RdFormTime.GetTimeSpan(1);

                    // Append time range to the StringBuilder
                    timeStringBuilder.AppendLine($"{timeStart} - {timeEnd}");
                }

                // Display the time ranges in TxtTime
                TxtTime.Text = timeStringBuilder.ToString().Trim();

                // From FormID, get all reserved equipments.
                CmdFormEquipment.CommandText = @"
                SELECT fe.EquipmentID, fe.Equipment_Quantity, e.Equipment_Name, e.Equipment_Location
                FROM Form_Equipment fe
                JOIN Equipment e ON fe.EquipmentID = e.EquipmentID
                WHERE fe.FormID = @FormID";

                CmdFormEquipment.Parameters.Clear();
                CmdFormEquipment.Parameters.AddWithValue("@FormID", FormID);
                RdFormTime.Close();
                SqlDataReader RdFormEquipment = CmdFormEquipment.ExecuteReader();
                while (RdFormEquipment.Read())
                {
                    int equipmentID = RdFormEquipment.GetInt32(0);
                    int equipmentQuantity = RdFormEquipment.GetInt32(1);
                    string equipmentName = RdFormEquipment.GetString(2);
                    string equipmentLocation = RdFormEquipment.GetString(3);

                    // Add equipment information to LstEquipment
                    LstEquipment.Items.Add($"{equipmentName} ({equipmentLocation}) - {equipmentQuantity}x");
                }
                RdFormEquipment.Close();
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