using System;
using System.Linq;
using System.Windows.Forms;

namespace Peminjaman_Ruangan
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start your main form (e.g., the login form)
            Glb.BukaDB();
            Application.Run(new frmLogin());
        }

        public static void CloseAllForms()
        {
            Glb.TutupDB();
            foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
            {
                // Close each form, including the currently active one
                if (form != null && !form.IsDisposed)
                {
                    form.Close();
                }
            }
        }

        public static void LogOut()
        {
            foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
            {
                // Exclude forms of type frmLogin from closing
                if (form != null && !form.IsDisposed && form.GetType() != typeof(frmLogin))
                {
                    form.Close();
                }
            }
            frmLogin loginForm = new frmLogin();
            loginForm.Show();
        }
        public static void CloseAllPendingForms(Form current)
        {
            // Synchronize access to the collection
            lock (Application.OpenForms)
            {
                // Iterate through the collection and close all instances of frmPendingForm except the current one
                foreach (Form form in Application.OpenForms.Cast<Form>().ToArray())
                {
                    if (form is frmPendingForm && form != current)
                    {
                        form.Close();
                    }
                }
            }
        }
    }
}
