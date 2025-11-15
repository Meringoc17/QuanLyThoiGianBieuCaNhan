using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
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
    public partial class CategoryEvtCountForm : Form // Hiển thị số Evt trg từng hạng mục
    {
        public CategoryEvtCountForm(Schedule sc)
        {
            InitializeComponent();
            List<string> list = sc.CategoryUsageCount();
            string text = string.Join(Environment.NewLine, list);
            txtboxDetail.Text = text;
        }
    }
}
