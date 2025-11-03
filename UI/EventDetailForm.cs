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
    public partial class EventDetailForm : Form
    {
        public EventDetailForm(EventBase e)
        {
            InitializeComponent();
            if (e is RecurringEvent rc)
            { 
                lblDetail.Text = "Tiêu đề: " + e.Title + "\n(Có lặp lại)";
                lBEvtDetail.Items.Add("Thời gian bắt đầu: " + rc.Start);
                lBEvtDetail.Items.Add("Thời gian kết thúc: " + rc.End);
                lBEvtDetail.Items.Add("Loại: " + rc.Type);
                lBEvtDetail.Items.Add("Ưu tiên: " + rc.Priority);
                if (rc.Status)
                {
                    lBEvtDetail.Items.Add("Trạng thái: Đã xong");
                }
                else
                {
                    lBEvtDetail.Items.Add("Trạng thái: Chưa xong");
                }    

                lBEvtDetail.Items.Add("    ======================");
                lBEvtDetail.Items.Add("Chi tiết lặp lại theo: " + rc.RepeatUnit.ToUpperInvariant());

                if (rc.RepeatUnit == "Tuần")
                {
                    rc.ToString();
                    lBEvtDetail.Items.Add("Lặp lại vào thứ: " + rc.DaysInVN);
                }
                if (rc.EndDate > DateTime.MinValue)
                {
                    lBEvtDetail.Items.Add("Thgian kết thúc: " + rc.EndDate);
                }
                if (rc.Occurrences > 0)
                {
                    lBEvtDetail.Items.Add("Số lần lặp còn lại: " + rc.Occurrences);
                }
            }
            else 
            {
                lblDetail.Text = "Tiêu đề: " + e.Title + "\n(Ko lặp lại)";
                lBEvtDetail.Items.Add("Thời gian bắt đầu: " + e.Start);
                lBEvtDetail.Items.Add("Thời gian kết thúc: " + e.End);
                lBEvtDetail.Items.Add("Loại: " + e.Type);
                lBEvtDetail.Items.Add("Ưu tiên: " + e.Priority);
                if (e.Status)
                {
                    lBEvtDetail.Items.Add("Trạng thái: Đã xong");
                }
                else
                {
                    lBEvtDetail.Items.Add("Trạng thái: Chưa xong");
                }

            }
        }
    }
}
