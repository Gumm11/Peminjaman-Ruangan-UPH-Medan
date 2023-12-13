using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmAllForm : Form
    {
        int x, y = 50;
        public frmAllForm()
        {
            InitializeComponent();
        }

        private void frmAllForm_Load(object sender, EventArgs e)
        {
            //Make a joint query of Form & Form_Time
            string countQuery = "SELECT COUNT(DISTINCT f.FormID) " +
                                "FROM Form f " +
                                "JOIN Form_Time t ON f.FormID = t.FormID ";

            using (SqlCommand countCmd = new SqlCommand(countQuery, Glb.KoneksiDB))
            {
                //Add the result from the countQuery
                int formCount = (int)countCmd.ExecuteScalar();

                //Get all the information needed except from start and end time
                string mainQuery = "SELECT DISTINCT f.FormID, f.Form_Status, f.Ruangan_Name, f.Form_Date, f.User_Associate, f.Room_Approval " +
                                   "FROM Form f " +
                                   "ORDER BY f.Form_Date " +
                                   "OFFSET @Offset ROWS FETCH NEXT 1 ROWS ONLY";
                //Offset is an offset where they move the fetch by 1 row at a time
                LoadFromDB(formCount, mainQuery);
            }
        }

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Program.CloseAllForms();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            frmAdminMenu form3 = new frmAdminMenu();
            form3.Show();
            this.Close();
        }
        private void PlacePanel(Control control, Control container) //Self-explanatory
        {
            x = (container.Width - control.Width) / 2;
            control.Location = new Point(x, y);

            y += 283;
        }
        private List<TimeSpan> FetchTimeIntervals(int formID)
        {
            //Create a list to hold all the extra intervals
            List<TimeSpan> timeIntervals = new List<TimeSpan>();
            bool hasList = false;
            TimeSpan lastTimeSpan = TimeSpan.MinValue;

            // Query to fetch start and end times based on FormID
            string timeQuery = "SELECT TimeStart, TimeEnd " +
                               "FROM Form_Time " +
                               "WHERE FormID = @FormID";

            using (SqlCommand timeCmd = new SqlCommand(timeQuery, Glb.KoneksiDB))
            {
                //Gives @FormID the value from formID
                timeCmd.Parameters.AddWithValue("@FormID", formID);

                using (SqlDataReader timeReader = timeCmd.ExecuteReader())
                {
                    while (timeReader.Read())
                    {
                        //Create new variables, timeStart & timeEnd, to hold the new times

                        TimeSpan timeStart = (TimeSpan)timeReader["TimeStart"];
                        TimeSpan timeEnd = (TimeSpan)timeReader["TimeEnd"];
                        //Add both to the list
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
            return timeIntervals;
        }
        private void LoadRequests(int formID, string ruanganName, string date, List<TimeSpan> timeIntervals, string status, string active, string association)
        {
            //Loads the composition/reservations made
            PanelAll request = new PanelAll();
            request.FormID = formID;

            // Checks name of room
            if (int.Parse(ruanganName) > 200)
                request.SetCode("LP - " + ruanganName);
            else
                request.SetCode("AD - " + ruanganName);

            // Places date from DB
            request.SetDate(date);

            // Concatenate and format the time intervals for display
            string timeIntervalString = string.Join("\n", timeIntervals.Select((t, index) =>
            {
                // Add a newline after every 2 entries
                if (index % 2 == 0)
                    return $"{t.ToString(@"hh\:mm")} - ";
                else if (index == timeIntervals.Count - 1)
                    return $"{t.ToString(@"hh\:mm")}\n";
                else
                    return t.ToString(@"hh\:mm");
            }));

            request.SetImage(ruanganName);

            // Set the time intervals to TxtTime multiline TextBox
            request.SetTime(timeIntervalString);

            // Places status
            request.SetStatus(status);

            // Places active/inactive
            request.SetActive(active);

            // Places association
            request.SetAssociation(association);

            // Places the newly made composition to the panel, "RequestPanel"
            RequestPanel.Controls.Add(request);

            // Places the panel
            PlacePanel(request, RequestPanel);
        }
        private void LoadFromDB(int formCount, string mainQuery)
        {
            string ruanganName = "", date = "", status = "", active = "", association = "";
            int formID = 0;
            using (SqlCommand cmd = new SqlCommand(mainQuery, Glb.KoneksiDB))
            {
                for (int i = 0; i < formCount; i++)
                {
                    //Offset changes with i
                    cmd.Parameters.AddWithValue("@Offset", i);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            formID = Convert.ToInt32(reader["FormID"]);
                            ruanganName = reader["Ruangan_Name"].ToString();
                            association = reader["User_Associate"].ToString();
                            DateTime formDate = Convert.ToDateTime(reader["Form_Date"]);
                            date = formDate.ToString("yyyy-MM-dd");
                            active = reader["Form_Status"].ToString();
                            int Approval = Convert.ToInt32(reader["Room_Approval"]);

                            // Capitalize the first char
                            active = char.ToUpper(active[0]) + active.Substring(1).ToLower();

                            // Determine the status based on the Room_Approval value
                            if (Approval == 0)
                            {
                                status = "Pending";
                            }
                            else if (Approval == 1)
                            {
                                status = "Approved";
                            }
                            else if (Approval == 2)
                            {
                                status = "Disapproved";
                            }
                        }
                    }

                    // Fetch start and end times for the current form
                    List<TimeSpan> timeIntervals = FetchTimeIntervals(formID);

                    // Load data into your component using the consolidated time intervals
                    LoadRequests(formID, ruanganName, date, timeIntervals, status, active, association);

                    // Reset parameters for the next iteration
                    cmd.Parameters.RemoveAt("@Offset");
                }
            }
        }
        private void BtnMenu1_Click(object sender, EventArgs e)
        {
            PanelSideBar.Visible = !PanelSideBar.Visible;
        }
        private void BtnHomeSide_Click(object sender, EventArgs e)
        {
            frmAdminMenu form3 = new frmAdminMenu();
            form3.Show();
            this.Close();
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            List<string> searchConditions = new List<string>();
            string searchText = TxtSearch.Text;

            bool isCbActiveOrInactive = cbActive.Checked || cbInactive.Checked;
            bool isCbRejectedAcceptedPending = cbRejected.Checked || cbAccepted.Checked || cbPending.Checked;

            // Add filter conditions from checkboxes
            if (isCbActiveOrInactive)
            {
                if (cbActive.Checked && cbInactive.Checked)
                {
                    searchConditions.Add("(f.Form_Status = 'Active' OR f.Form_Status = 'Inactive')");
                }
                else
                {
                    if (cbActive.Checked)
                    {
                        searchConditions.Add("f.Form_Status = 'Active'");
                    }
                    else
                    {
                        searchConditions.Add("f.Form_Status = 'Inactive'");
                    }
                }
            }

            if (isCbRejectedAcceptedPending)
            {
                List<string> approvalConditions = new List<string>();
                if (cbPending.Checked)
                {
                    approvalConditions.Add("f.Room_Approval = 0");
                }
                if (cbAccepted.Checked)
                {
                    approvalConditions.Add("f.Room_Approval = 1");
                }
                if (cbRejected.Checked)
                {
                    approvalConditions.Add("f.Room_Approval = 2");
                }

                // Use OR for approval conditions
                string approvalCondition = string.Join(" OR ", approvalConditions);

                if (isCbActiveOrInactive)
                {
                    // AND with approval condition
                    searchConditions.Add($"({approvalCondition})");
                }
                else
                {
                    searchConditions.AddRange(approvalConditions);
                }
            }

            // Add search conditions from text search
            if (!string.IsNullOrEmpty(searchText))
            {
                // Split the search text into words
                string[] words = searchText.Split(' ');

                List<string> escapedWords = new List<string>();

                // Escape each word and add to the list
                foreach (string word in words)
                {
                    if (!string.IsNullOrEmpty(word))
                    {
                        escapedWords.Add(Regex.Escape(word));
                    }
                }

                // Build search condition for each word
                foreach (string escapedWord in escapedWords)
                {
                    searchConditions.Add(
                        $"((Ruangan_Name LIKE '%{escapedWord}%') OR (User_Associate LIKE '%{escapedWord}%'))"
                    );
                }
            }

            // Combine filter and search conditions with AND
            string searchCondition = string.Join(" AND ", searchConditions);

            // Clear existing panel from the requestpanel except panel1
            for (int i = RequestPanel.Controls.Count - 1; i >= 0; i--)
            {
                if (RequestPanel.Controls[i] != panel1)
                {
                    RequestPanel.Controls.RemoveAt(i);
                }
            }
            y = 50;

            // Prepare count and main queries with search condition
            string countQuery = "SELECT COUNT(DISTINCT f.FormID) " +
                                "FROM Form f " +
                                "JOIN Form_Time t ON f.FormID = t.FormID " +
                                (searchCondition.Length > 0 ? "WHERE " + searchCondition : "");

            string mainQuery = "SELECT DISTINCT f.FormID, f.Form_Status, f.Ruangan_Name, f.Form_Date, f.User_Associate, f.Room_Approval " +
                                "FROM Form f " +
                                "WHERE " + searchCondition +
                                "ORDER BY f.Form_Date " +
                                "OFFSET @Offset ROWS FETCH NEXT 1 ROWS ONLY";

            using (SqlCommand countCmd = new SqlCommand(countQuery, Glb.KoneksiDB))
            {
                int formCount = (int)countCmd.ExecuteScalar();

                countCmd.Parameters.AddWithValue("@SearchText", searchText);

                LoadFromDB(formCount, mainQuery);
            }
        }
        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click(sender, e);
            }
        }
        private void BtnApplyFilter_Click(object sender, EventArgs e)
        {
            TxtSearch.Clear();
            List<string> searchConditions = new List<string>();

            bool isCbActiveOrInactive = cbActive.Checked || cbInactive.Checked;
            bool isCbRejectedAcceptedPending = cbRejected.Checked || cbAccepted.Checked || cbPending.Checked;

            // Check for cbActive and cbInactive
            if (isCbActiveOrInactive)
            {
                if (cbActive.Checked && cbInactive.Checked)
                {
                    // Both checked, use OR
                    searchConditions.Add("(f.Form_Status = 'Active' OR f.Form_Status = 'Inactive')");
                }
                else
                {
                    // Only one checked, add specific condition
                    if (cbActive.Checked)
                    {
                        searchConditions.Add("f.Form_Status = 'Active'");
                    }
                    else
                    {
                        searchConditions.Add("f.Form_Status = 'Inactive'");
                    }
                }
            }

            // Check for cbRejected, cbAccepted, and cbPending
            if (isCbRejectedAcceptedPending)
            {
                List<string> approvalConditions = new List<string>();
                if (cbPending.Checked)
                {
                    approvalConditions.Add("f.Room_Approval = 0");
                }
                if (cbAccepted.Checked)
                {
                    approvalConditions.Add("f.Room_Approval = 1");
                }
                if (cbRejected.Checked)
                {
                    approvalConditions.Add("f.Room_Approval = 2");
                }

                // Use OR for approval conditions
                string approvalCondition = string.Join(" OR ", approvalConditions);

                // Combine with cbActive/cbInactive condition
                if (isCbActiveOrInactive)
                {
                    // AND with approval condition
                    searchConditions.Add($"({approvalCondition})");
                }
                else
                {
                    // Only approval conditions, use OR
                    searchConditions.AddRange(approvalConditions);
                }
            }

            if (searchConditions.Count > 0)
            {
                string searchCondition = string.Join(" AND ", searchConditions);

                // Clear existing panel from the requestpanel except panel1
                for (int i = RequestPanel.Controls.Count - 1; i >= 0; i--)
                {
                    if (RequestPanel.Controls[i] != panel1)
                    {
                        RequestPanel.Controls.RemoveAt(i);
                    }
                }
                y = 50;

                // Prepare count and main queries with search condition
                string countQuery = "SELECT COUNT(DISTINCT f.FormID) " +
                                    "FROM Form f " +
                                    "JOIN Form_Time t ON f.FormID = t.FormID " +
                                    "WHERE " + searchCondition; // Apply the search condition to the count query as well

                string mainQuery = "SELECT DISTINCT f.FormID, f.Form_Status, f.Ruangan_Name, f.Form_Date, f.User_Associate, f.Room_Approval " +
                                    "FROM Form f " +
                                    "WHERE " + searchCondition + // Apply the search condition to the main query as well
                                    "ORDER BY f.Form_Date " +
                                    "OFFSET @Offset ROWS FETCH NEXT 1 ROWS ONLY";

                using (SqlCommand countCmd = new SqlCommand(countQuery, Glb.KoneksiDB))
                {
                    int formCount = (int)countCmd.ExecuteScalar();

                    LoadFromDB(formCount, mainQuery);
                }
            }
        }
        private void BtnPendingForm_Click_1(object sender, EventArgs e)
        {
            new frmPendingForm().Show();
            this.Close();
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            if (PanelAccount.Visible == false)
            {
                PanelAccount.Visible = true;
            }
            else PanelAccount.Visible = false;
        }

        private void buttonLogOut_Click(object sender, EventArgs e)
        {
            Program.LogOut();
        }

    }
}
