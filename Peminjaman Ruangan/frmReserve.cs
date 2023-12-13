using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    public partial class frmReserve : Form
    {
        public frmReserve()
        {
            InitializeComponent();
        }

        public void SetImg111(Bitmap img)
        {
            Img111.Image = img;
        }

        public void SetLblRoom(string label)
        {
            LblRoom.Text = label;
        }

        private SqlCommand CmdEquipment = Glb.CmdEquipment, CmdFormEquipment = Glb.CmdFormEquipment, CmdForm = Glb.CmdForm, CmdFormTime = Glb.CmdFormTime, CmdStaff = Glb.CmdStaff;
        private SqlDataReader RdEquipment, RdFormEquipment, RdFormTime;
        //List of reservable equipments.
        private Dictionary<int, Tuple<string, int, string>> equipmentDictionary = new Dictionary<int, Tuple<string, int, string>>();
        //List of selected equipments to be reserved.
        private Dictionary<int, Tuple<string, int, string>> selectedEquipmentDictionary = new Dictionary<int, Tuple<string, int, string>>();
        private int equipmentID, equipmentQuantity;
        private string equipmentName, equipmentLocation;

        //List to keep equipment ID.
        private List<int> tempIDList = new List<int>();

        private List<string> CLBTime_OriginalItem = new List<string> //List of reserveable timeslots.
        {
            "09:00 - 10:00",
            "10:00 - 11:00",
            "11:00 - 12:00",
            "12:00 - 13:00",
            "13:00 - 14:00",
            "14:00 - 15:00",
            "15:00 - 16:00",
            "16:00 - 17:00",
            "17:00 - 18:00",
            "18:00 - 19:00",
            "19:00 - 20:00",
            "20:00 - 21:00"
        };

        private bool CheckIfAdmin() //Check if current user is Admin. 
        {
            CmdStaff.CommandText = @"SELECT COUNT(*) FROM Staff WHERE Staff_Email = @UserEmail;";
            CmdStaff.Parameters.Clear();
            CmdStaff.Parameters.AddWithValue("@UserEmail", frmLogin.UserEmail);
            int adminCount = (int)CmdStaff.ExecuteScalar();
            return adminCount > 0;
        }

        private void frmReserve_Load(object sender, EventArgs e)
        {
            Glb.UpdateFormStatus(); //Make sure form that are past NOW are marked inactive. 

            CheckIfAdmin();

            DateTime currentDate = DateTime.Now;
            if (CheckIfAdmin()) //If user is admin, user can reserve rooms as early as today.
            {
                UseDate.MinDate = currentDate;
            }
            else if (currentDate.Hour <= 3) //If not admin, it's <= 3 oclock right now, user can reserve rooms as early as tomorrow 
            {
                UseDate.MinDate = currentDate.AddDays(1);
            }
            else //> 3 oclock = overmorrow. 
            {
                UseDate.MinDate = currentDate.AddDays(2);
            }

            DateTime selectedDate = UseDate.Value.Date;

            if (CheckExistingForms(selectedDate)) //If there are any forms reserved for selectedDate,
            {
                UpdateAvailableTimeSlots(selectedDate); //Update current available timeslots based on selected room and date. 
            }
            else //else all timeslots are available. 
            { 
                CLBTime.Items.Clear();
                foreach (var item in CLBTime_OriginalItem)
                {
                    CLBTime.Items.Add(item);
                }
            }

            //From Db, place all available equipment informations inside equipmentDictionary. 
            CmdEquipment.CommandText = "SELECT EquipmentID, Equipment_Name, Equipment_Quantity, Equipment_Location FROM Equipment";
            RdEquipment = CmdEquipment.ExecuteReader();
            while (RdEquipment.Read())
            {
                // Read values from the database
                equipmentID = RdEquipment.GetInt32(0);
                equipmentName = RdEquipment.GetString(1);
                equipmentQuantity = RdEquipment.GetInt32(2);
                equipmentLocation = RdEquipment.GetString(3);

                // Add to the dictionary
                equipmentDictionary.Add(equipmentID, Tuple.Create(equipmentName, equipmentQuantity, equipmentLocation));
            }
            RdEquipment.Close();

            foreach (var entry in equipmentDictionary) //Display equipment in ComboBox Equip.
            {
                string equipmentDisplayName = $"{entry.Value.Item1} ({entry.Value.Item3})";
                CmbEquip.Items.Add(equipmentDisplayName);
            }

            CmbEquip.SelectedIndex = -1;
        }

        private void BtnSubmit_Click(object sender, EventArgs e)
        {
            Glb.UpdateFormStatus(); //To make sure when submitting no forms past now are active.

            if (!IsRoomAvailable())
            {
                MessageBox.Show("Sorry, the room has just been booked by someone else for the selected date and time.", "Room Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                UpdateAvailableTimeSlots(UseDate.Value.Date);
                return;
            }

            // Check if the requested equipment is available in the required quantity
            if (!AreEquipmentsAvailable())
            {
                MessageBox.Show("Sorry, the requested equipment(s) have just been used or are not available in the required quantity.", "Equipment Not Available", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                foreach (var equipmentID in tempIDList) //tempIDList contains ID of items that are conflicting. 
                {
                    // Remove conflicting items from lb1 and selectedEquipment.
                    selectedEquipmentDictionary.Remove(equipmentID);

                    foreach (object item in lb1.Items)
                    {
                        // Assuming GetEquipmentIDFromListBoxItem is a method that extracts ID from the item
                        int itemId = GetEquipmentIDFromListBoxItem(item.ToString());

                        if (itemId == equipmentID)
                        {
                            lb1.Items.Remove(item);
                            break; // Assuming there is only one item with the same ID in lb1
                        }
                    }
                }
                tempIDList.Clear();
                lb1.SelectedIndex = -1;
                selectedQuantity.Text = "";
                selectedLoc.Text = "";
                UpdateEquipmentQuantities();
                return;
            }

            int formID;
            //Form insertion to DB.
            if (CLBTime.CheckedItems.Count > 0 && ReserveDesc.Text != "" && ReserveAssc.Text != "")
            {
                CmdForm.CommandText = @"INSERT INTO Form (Ruangan_Name, Form_Date, User_Email, 
                                  Form_Description, User_Associate, Rejection_Reason) 
                                  VALUES (@RuanganName, @FormDate, @UserEmail, 
                                  @FormDescription, @UserAssociate, null); SELECT SCOPE_IDENTITY()";
                CmdForm.Parameters.Clear();
                CmdForm.Parameters.AddWithValue("@RuanganName", LblRoom.Text.Substring(3));
                CmdForm.Parameters.AddWithValue("@FormDate", UseDate.Value);
                CmdForm.Parameters.AddWithValue("@UserEmail", frmLogin.UserEmail);
                CmdForm.Parameters.AddWithValue("@FormDescription", ReserveDesc.Text);
                CmdForm.Parameters.AddWithValue("@UserAssociate", ReserveAssc.Text);

                formID = Convert.ToInt32(CmdForm.ExecuteScalar());

                // Insert selected time ranges into the Form_Time table
                foreach (var item in CLBTime.CheckedItems)
                {
                    string[] timeParts = item.ToString().Split(new[] { " - " }, StringSplitOptions.None);
                    if (timeParts.Length == 2)
                    {
                        string startTime = timeParts[0];
                        string endTime = timeParts[1];

                        CmdFormTime.CommandText = @"
                        INSERT INTO Form_Time (FormID, TimeStart, TimeEnd)
                        VALUES (@FormID, @StartTime, @EndTime)";

                        CmdFormTime.Parameters.Clear();
                        CmdFormTime.Parameters.AddWithValue("@FormID", formID);
                        CmdFormTime.Parameters.AddWithValue("@StartTime", startTime);
                        CmdFormTime.Parameters.AddWithValue("@EndTime", endTime);

                        CmdFormTime.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("Time, Description, and Association must be filled!");
                return;
            }

            //Equipment insertion to DB.
            if (selectedEquipmentDictionary.Count > 0)
            {
                // Insert selected equipment into the Form_Equipment table
                foreach (var equip in selectedEquipmentDictionary)
                {
                    CmdFormEquipment.CommandText = @"
                    INSERT INTO Form_Equipment (FormID, EquipmentID, Equipment_Quantity)
                    VALUES (@FormID, @EquipmentID, @EquipmentQuantity)";

                    CmdFormEquipment.Parameters.Clear();
                    CmdFormEquipment.Parameters.AddWithValue("@FormID", formID);
                    CmdFormEquipment.Parameters.AddWithValue("@EquipmentID", equip.Key);
                    CmdFormEquipment.Parameters.AddWithValue("@EquipmentQuantity", equip.Value.Item2);

                    CmdFormEquipment.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Form submitted successfully!");
            this.Close();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            if (CmbEquip.SelectedIndex != -1 && CLBTime.CheckedItems.Count > 0)
            {
                // Get selected equipment details from the ComboBox
                string selectedEquipmentItem = CmbEquip.SelectedItem.ToString();
                int selectedEquipmentID = GetEquipmentIDFromComboBoxItem(selectedEquipmentItem);
                int selectedQ = Convert.ToInt32(EquipQuantity.Value);

                // Check if the selected quantity is greater than 0
                if (selectedQ > 0)
                {
                    // Check if the equipment is already in the selectedEquipmentDictionary
                    if (!selectedEquipmentDictionary.ContainsKey(selectedEquipmentID))
                    {
                        // Add the selected equipment to the selectedEquipmentDictionary
                        selectedEquipmentDictionary.Add(selectedEquipmentID, Tuple.Create(equipmentDictionary[selectedEquipmentID].Item1, selectedQ, equipmentDictionary[selectedEquipmentID].Item3));

                        // Update the ListBox
                        UpdateListBox();
                    }
                    else
                    {
                        // If the equipment is already in the dictionary, update the quantity
                        selectedEquipmentDictionary[selectedEquipmentID] = Tuple.Create(equipmentDictionary[selectedEquipmentID].Item1, selectedQ, equipmentDictionary[selectedEquipmentID].Item3);

                        // Update the ListBox
                        UpdateListBox();
                    }
                    BtnAdd.Text = "Change";
                    selectedQuantity.Text = "";
                    selectedLoc.Text = "";
                }
                else
                {
                    MessageBox.Show("Please enter a quantity greater than 0.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select equipment and time before adding.", "Incomplete Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (lb1.SelectedItem != null)
            {
                // Get the selected item from the ListBox
                string selectedEquipmentItem = lb1.SelectedItem.ToString();

                // Extract the ID from the selected item (you may need to parse it based on your actual format)
                int selectedEquipmentID = GetEquipmentIDFromListBoxItem(selectedEquipmentItem);

                // Remove the item from the selected dictionary
                selectedEquipmentDictionary.Remove(selectedEquipmentID);

                // Remove the item from the ListBox
                lb1.Items.Remove(selectedEquipmentItem);

                // Change the button text to "Add"
                BtnAdd.Text = "Add";
                selectedQuantity.Text = "";
                selectedLoc.Text = "";
            }
        }

        private void CmbEquip_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get selected equipment details from the ComboBox
            string selectedEquipmentItem = CmbEquip.SelectedItem?.ToString();

            if (selectedEquipmentItem != null)
            {
                int selectedEquipmentID = GetEquipmentIDFromComboBoxItem(selectedEquipmentItem);
                EquipQuantity.Maximum = equipmentDictionary[selectedEquipmentID].Item2;

                // Check if the selected equipment is already in lb1
                bool equipmentExistsInListBox = lb1.Items.Cast<string>().Any(item => GetEquipmentIDFromListBoxItem(item) == selectedEquipmentID);

                // Set the text of BtnAdd based on whether the equipment exists in lb1
                BtnAdd.Text = equipmentExistsInListBox ? "Change" : "Add";

                int initialQuantity = GetInitialQuantity(selectedEquipmentID);
                if (EquipQuantity.Maximum < initialQuantity)
                {
                    if (selectedEquipmentDictionary.ContainsKey(selectedEquipmentID))
                    {
                        // Assuming selectedEquipmentDictionary is a Dictionary<int, object>
                        selectedEquipmentDictionary.Remove(selectedEquipmentID);

                        // Remove item from lb1
                        foreach (object item in lb1.Items)
                        {
                            // Assuming GetEquipmentIDFromListBoxItem is a method that extracts ID from the item
                            int itemId = GetEquipmentIDFromListBoxItem(item.ToString());

                            if (itemId == selectedEquipmentID)
                            {
                                lb1.Items.Remove(item);
                                break; // Assuming there is only one item with the same ID in lb1
                            }
                        }

                        lb1.SelectedIndex = -1;
                        selectedQuantity.Text = "";
                        selectedLoc.Text = "";
                    }
                    MessageBox.Show($"You can only book up to {EquipQuantity.Maximum}/{initialQuantity} {selectedEquipmentItem} because of conflicting timeslot!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void lb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lb1.SelectedItem != null)
            {
                string selectedEquipmentItem = lb1.SelectedItem.ToString();
                int equID = GetEquipmentIDFromListBoxItem(selectedEquipmentItem);
                int quantity = selectedEquipmentDictionary[equID].Item2;
                string location = selectedEquipmentDictionary[equID].Item3;
                selectedQuantity.Text = quantity.ToString();
                selectedLoc.Text = location;
            }
        }

        private void UpdateListBox()
        {
            // Clear and update items in the ListBox based on the selectedEquipmentDictionary
            lb1.Items.Clear();
            foreach (var entry in selectedEquipmentDictionary)
            {
                lb1.Items.Add($"{entry.Value.Item1}");
            }
        }

        private void UseDate_ValueChanged(object sender, EventArgs e)
        {
            // Check for existing forms that use the selected date
            DateTime selectedDate = UseDate.Value.Date;

            // If forms exist, remove the occupied time slots from cmbstrt and cmbnd
            if (CheckExistingForms(selectedDate))
            {
                UpdateAvailableTimeSlots(selectedDate);
            }
            else
            {
                CLBTime.Items.Clear();
                foreach (var items in CLBTime_OriginalItem)
                {
                    CLBTime.Items.Add(items);
                }
            }
        }

        private bool CheckExistingForms(DateTime selectedDate)
        {
            // Check if there are any forms that use the selected date
            CmdForm.CommandText = @"
        SELECT COUNT(*) AS FormCount
        FROM Form
        WHERE
            Form_Date = @SelectedDate
            AND Form_Status = 'active'
            AND Room_Approval IN (0, 1)";

            CmdForm.Parameters.Clear();
            CmdForm.Parameters.AddWithValue("@SelectedDate", selectedDate);

            int formCount = Convert.ToInt32(CmdForm.ExecuteScalar());
            return formCount > 0;
        }

        private void CLBTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEquipmentQuantities();
        }

        private void UpdateAvailableTimeSlots(DateTime selectedDate)
        {
            CLBTime.Items.Clear();
            CmdForm.CommandText = @"
            SELECT DISTINCT ft.TimeStart, ft.TimeEnd
            FROM Form_Time ft
            JOIN Form f ON ft.FormID = f.FormID
            WHERE f.Form_Date = @SelectedDate
            AND f.Room_Approval IN (0, 1)
            AND f.Form_Status = 'active'
            AND f.Ruangan_Name = @RuanganName";

            CmdForm.Parameters.Clear();
            CmdForm.Parameters.AddWithValue("@SelectedDate", selectedDate);
            CmdForm.Parameters.AddWithValue("@RuanganName", LblRoom.Text.Substring(3));
            List<string> timeRanges = new List<string>();
            RdFormTime = CmdForm.ExecuteReader();
            while (RdFormTime.Read())
            {
                string timeStart = ((TimeSpan)RdFormTime["TimeStart"]).ToString("hh\\:mm");
                string timeEnd = ((TimeSpan)RdFormTime["TimeEnd"]).ToString("hh\\:mm");
                string timeRange = $"{timeStart} - {timeEnd}";

                // Add the formatted time range to the list
                timeRanges.Add(timeRange);
            }
            RdFormTime.Close();

            foreach (var originalItem in CLBTime_OriginalItem)
            {
                if (!timeRanges.Contains(originalItem))
                {
                    CLBTime.Items.Add(originalItem);
                }
            }
        }

        private int GetEquipmentIDFromListBoxItem(string listBoxItem)
        {
            // Find the equipment ID in the equipmentDictionary based on equipment name
            var equipmentEntry = equipmentDictionary.FirstOrDefault(entry =>
                entry.Value.Item1 == listBoxItem);

            // If a matching entry is found, return its ID; otherwise, return a default value (e.g., -1)
            return equipmentEntry.Key;
        }

        private int GetEquipmentIDFromComboBoxItem(string comboBoxItem)
        {
            // Extract the ID from the selected item (you may need to parse it based on your actual format)
            int selectedEquipmentID = equipmentDictionary.FirstOrDefault(x => $"{x.Value.Item1} ({x.Value.Item3})" == comboBoxItem).Key;

            return selectedEquipmentID;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UpdateEquipmentQuantities()
        {
            List<int> equipmentIDsToUpdate = new List<int>();

            foreach (var entry in equipmentDictionary)
            {
                int equipmentID = entry.Key;
                // Store the equipment IDs that need to be updated
                equipmentIDsToUpdate.Add(equipmentID);
            }

            // Update the equipmentDictionary outside of the foreach loop
            foreach (int equipmentID in equipmentIDsToUpdate)
            {
                int initialQuantity = GetInitialQuantity(equipmentID);
                int totalQuantityUsed = GetTotalUsedQuantity(equipmentID);

                // Calculate the remaining quantity
                int remainingQuantity = initialQuantity - totalQuantityUsed;

                // Update the equipmentDictionary with the new quantity value
                equipmentDictionary[equipmentID] = Tuple.Create(
                    equipmentDictionary[equipmentID].Item1,
                    remainingQuantity,
                    equipmentDictionary[equipmentID].Item3);
            }

            CmbEquip.SelectedIndex = -1;
            EquipQuantity.Value = 0;
        }

        private int GetInitialQuantity(int equipmentID)
        {
            int initialQuantity = 0;

            // SQL query to get the initial quantity for the specified equipmentID
            CmdEquipment.CommandText = "SELECT Equipment_Quantity FROM Equipment WHERE EquipmentID = @EquipmentID";
            CmdEquipment.Parameters.Clear();
            CmdEquipment.Parameters.AddWithValue("@EquipmentID", equipmentID);

            RdEquipment = CmdEquipment.ExecuteReader();
            if (RdEquipment.Read())
            {
                initialQuantity = RdEquipment.GetInt32(0);
            }
            RdEquipment.Close();
            return initialQuantity;
        }

        private int GetTotalUsedQuantity(int equipmentID)
        {
            int totalQuantityUsed = 0;

            if (CLBTime.CheckedItems.Count > 0)
            {
                string startTimeString = null;
                string endTimeString = null;
                // SQL query to get the total quantity used for the specified equipmentID
                CmdFormEquipment.CommandText = @"
            SELECT SUM(FE.Equipment_Quantity) AS TotalQuantityUsed
            FROM Form AS F
            JOIN Form_Equipment AS FE ON F.FormID = FE.FormID
            JOIN Form_Time AS FT ON F.FormID = FT.FormID
            WHERE
            F.Form_Date = @FormDate
            AND FT.TimeStart = @StartTime
            AND FT.TimeEnd = @EndTime
            AND FE.EquipmentID = @EquipmentID
            AND F.Form_Status = 'active'
            AND F.Room_Approval IN (0, 1)";

                foreach (var item in CLBTime.CheckedItems)
                {
                    string[] timeParts = item.ToString().Split(new[] { " - " }, StringSplitOptions.None);
                    if (timeParts.Length == 2)
                    {
                        startTimeString = timeParts[0];
                        endTimeString = timeParts[1];
                    }

                    CmdFormEquipment.Parameters.Clear();
                    CmdFormEquipment.Parameters.AddWithValue("@FormDate", UseDate.Value.Date);
                    CmdFormEquipment.Parameters.AddWithValue("@StartTime", startTimeString);
                    CmdFormEquipment.Parameters.AddWithValue("@EndTime", endTimeString);
                    CmdFormEquipment.Parameters.AddWithValue("@EquipmentID", equipmentID);

                    try
                    {
                        RdFormEquipment = CmdFormEquipment.ExecuteReader();

                        if (RdFormEquipment.Read()) // Check if there are results
                        {
                            if (RdFormEquipment["TotalQuantityUsed"] != DBNull.Value)
                            {
                                totalQuantityUsed += Convert.ToInt32(RdFormEquipment["TotalQuantityUsed"]);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle exception as needed
                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        RdFormEquipment.Close();
                    }
                }


            }
            return totalQuantityUsed;
        }

        private bool IsRoomAvailable()
        {
            foreach (var item in CLBTime.CheckedItems)
            {
                string[] timeParts = item.ToString().Split(new[] { " - " }, StringSplitOptions.None);
                if (timeParts.Length == 2)
                {

                    string startTime = timeParts[0];
                    string endTime = timeParts[1];

                    // Check if the room is booked for the selected date and time
                    if (IsRoomBooked(startTime, endTime))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool AreEquipmentsAvailable()
        {
            bool result = true;
            foreach (var equip in selectedEquipmentDictionary)
            {
                int equipmentID = equip.Key;
                int requestedQuantity = equip.Value.Item2;
                if (!IsEquipmentAvailable(equipmentID, requestedQuantity))
                {
                    tempIDList.Add(equipmentID);
                    result = false;
                }
            }
            return result;
        }

        private bool IsRoomBooked(string startTime, string endTime)
        {
            CmdForm.CommandText = @"
        SELECT COUNT(*) AS FormCount
        FROM Form f
        JOIN Form_Time ft ON f.FormID = ft.FormID
        WHERE
            f.Ruangan_Name = @RoomName
            AND f.Form_Date = @SelectedDate
            AND f.Form_Status = 'active'
            AND f.Room_Approval IN (0, 1)
            AND ft.TimeStart = @StartTime
            AND ft.TimeEnd = @EndTime";

            CmdForm.Parameters.Clear();
            CmdForm.Parameters.AddWithValue("@RoomName", LblRoom.Text.Substring(3));
            CmdForm.Parameters.AddWithValue("@SelectedDate", UseDate.Value.Date);
            CmdForm.Parameters.AddWithValue("@StartTime", startTime.Trim());
            CmdForm.Parameters.AddWithValue("@EndTime", endTime.Trim());

            int formCount = (int)CmdForm.ExecuteScalar();
            return formCount > 0;
        }

        private bool IsEquipmentAvailable(int equipmentID, int requestedQuantity)
        {
            return GetInitialQuantity(equipmentID) - GetTotalUsedQuantity(equipmentID) >= requestedQuantity;
        }
    }
}
