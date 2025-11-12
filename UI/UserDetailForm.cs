using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    public partial class UserDetailForm : Form
    {
        User user;
        public delegate void ToCloseMainFormHandler (bool e);
        public event ToCloseMainFormHandler ToCloseMainForm;
        bool closeMForm = false;

        public UserDetailForm(User u)
        {
            InitializeComponent();
            user = u;
            txtboxUsrname.Text = user.Name;
            txtbox_PhoneNum.Text = user.Phone;
            txtbox_pwd.Text = user.Password;
        }

        private void lblDeleteAccount_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn chắc chắn muốn xóa tài khoản?\nHành động này sẽ xóa cả file liên quan đến người dùng.", "Xác nhận xóa tài khoản",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                UserManager.DeleteUser(user);
                ScheduleService.Save(user, ScheduleService.ScheduleLoad(user));
                FileService.DeleteScheduleFile(user);
                UserManager.SaveUsersToFile();
                
                MessageBox.Show("Xóa người dùng thành công! Trở về màn hình đăng nhập...");
                this.Hide();
                closeMForm = true;
                ToCloseMainForm?.Invoke(closeMForm);
                this.Close();
            }
            if (result == DialogResult.Cancel)
            {
                result = DialogResult.OK;
            }
        }
    }
}
