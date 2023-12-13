﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmMenu : Form
    {
        private List<Panel> allPanels = new List<Panel>();
        private List<Panel> filteredPanels = new List<Panel>();
        private int currentIndex = 0;
        public frmMenu()
        {
            InitializeComponent();
            InitializePanels();

        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            // Get the current date and time in WIB (Western Indonesian Time)
            DateTime currentDateTimeWIB = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, "SE Asia Standard Time");

            // Determine the minimum date based on the current time
            DateTime minimumDate = currentDateTimeWIB.Hour < 15 ? currentDateTimeWIB.Date.AddDays(1) : currentDateTimeWIB.Date.AddDays(2);

            // Set the minimum date for UseDate control
            UseDate.MinDate = minimumDate;
        }

        private void InitializePanels()
        {
            // Initialize all panels and add them to the list
            allPanels.AddRange(new Panel[]
            {
                Panel501, Panel502, Panel503, Panel504, Panel601, Panel602, Panel603, Panel604,
                Panel605, Panel606, Panel607, Panel608, Panel609, Panel610, Panel701, Panel702,
                Panel703, Panel704, Panel101, Panel102, Panel103, Panel104, Panel105, Panel106,
                Panel107, Panel108, Panel109, Panel110, Panel111, PanelKosong
            });
        }

        private void HideAllPanels()
        {
            foreach (Panel panel in allPanels)
            {
                if (panel != null)
                {
                    panel.Hide();
                }
                else
                {
                    throw new InvalidOperationException("One or more panels not found!");
                }
            }
        }

        private bool AnyFilterSelected()
        {
            // Check if any item is checked in CLBTime
            if (CLBTime.CheckedItems.Count > 0)
            {
                return true;
            }

            // Check if any item is checked in CLBCampus
            for (int i = 0; i < CLBCampus.Items.Count; i++)
            {
                if (CLBCampus.GetItemChecked(i))
                {
                    return true;
                }
            }

            // Check if TxtSearch has any text
            if (!string.IsNullOrWhiteSpace(TxtSearch.Text))
            {
                return true;
            }

            // Check if a date is selected in UseDate
            if (UseDate.Value != null)
            {
                return true;
            }

            // No filters are selected, return false
            return false;
        }

        private void ShowCurrentPanels()
        {
            List<Panel> panelsToShow;
            //Ada filter, dan filteredpanels kosong.
            if (AnyFilterSelected() && !filteredPanels.Any())
            {
                HideAllPanels();
                return;
            }
            //Tidak ada filter, dan filteredpanels kosong.
            else if (!AnyFilterSelected() && !filteredPanels.Any())
            {
                panelsToShow = allPanels;
            }

            /*Tidak ada filter, dan filteredpanels berisi tidak mungkin terjadi. 
            Karena jika dari ada filter jadi tidak, FilterPanels() dijalankan, sehingga filteredpanels di clear dan di isi ulang.
            jika tidak ada filter, filteredpanels tidak mungkin berisi.*/

            //Ada filter, dan filteredpanels berisi
            else
            {
                panelsToShow = filteredPanels;
            }

            // Check if the count of panelsToShow is not a multiple of 3
            if (panelsToShow.Count % 3 != 0)
            {
                // Calculate the number of PanelKosong needed to make it a multiple of 3
                int kosongCount = 3 - (panelsToShow.Count % 3);

                // Add PanelKosong to the panelsToShow list
                for (int i = 0; i < kosongCount; i++)
                {
                    panelsToShow.Add(PanelKosong);
                }
            }

            for (int i = 0; i < 3; i++)
            {
                int adjustedIndex = (currentIndex + i) % panelsToShow.Count;

                // Set the location of the panel
                panelsToShow[adjustedIndex].Location = GetPanelPosition(i + 1);

                // Show the panel
                panelsToShow[adjustedIndex].Show();
            }
        }

        private void HideAndShowPanels()
        {
            // Hide all panels and show the current panels
            HideAllPanels();
            ShowCurrentPanels();
        }

        private List<string> GetSelectedFilters()
        {
            // Collect selected filters from the checklist box
            List<string> selectedFilters = new List<string>();

            foreach (var item in CLBCampus.CheckedItems)
            {
                selectedFilters.Add(item.ToString());
            }

            return selectedFilters;
        }

        private List<string> GetSelectedFilters(string selectedFilter, string action)
        {
            // Collect selected filters from the checklist box
            List<string> selectedFilters = new List<string>();

            if (action == "checked")
            {
                selectedFilters.Add(selectedFilter);
            }

            for (int i = 0; i < CLBCampus.Items.Count; i++)
            {
                if (selectedFilter != CLBCampus.Items[i].ToString() && CLBCampus.GetItemChecked(i))
                {
                    selectedFilters.Add(CLBCampus.Items[i].ToString());
                }
            }
            return selectedFilters;
        }


        private bool panelMatchesFilters(Panel panel, List<string> filters)
        {
            foreach (var filter in filters)
            {
                if (filter == "Aryaduta Campus" && panel.Controls.OfType<Control>().Any(c => c.Text != null && c.Text.Contains("AD")))
                {
                    return true;
                }
                else if (filter == "Lippo Campus" && panel.Controls.OfType<Control>().Any(c => c.Text != null && c.Text.Contains("LP")))
                {
                    return true;
                }
            }

            return false;
        }

        private void FilterPanels(string searchText, List<string> selectedFilters)
        {
            filteredPanels.Clear();

            List<string> reservations = (CLBTime.CheckedItems.Count > 0)
                ? GetReservations(UseDate.Value)
                : new List<string>();

            foreach (Panel panel in allPanels)
            {
                string panelName = GetPanelName(panel);
                // Check if the panel matches the search text, selected filters, and GetPanelName(panel) does not exist in the list of reservations.
                if (panelName.ToLower().Contains(searchText) &&
                    (selectedFilters.Count == 0 || panelMatchesFilters(panel, selectedFilters)) &&
                    !reservations.Contains(panelName))
                {
                    filteredPanels.Add(panel);
                }
            }
            // After updating the filtered panels, hide all panels and show the current panels
            HideAndShowPanels();
        }

        private string GetPanelName(Panel panel)
        {
            // Assuming the panel names have the format "PanelXXX"
            // Extract the numeric part from the panel's name
            string panelName = panel.Name;

            // Check if the panel name follows the expected format
            if (panelName.Length >= 6 && panelName.StartsWith("Panel"))
            {
                // Extract the numeric part (e.g., "501" from "Panel501")
                string numericPart = panelName.Substring(5);

                // You can return the numeric part as the identifier
                return numericPart;
            }

            // If the panel name doesn't follow the expected format, you might want to handle it accordingly
            // For example, throw an exception, return a default value, or log an error
            throw new InvalidOperationException("Panel name does not follow the expected format: " + panelName);
        }

        private Point GetPanelPosition(int position)
        {
            switch (position)
            {
                case 1:
                    return new Point(570, 780);
                case 2:
                    return new Point(850, 780);
                case 3:
                    return new Point(1120, 780);
                default:
                    return Point.Empty;
            }
        }

        public List<TimeSpan[]> InsertCLBToList()
        {
            List<TimeSpan[]> selectedTimeSpans = new List<TimeSpan[]>();

            foreach (var selectedItem in CLBTime.CheckedItems)
            {
                // Split the selected item into start and end times
                string[] times = selectedItem.ToString().Split('-');

                // Parse start and end times
                if (TimeSpan.TryParse(times[0].Trim(), out var startTime) && TimeSpan.TryParse(times[1].Trim(), out var endTime))
                {
                    // Add the timespan to the list
                    selectedTimeSpans.Add(new TimeSpan[] { startTime, endTime });
                }
                else
                {
                    // Handle invalid time period format
                    MessageBox.Show($"Invalid time period format: {selectedItem}");
                }
            }

            return selectedTimeSpans;
        }

        public List<string> GetReservations(DateTime selectedDate)
        {
            List<string> reservations = new List<string>();
            SqlCommand CmdForm = Glb.CmdForm;
            // Replace 'UseDate value' with the selected date in the format 'yyyy-MM-dd'
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");

            // Assuming you have a method to get the selected time spans
            List<TimeSpan[]> timeSpans = InsertCLBToList();
            TimeSpan startTime, endTime;

            CmdForm.CommandText = "SELECT DISTINCT F.Ruangan_Name " +
                               "FROM Form F " +
                               "JOIN Form_Time FT ON F.FormID = FT.FormID " +
                               "WHERE F.Form_Date = @SelectedDate " +
                               "AND FT.TimeStart >= @StartTime " +
                               "AND FT.TimeEnd <= @EndTime " +
                               "AND F.Form_Status = 'active';";

            // Iterate through the time spans and fetch reservations
            foreach (var timeSpan in timeSpans)
            {
                startTime = timeSpan[0];
                endTime = timeSpan[1];

                CmdForm.Parameters.Clear();
                CmdForm.Parameters.AddWithValue("@SelectedDate", formattedDate);
                CmdForm.Parameters.AddWithValue("@StartTime", startTime.ToString());
                CmdForm.Parameters.AddWithValue("@EndTime", endTime.ToString());

                SqlDataReader RdForm = CmdForm.ExecuteReader();

                // Read the results and add them to the reservations list
                while (RdForm.Read())
                {
                    reservations.Add(RdForm["Ruangan_Name"].ToString());
                }

                RdForm.Close();
            }

            return reservations;
        }

        private void ImgRight_Click(object sender, EventArgs e)
        {
            currentIndex += 3;
            HideAndShowPanels();
        }

        private void ImgSearch_Click(object sender, EventArgs e)
        {
            // Perform search logic based on the TextBox text
            string searchText = TxtSearch.Text.ToLower();
            FilterPanels(searchText, GetSelectedFilters());
        }

        private void ImgLeft_Click(object sender, EventArgs e)
        {
            // Move to the previous set of panels
            currentIndex -= 3;

            // Wrap around to the end if necessary
            currentIndex = (currentIndex + allPanels.Count) % allPanels.Count;
            HideAndShowPanels();
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchText = TxtSearch.Text.ToLower();
            LblSearch.Text = searchText == "" ? "Search for a room..." : "";
            FilterPanels(searchText, GetSelectedFilters());
        }

        private void BtnMenu_Click(object sender, MouseEventArgs e)
        {
            PanelSideBar.Visible = !PanelSideBar.Visible;
        }

        private void BtnReserveRoom_Click(object sender, EventArgs e)
        {
            new frmReserve().Show();
        }

        private void imageButton1_Click(object sender, EventArgs e)
        {
            Program.CloseAllForms();
        }

        private void MyReservation_Click(object sender, EventArgs e)
        {
            new frmMyReserve().Show();
        }

        private void CLBCampus_ItemCheck_1(object sender, ItemCheckEventArgs e)
        {
            // Update the filtered panels list based on the search criteria and selected filters
            string searchText = TxtSearch.Text.ToLower();
            string selectedFilter = CLBCampus.Items[e.Index].ToString();
            string action = e.NewValue == CheckState.Checked ? "checked" : "unchecked";
            // Use the GetSelectedFilters method with the current item index and new state
            FilterPanels(searchText, GetSelectedFilters(selectedFilter, action));
        }

        private void UseDate_ValueChanged(object sender, EventArgs e)
        {
            string searchText = TxtSearch.Text.ToLower();
            FilterPanels(searchText, GetSelectedFilters());
        }

        private void CLBTime_Click(object sender, EventArgs e)
        {
            string searchText = TxtSearch.Text.ToLower();
            FilterPanels(searchText, GetSelectedFilters());
        }

    }
}
