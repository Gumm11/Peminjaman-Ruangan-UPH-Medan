using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmReservedDetail : Form
    {
        public frmReservedDetail()
        {
            InitializeComponent();
        }
        public int FormID { get; set; }
        SqlCommand CmdForm = Glb.CmdForm, CmdFormEquipment = Glb.CmdFormEquipment;

        public void SetImage(string s)
        {
            switch (s)
            {
                case "101":
                    Img111.Image = AdminMenu._101;
                    break;
                case "102":
                    Img111.Image = AdminMenu._102;
                    break;
                case "103":
                    Img111.Image = AdminMenu._103;
                    break;
                case "104":
                    Img111.Image = AdminMenu._104;
                    break;
                case "105":
                    Img111.Image = AdminMenu._105;
                    break;
                case "106":
                    Img111.Image = AdminMenu._106;
                    break;
                case "107":
                    Img111.Image = AdminMenu._107;
                    break;
                case "108":
                    Img111.Image = AdminMenu._108;
                    break;
                case "109":
                    Img111.Image = AdminMenu._109;
                    break;
                case "110":
                    Img111.Image = AdminMenu._110;
                    break;
                case "111":
                    Img111.Image = AdminMenu._111;
                    break;
                case "501":
                    Img111.Image = AdminMenu._501;
                    break;
                case "502":
                    Img111.Image = AdminMenu._502;
                    break;
                case "503":
                    Img111.Image = AdminMenu._503;
                    break;
                case "504":
                    Img111.Image = AdminMenu._504;
                    break;
                case "601":
                    Img111.Image = AdminMenu._601;
                    break;
                case "602":
                    Img111.Image = AdminMenu._602;
                    break;
                case "603":
                    Img111.Image = AdminMenu._603;
                    break;
                case "604":
                    Img111.Image = AdminMenu._604;
                    break;
                case "605":
                    Img111.Image = AdminMenu._605;
                    break;
                case "606":
                    Img111.Image = AdminMenu._606;
                    break;
                case "607":
                    Img111.Image = AdminMenu._607;
                    break;
                case "608":
                    Img111.Image = AdminMenu._608;
                    break;
                case "609":
                    Img111.Image = AdminMenu._609;
                    break;
                case "610":
                    Img111.Image = AdminMenu._610;
                    break;
                case "701":
                    Img111.Image = AdminMenu._701;
                    break;
                case "702":
                    Img111.Image = AdminMenu._702;
                    break;
                case "703":
                    Img111.Image = AdminMenu._703;
                    break;
                case "704":
                    Img111.Image = AdminMenu._704;
                    break;
            }
        }

        public void SetLblRoom(string label)
        {
            Lbl111.Text = label;
        }
        private static string FormatTimeIntervals(List<TimeSpan> timeIntervals)
        {
            string resultString = "";

            for (int index = 0; index < timeIntervals.Count; index++)
            {
                TimeSpan currentInterval = timeIntervals[index];
                // Add a separator after every entry except the last one
                if (index % 2 == 1)
                {
                    resultString += " - ";
                }

                // Add a newline after every 2 entries, but not before the first entry
                if (index % 2 == 0 && index != 0)
                {
                    resultString += Environment.NewLine;
                }

                // Add the formatted time interval
                resultString += currentInterval.ToString(@"hh\:mm");


            }

            return resultString;
        }
        private void FetchTimeIntervals(int formID)
        {
            List<TimeSpan> timeIntervals = new List<TimeSpan>();
            bool hasList = false;
            TimeSpan lastTimeSpan = TimeSpan.MinValue;
            string timeQuery = "SELECT TimeStart, TimeEnd " +
                               "FROM Form_Time " +
                               "WHERE FormID = @FormID";

            using (SqlCommand timeCmd = new SqlCommand(timeQuery, Glb.KoneksiDB))
            {
                timeCmd.Parameters.AddWithValue("@FormID", formID);

                using (SqlDataReader timeReader = timeCmd.ExecuteReader())
                {
                    while (timeReader.Read())
                    {

                        TimeSpan timeStart = (TimeSpan)timeReader["TimeStart"];
                        TimeSpan timeEnd = (TimeSpan)timeReader["TimeEnd"];
                        if (!hasList)
                        {
                            timeIntervals.Add(timeStart);
                            timeIntervals.Add(timeEnd);
                            lastTimeSpan = timeIntervals.Last();
                            hasList = true;
                        }
                        else
                        {
                            if (lastTimeSpan == timeStart)
                            {
                                timeIntervals.Remove(lastTimeSpan);
                                timeIntervals.Add(timeEnd);
                            }
                            else
                            {
                                timeIntervals.Add(timeStart);
                                timeIntervals.Add(timeEnd);
                            }
                            lastTimeSpan = timeIntervals.Last();
                        }

                    }
                }
            }
            string timeIntervalString = FormatTimeIntervals(timeIntervals);
            TxtTime.Text = timeIntervalString;
        }

        private void frmReservedDetail_Load(object sender, EventArgs e)
        {
            if (FormID >= 0)
            {
                CmdForm.CommandText = @"Select * From Form Where FormID = @FormID";
                CmdForm.Parameters.Clear();
                CmdForm.Parameters.AddWithValue("@FormID", FormID);
                SqlDataReader RdForm = CmdForm.ExecuteReader();
                while (RdForm.Read())
                {
                    UseDate.Value = Convert.ToDateTime(RdForm["Form_Date"]);
                    ReserveDesc.Text = RdForm["Form_Description"].ToString();
                    ReserveAssc.Text = RdForm["User_Associate"].ToString();
                    TxtEmail.Text = RdForm["User_Email"].ToString();
                    string status = RdForm["Room_Approval"].ToString();
                    string ruanganName = RdForm["Ruangan_Name"].ToString();
                    SetImage(ruanganName);
                    Lbl111.Text = ruanganName.StartsWith("1") ? "AD - " + ruanganName : "LP - " + ruanganName
                    
                    if (status == "0")
                    {
                        status = "Pending";
                    }
                    else if (status == "1")
                    {
                        status = "Approved";
                    }
                    else if (status == "2")
                    {
                        status = "Disapproved";
                        LblReject.Visible = true;
                        TxtReject.Visible = true;
                        TxtReject.Text = RdForm["Rejection_Reason"].ToString();
                    }
                    else
                    {
                        status = "Not found.";
                    }
                    TxtStatus.Text = status;
                }
                RdForm.Close();
                FetchTimeIntervals(FormID);

                CmdFormEquipment.CommandText = @"
                SELECT fe.EquipmentID, fe.Equipment_Quantity, e.Equipment_Name, e.Equipment_Location
                FROM Form_Equipment fe
                JOIN Equipment e ON fe.EquipmentID = e.EquipmentID
                WHERE fe.FormID = @FormID";

                CmdFormEquipment.Parameters.Clear();
                CmdFormEquipment.Parameters.AddWithValue("@FormID", FormID);
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
    }
}
