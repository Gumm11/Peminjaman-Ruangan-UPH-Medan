using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmMyReserve : Form
    {
        int x, y = 50;
        public frmMyReserve()
        {
            InitializeComponent();
        }

        private void BtnHome_Click(object sender, EventArgs e)
        {
            frmMenu form3 = new frmMenu();
            form3.Show();
            this.Hide();
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            Program.CloseAllForms();
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
        private void LoadRequests(int formID, string ruanganName, string date, List<TimeSpan> timeIntervals, string status)
        {
            //Loads the composition/reservations made
            Requests request = new Requests();
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

            // Set the time intervals to TxtTime multiline TextBox
            request.SetTime(timeIntervalString);

            // Places status
            request.SetStatus(status);

            request.SetImage(ruanganName);

            // Places the newly made composition to the panel, "RequestPanel"
            RequestPanel.Controls.Add(request);

            // Places the panel ¯\_(ツ)_/¯
            PlacePanel(request, RequestPanel);
        }
        private void LoadFromDB(int formCount, string currentEmail, string mainQuery)
        {
            string ruanganName = "", date = "", status = "";
            int formID = 0;
            using (SqlCommand cmd = new SqlCommand(mainQuery, Glb.KoneksiDB))
            {
                //redone cause its a new query
                cmd.Parameters.AddWithValue("@UserEmail", frmLogin.UserEmail);

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
                            DateTime formDate = Convert.ToDateTime(reader["Form_Date"]);
                            date = formDate.ToString("yyyy-MM-dd");
                            int Approval = Convert.ToInt32(reader["Room_Approval"]);

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
                    LoadRequests(formID, ruanganName, date, timeIntervals, status);

                    // Reset parameters for the next iteration
                    cmd.Parameters.RemoveAt("@Offset");
                }
            }
        }

        private void BtnMenu1_Click(object sender, EventArgs e)
        {
            PanelSideBar.Visible = !PanelSideBar.Visible;
        }

        private void frmMyReserve_Load(object sender, EventArgs e)
        {
            Glb.UpdateFormStatus();
            //make a joint query of Form & Form_Time
            string countQuery = "SELECT COUNT(DISTINCT f.FormID) " +
                                "FROM Form f " +
                                "JOIN Form_Time t ON f.FormID = t.FormID " +
                                "WHERE f.Form_Status = 'active' " +
                                "AND f.User_Email = @UserEmail";

            using (SqlCommand countCmd = new SqlCommand(countQuery, Glb.KoneksiDB))
            {
                //give @UserEmail the value from currentEmail
                countCmd.Parameters.AddWithValue("@UserEmail", frmLogin.UserEmail);
                //add the result from the countQuery
                int formCount = (int)countCmd.ExecuteScalar();

                //this query gives us all the information needed except from start and end time
                string mainQuery = "SELECT DISTINCT f.FormID, f.Ruangan_Name, f.Form_Date, f.Room_Approval " +
                                   "FROM Form f " +
                                   "WHERE f.Form_Status = 'active' " +
                                   "AND f.User_Email = @UserEmail " +
                                   "ORDER BY f.Form_Date " +
                                   "OFFSET @Offset ROWS FETCH NEXT 1 ROWS ONLY";
                //offset is an offset where they move the fetch by 1 row at a time
                LoadFromDB(formCount, frmLogin.UserEmail, mainQuery);
            }
            PanelSideBar.Height = Screen.PrimaryScreen.WorkingArea.Height;
        }
    }
}
