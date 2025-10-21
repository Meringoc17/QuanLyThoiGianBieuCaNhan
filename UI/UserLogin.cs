using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    public partial class UserLogin : Form
    {
        public UserLogin()
        {
            InitializeComponent();
            panelLogin.Region = CreateRoundedRegion(panelLogin.ClientRectangle, 20);
            pwdTxtbox.UseSystemPasswordChar = true;
        }

        private Region CreateRoundedRegion(Rectangle bounds, int radius) // tạo góc bolder tròn
        {
            GraphicsPath path = new GraphicsPath();
            int d = radius * 2;
            path.AddArc(bounds.X, bounds.Y, d, d, 180, 90);
            path.AddArc(bounds.Right - d, bounds.Y, d, d, 270, 90);
            path.AddArc(bounds.Right - d, bounds.Bottom - d, d, d, 0, 90);
            path.AddArc(bounds.X, bounds.Bottom - d, d, d, 90, 90);
            path.CloseAllFigures();
            return new Region(path);
        }

        private void btn_Input_Click(object sender, EventArgs e)
        {
            try
            {
                User user = UserManager.Login(usnTxtBox.Text.Trim(), pwdTxtbox.Text.Trim());
                
                lbl_LoginError.ForeColor = Color.Green;
                lbl_LoginError.Text = "Đăng nhập thành công !";
                lbl_LoginError.Visible = true;
                Console.Beep(750, 150);
                Console.Beep(850, 150);
                Console.Beep(1000, 150);

                MessageBox.Show($"Đăng nhập thành công! Xin chào {user.Name}",
                                "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                
                MainForm mainForm = new MainForm(user);
                mainForm.ShowDialog();
                this.Close();

                // new MainForm(user).Show();
                // this.Hide();
            }
            catch (Exception ex)
            {
                lbl_LoginError.Text = "❌ " + ex.Message;
                lbl_LoginError.ForeColor = Color.Red;
                lbl_LoginError.Visible = true;
            }
        }

        private void ckBox_KeepLogIn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
