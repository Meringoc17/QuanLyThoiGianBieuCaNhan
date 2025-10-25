using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UserManager.LoadUsersFromFile();
            UserManager.Add_Admin(); // thêm admin mặc định nếu cần

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Ép app chạy high DPI
            if (Environment.OSVersion.Version.Major >= 6)
            {
                SetProcessDPIAware();
            }
            UserManager.Add_Admin();
            Application.Run(new UserLogin());
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();

    }
}
