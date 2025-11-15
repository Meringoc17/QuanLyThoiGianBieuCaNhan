using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    public partial class UserRegisterForm : Form
    {
        // Form đăng ký ng dùng
        public UserRegisterForm()
        {
            InitializeComponent();
            pnSignUp.Region = CreateRoundedRegion(pnSignUp.ClientRectangle, 20);
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

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép chữ số và phím điều khiển (Backspace, Delete, v.v.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự không hợp lệ
            }
        }

        // 
        private void btn_Done_Click(object sender, EventArgs e)
        {
            try
            {
                lblError.Visible = false; // Ẩn lỗi trước

                // Kiểm tra dữ liệu nhập
                if (string.IsNullOrWhiteSpace(txtBoxName.Text) && string.IsNullOrWhiteSpace(txtBoxPhoneNum.Text))
                {
                    ShowError("Vui lòng điền thông tin đầy đủ!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBoxName.Text))
                {
                    ShowError("Vui lòng điền tên!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBoxPhoneNum.Text))
                {
                    ShowError("Vui lòng điền SĐT!");
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtBoxPass.Text) || string.IsNullOrWhiteSpace(txtBoxConfirmPass.Text))
                {
                    ShowError("Hãy đặt mật khẩu!");
                    return;
                }

                if (txtBoxPass.Text != txtBoxConfirmPass.Text)
                {
                    ShowError("Mật khẩu không khớp với nhau! Vui lòng thử lại.");
                    return;
                }

                if (txtBoxPhoneNum.Text.Length != 10)
                {
                    ShowError("Vui lòng nhập số điện thoại đủ 10 số!");
                    return;
                }    

                // Đăng ký người dùng
                bool success = UserManager.Register(txtBoxName.Text.Trim(), txtBoxPhoneNum.Text.Trim(), txtBoxPass.Text.Trim());

                if (!success)
                {
                    if (UserManager.IsUsernameExisted(txtBoxName.Text) || UserManager.IsPhoneNumExisted(txtBoxPhoneNum.Text))
                    {
                        MessageBox.Show("Tên đăng nhập/số điện thoại đã có người sử dụng!\nVui lòng sử dụng tên/SĐT khác",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Đăng ký thành công! Vui lòng quay lại màn hình đăng nhập chính!",
                                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi trong quá trình đăng ký:\n{ex.Message}",
                                "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thể hiện thbao lỗi lên lbl trên Form
        private void ShowError(string message)
        {
            lblError.ForeColor = Color.Red;
            lblError.Visible = true;
            lblError.Text = message;
        }

    }
}

