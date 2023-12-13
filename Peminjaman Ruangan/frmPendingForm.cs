using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmPendingForm : Form
    {
        int x, y = 50;
        public frmPendingForm()
        {
            InitializeComponent();
        }

        private void PlacePanel(Control control, Control container)
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
                        //create new variables, timeStart & timeEnd, to hold the new times

                        TimeSpan timeStart = (TimeSpan)timeReader["TimeStart"];
                        TimeSpan timeEnd = (TimeSpan)timeReader["TimeEnd"];
                        //add both to the list
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
            PanelConfirm request = new PanelConfirm();
            request.FormID = formID;

            // Check name of room
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
                    //so the offset changes with i
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

        private void BtnHome_Click(object sender, EventArgs e)
        {
            frmAdminMenu form3 = new frmAdminMenu();
            form3.Show();
            this.Close();
        }
        private void BtnAllReservation_Click(object sender, EventArgs e)
        {
            new frmAllForm().Show();
            this.Close();
        }
        private void frmPendingForm_Load(object sender, EventArgs e)
        {
            Program.CloseAllPendingForms(this);
            //make a joint query of Form & Form_Time
            string countQuery = "SELECT COUNT(DISTINCT f.FormID) " +
                                "FROM Form f " +
                                "JOIN Form_Time t ON f.FormID = t.FormID " +
                                "WHERE f.Form_Status = 'active' " +
                                "AND f.Room_Approval = 0";

            using (SqlCommand countCmd = new SqlCommand(countQuery, Glb.KoneksiDB))
            {
                //add the result from the countQuery
                int formCount = (int)countCmd.ExecuteScalar();

                //this query gives us all the information needed except from start and end time
                string mainQuery = "SELECT DISTINCT f.FormID, f.Form_Status, f.Ruangan_Name, f.Form_Date, f.User_Associate, f.Room_Approval " +
                                   "FROM Form f " +
                                   "WHERE f.Form_Status = 'active' " +
                                   "AND f.Room_Approval = 0 " +
                                   "ORDER BY f.Form_Date " +
                                   "OFFSET @Offset ROWS FETCH NEXT 1 ROWS ONLY";
                //offset is an offset where they move the fetch by 1 row at a time
                LoadFromDB(formCount, mainQuery);
            }
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtSearch.Text))
            {
                // Clear existing requests from the panel
                RequestPanel.Controls.Clear();
                y = 50;

                // Retrieve text from TxtSearch
                string searchText = TxtSearch.Text;

                // Split the search text into words
                string[] searchWords = searchText.Split(' ');

                // Build the search condition dynamically
                string searchCondition = "";
                if (!string.IsNullOrEmpty(searchText))
                {
                    // Search for words in specific fields
                    foreach (string word in searchWords)
                    {
                        if (!string.IsNullOrEmpty(word))
                        {
                            if (searchCondition.Length > 0)
                            {
                                searchCondition += " AND ";
                            }
                            searchCondition += "(f.Ruangan_Name LIKE '%" + word + "%' " +
                                              "OR f.User_Associate LIKE '%" + word + "%')";
                        }
                    }
                }

                // Update count and main queries with search condition
                string countQuery = "SELECT COUNT(DISTINCT f.FormID) " +
                                    "FROM Form f " +
                                    "JOIN Form_Time t ON f.FormID = t.FormID " +
                                    (searchCondition.Length > 0 ? "WHERE f.Form_Status = 'active' " +
                                    "AND f.Room_Approval = 0 AND " + searchCondition : "");

                string mainQuery = "SELECT DISTINCT f.FormID, f.Form_Status, f.Ruangan_Name, f.Form_Date, f.User_Associate, f.Room_Approval " +
                                   "FROM Form f " +
                                   "WHERE f.Form_Status = 'active' " +
                                   "AND f.Room_Approval = 0 AND " + searchCondition +
                                   "ORDER BY f.Form_Date " +
                                   "OFFSET @Offset ROWS FETCH NEXT 1 ROWS ONLY";

                using (SqlCommand countCmd = new SqlCommand(countQuery, Glb.KoneksiDB))
                {
                    int formCount = (int)countCmd.ExecuteScalar();

                    countCmd.Parameters.AddWithValue("@SearchText", searchText);

                    LoadFromDB(formCount, mainQuery);
                }
            }
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSearch_Click(sender, e);
            }
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

        private void BtnQuit_Click(object sender, EventArgs e)
        {
            Program.CloseAllForms();
        }
    }
}
