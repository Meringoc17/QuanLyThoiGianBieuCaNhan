using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    public partial class CategoryConfigForm : Form // Form đại diện cho điều chỉnh Category
    {
        User user;
        public delegate void OnCategoryListChangingHandler(bool callback);
        public event OnCategoryListChangingHandler OnCategoryListChanging;
        private bool isChanged = false;

        public CategoryConfigForm(User user) // Constructor khởi tạo form
        {
            InitializeComponent();
            this.user = user;
            List<Category> categories = CategoryManager.AvailableCategories;

            // Xóa sạch listView trước khi add
            lv_AvailCategr.View = View.Details;
            lv_AvailCategr.Columns.Clear();
            lv_AvailCategr.Columns.Add("Tên", 150);
            lv_AvailCategr.Columns.Add("Mô tả", 200); // ví dụ

            // Add một item
            foreach (Category c in categories)
            {
                ListViewItem item = new ListViewItem(c.Name); // cột 0
                item.SubItems.Add(c.Description);             // cột 1
                item.Tag = c;                                 // giữ object để reference
                lv_AvailCategr.Items.Add(item);
            }
        }

        // nút <Thêm>: ktra Hạng mục thêm vào
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxName.Text) && !string.IsNullOrEmpty(txtboxDesc.Text))
            {
                CategoryManager.AddNewCateToList(txtBoxName.Text, txtboxDesc.Text);
                MessageBox.Show("Đã thêm vào danh sách hạng mục: " + txtBoxName.Text);
                CategoryManager.Save(user);
                ListViewItem i = new ListViewItem(CategoryManager.FindMatchToString(txtBoxName.Text).Name);
                i.SubItems.Add(txtboxDesc.Text);
                lv_AvailCategr.Items.Add(i);
                isChanged = true;
                return;
            }
            else if (!string.IsNullOrEmpty(txtBoxName.Text) && string.IsNullOrEmpty(txtboxDesc.Text))
            {
                CategoryManager.AddNewCateToList(txtBoxName.Text, "");
                MessageBox.Show("Đã thêm vào danh sách hạng mục: " + txtBoxName.Text);
                CategoryManager.Save(user);
                lv_AvailCategr.Items.Add(CategoryManager.FindMatchToString(txtBoxName.Text).Name);
                isChanged = true;
                return;
            }   
        }

        // nút <Xóa> hạng mục
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lv_AvailCategr.SelectedItems.Count == 1)
            {
                CategoryManager.RemoveCategory(lv_AvailCategr.SelectedItems[0].Text);
                lv_AvailCategr.SelectedItems[0].Remove();
                isChanged = true;
            }
        }

        // Khi đóng form sẽ gửi thông tin về cho MainForm refresh
        private void CategoryConfigForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            OnCategoryListChanging?.Invoke(isChanged);
        }
    }
}
