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
    public partial class RecurringEvtSettingForm : Form
    {
        RecurringEvent recurrringEvt = new RecurringEvent();
        public delegate void RecurringEventSavedHandler(RecurringEvent e);
        public event RecurringEventSavedHandler OnRecurrEvtSaved;

        public RecurringEvtSettingForm(RecurringEvent r)
        {
            InitializeComponent();
            this.recurrringEvt = r;
            string[] timeUnits = { "Ngày", "Tuần", "Tháng", "Năm" };
            cLB_UnitTimeSelect.Items.AddRange(timeUnits);
            cLB_UnitTimeSelect.SetItemChecked(0, true);
            
            //if (cLB_UnitTimeSelect)
        }

        private void btn_Done_Click(object sender, EventArgs e)
        {
            recurrringEvt.RepeatIntervalDays = int.Parse(txtBox_NumTimeUnit.Text);
            recurrringEvt.RepeatUnit = cLB_UnitTimeSelect.CheckedItems[0].ToString();

            int i = 0;
            if (pnRepeatDays.Enabled == true)
            {
                foreach (Control ctrl in pnRepeatDays.Controls)
                {
                    if (ctrl is CheckBox cb && cb.Checked && cb.Text != "Cả Tuần")
                    {
                        recurrringEvt.Days.Add(RecurringEvent.DayConverter(cb.Text));
                        i++;
                    }
                }
                if (i == 0)
                {
                    MessageBox.Show("Không có ngày được chọn !");
                }
            }

            if (cB_AfterTimes.Checked == true)
            {
                if (txtBox_Times.Text != null && txtBox_Times.Text != "")
                {
                    recurrringEvt.Occurrences = int.Parse(txtBox_Times.Text.Trim());   
                }
                else
                {
                    throw new Exception("Chưa điền số lần nhắc !");
                }
            }

            if (cB_Never.Checked == true)
            {
                recurrringEvt.EndDate = DateTime.MaxValue;
            }

            if (cB_Overday.Checked == true)
            {
                recurrringEvt.EndDate = dtPicker_DaySelect.Value;
            }

            OnRecurrEvtSaved?.Invoke(recurrringEvt);

            this.Close();
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép chữ số và phím điều khiển (Backspace, Delete, v.v.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự không hợp lệ
            }
        }



        private void btn_Reset_Click(object sender, EventArgs e)
        {
            cLB_UnitTimeSelect.SetItemChecked(0, true);
            txtBox_NumTimeUnit.Text = "";
            pnRepeatDays.Enabled = false;
            txtBox_Times.Text = "";
            foreach (Control ctrl in pnRepeatDays.Controls)
            {
                if (ctrl is CheckBox cb)
                {
                    cb.Checked = false;
                }    
            }
            foreach (Control ctrl in pnOverSetting.Controls)
            {
                if (ctrl is CheckBox cb && cb.Checked == true)
                {
                    cb.Checked = false;
                }
            }
            lblEveryMonth.Visible = false;
        }

        private void OSCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clicked = sender as CheckBox;

            // Nếu cái vừa click được check
            if (clicked.Checked)
            {
                // Duyệt qua các checkbox khác trong cùng panel
                foreach (Control ctrl in pnOverSetting.Controls)
                {
                    if (ctrl is CheckBox cb && cb != clicked)
                    {
                        cb.Checked = false; // Bỏ chọn các cái khác
                    }
                }
            }
        }


        private void cLB_UnitTimeSelect_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < cLB_UnitTimeSelect.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        cLB_UnitTimeSelect.SetItemChecked(i, false);
                    }    
                }
            }
            if (e.NewValue == CheckState.Checked)
            {
                switch (cLB_UnitTimeSelect.Items[e.Index].ToString())
                {
                    case "Tuần":
                        pnRepeatDays.Enabled = true;
                        lblEveryMonth.Visible = false;
                        break;
                    case "Tháng": 
                        pnRepeatDays.Enabled = false;
                        
                        if (recurrringEvt.Start.Date != recurrringEvt.End.Date)
                        {
                            lblEveryMonth.Location = new System.Drawing.Point(160, 81);
                            lblEveryMonth.Text = $"Lặp lại vào ngày " +
                                $"{recurrringEvt.Start.Date.Day} - {recurrringEvt.End.Date.Day} hằng tháng";
                            lblEveryMonth.Visible = true;
                        }
                        else
                        {
                            lblEveryMonth.Location = new System.Drawing.Point(177, 81);
                            lblEveryMonth.Text = $"Lặp lại vào ngày " +
                                $"{recurrringEvt.Start.Date.Day} hằng tháng";
                            lblEveryMonth.Visible = true;
                        }    
                            break;
                    case "Năm": 
                        pnRepeatDays.Enabled = false;
                        
                        if (recurrringEvt.Start.Date != recurrringEvt.End.Date)
                        {
                            lblEveryMonth.Location = new System.Drawing.Point(130, 81);
                            lblEveryMonth.Text = $"Lặp lại vào ngày " +
                                $"{recurrringEvt.Start.Date.Day}/{recurrringEvt.Start.Date.Month} - " +
                                $"{recurrringEvt.End.Date.Day}/{recurrringEvt.End.Date.Month} hằng năm";
                            lblEveryMonth.Visible = true;
                        }
                        else
                        {
                            lblEveryMonth.Location = new System.Drawing.Point(177, 81);
                            lblEveryMonth.Text = $"Lặp lại vào ngày " +
                                $"{recurrringEvt.Start.Date.Day} hằng năm";
                            lblEveryMonth.Visible = true;
                        }
                        break;
                    default:
                        lblEveryMonth.Visible = false;
                        pnRepeatDays.Enabled = false;
                        break;
                }
            }
        }

        private void cbAllWeek_CheckedChanged(object sender, EventArgs e)
        {
            // Ngắt sự kiện của từng checkbox ngày để tránh vòng lặp
            foreach (Control ctrl in pnRepeatDays.Controls)
            {
                if (ctrl is CheckBox cb && cb.Text != "Cả Tuần")
                {
                    cb.CheckedChanged -= pn_DaysCB_CheckedChanged;
                }
            }

            if (cbAllWeek.Checked)
            {
                foreach (Control ctrl in pnRepeatDays.Controls)
                {
                    if (ctrl is CheckBox cb && cb.Text != "Cả Tuần")
                    {
                        cb.Checked = true;
                    }
                }
            }
            else
            {
                foreach (Control ctrl in pnRepeatDays.Controls)
                {
                    if (ctrl is CheckBox cb && cb.Text != "Cả Tuần")
                    {
                        cb.Checked = false;
                    }
                }
            }

            // Gắn lại sự kiện cho checkbox ngày
            foreach (Control ctrl in pnRepeatDays.Controls)
            {
                if (ctrl is CheckBox cb && cb.Text != "Cả Tuần")
                {
                    cb.CheckedChanged += pn_DaysCB_CheckedChanged;
                }
            }
        }

        private void pn_DaysCB_CheckedChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem tất cả ngày có được chọn không
            foreach (Control ctrl in pnRepeatDays.Controls)
            {
                if (ctrl is CheckBox cb && cb.Text != "Cả Tuần")
                {
                    if (!cb.Checked)
                    {
                        cbAllWeek.CheckedChanged -= cbAllWeek_CheckedChanged;
                        cbAllWeek.Checked = false;
                        cbAllWeek.CheckedChanged += cbAllWeek_CheckedChanged;
                        break; // chỉ cần 1 cái chưa check là đủ
                    }
                }
            }
            
        }
    }
}
