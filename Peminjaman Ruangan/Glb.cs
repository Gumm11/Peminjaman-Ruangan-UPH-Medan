using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    internal class Glb
    {
        public static SqlConnection KoneksiDB;
        public static SqlCommand CmdUser, CmdStaff, CmdRuangan, CmdForm, CmdEquipment, CmdFormEquipment, CmdFormTime;
        public bool IsAdmin = false;
        public static void BukaDB()
        {
            try
            {
                KoneksiDB = new SqlConnection("Data Source = localhost\\SQLEXPRESS; Initial Catalog = DbPeminjaman; Integrated Security = True");
                KoneksiDB.Open();
                CmdUser = KoneksiDB.CreateCommand();
                CmdStaff = KoneksiDB.CreateCommand();
                CmdRuangan = KoneksiDB.CreateCommand();
                CmdForm = KoneksiDB.CreateCommand();
                CmdEquipment = KoneksiDB.CreateCommand();
                CmdFormEquipment = KoneksiDB.CreateCommand();
                CmdFormTime = KoneksiDB.CreateCommand();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening database connection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void TutupDB()
        {
            CmdUser.Dispose();
            CmdStaff.Dispose();
            CmdRuangan.Dispose();
            CmdForm.Dispose();
            CmdEquipment.Dispose();
            CmdFormEquipment.Dispose();
            CmdFormTime.Dispose();
            KoneksiDB.Close();
            KoneksiDB.Dispose();
        }

        public static void UpdateFormStatus()
        {
            Glb.CmdForm.CommandText = @"
                UPDATE f
                SET Form_Status = 'inactive'
                FROM Form f
                JOIN (
                    SELECT ft.FormID, MAX(ft.TimeEnd) AS LatestTimeEnd
                    FROM Form_Time ft
                    GROUP BY ft.FormID
                ) AS LatestTime ON f.FormID = LatestTime.FormID
                WHERE f.Form_Date < CONVERT(DATE, GETDATE()) 
                   OR (f.Form_Date = CONVERT(DATE, GETDATE()) AND LatestTime.LatestTimeEnd < CONVERT(TIME, GETDATE()));
            ";
            try
            {
                Glb.CmdForm.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occured: " + ex.Message);
            }
        }
    }
}
