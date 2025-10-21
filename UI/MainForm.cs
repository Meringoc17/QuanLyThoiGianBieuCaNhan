using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    public partial class MainForm : Form
    {

        private DateTime currentMonth = DateTime.Today;

        private Label[,] dayLabels = new Label[6, 7]; // 42 ô ngày
        
        private Timer timerReminder;

        private User currentUser;
        private Schedule currentUser_Sched;
        private Form dropDownForm;
        private RecurringEvent recurringEvt = new RecurringEvent();
        private BindingList<EventBase> allEvents;

        //=========================================================================


        public MainForm(User user)
        {
            this.AutoScaleMode = AutoScaleMode.None; // Ngắt autoscale
            this.Font = SystemFonts.DefaultFont;     // Reset font về chuẩn
            InitializeComponent();
            currentUser = user;
            currentUser_Sched = ScheduleService.ScheduleLoad(currentUser);
            allEvents = new BindingList<EventBase>(currentUser_Sched.Events);
            InitCalendarGrid();
            // Gán BindingList vào DataGridView
            allEvents.ListChanged += (s, e) =>
            {
                if (e.ListChangedType == ListChangedType.ItemAdded)
                {
                    EventBase added = allEvents[e.NewIndex];
                    if (!currentUser_Sched.Events.Contains(added))
                        currentUser_Sched.Events.Add(added);
                }
                else if (e.ListChangedType == ListChangedType.ItemDeleted)
                {
                    // Cập nhật theo index
                    if (e.NewIndex >= 0 && e.NewIndex < currentUser_Sched.Events.Count)
                        currentUser_Sched.Events.RemoveAt(e.NewIndex);
                }
            };
            dgvEvents.DataSource = allEvents;
            
            // Khởi tạo Timer
            timerReminder = new Timer();
            timerReminder.Interval = 10000; // 1 phút
            timerReminder.Tick += timerReminder_Tick;
            timerReminder.Start();
            lbl_SignInName.Text = $"Đang đăng nhập dưới tên {currentUser.Name}";
        }


        //------------------------------code cho sự kiện lịch ---------------------------------
        /// <summary>
        /// Khởi tạo 42 ô label trong bảng lịch
        /// </summary>
        private void InitCalendarGrid()
        {
            tblCalendar.Controls.Clear();
            tblCalendar.RowCount = 6;
            tblCalendar.ColumnCount = 7;

            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Label lbl = new Label
                    {
                        Dock = DockStyle.Fill,
                        TextAlign = ContentAlignment.MiddleCenter,
                        BorderStyle = BorderStyle.None,
                        Font = new Font("Segoe UI", 10, FontStyle.Regular),
                        Cursor = Cursors.Hand
                    };
                    lbl.Click += Day_Click;
                    tblCalendar.Controls.Add(lbl, col, row);
                    dayLabels[row, col] = lbl;
                }
            }
        }

        /// <summary>
        /// Hiển thị lịch cho tháng hiện tại
        /// </summary>
        private void DisplayCalendar(DateTime month)
        {
            tblCalendar.SuspendLayout();

            lblMonthYear.Text = "Tháng " + month.Month + " năm " + month.Year;

            DateTime firstDay = new DateTime(month.Year, month.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            int startCol = ((int)firstDay.DayOfWeek + 6) % 7;

            // Reset toàn bộ lịch
            for (int r = 0; r < 6; r++)
            {
                for (int c = 0; c < 7; c++)
                {
                    Label lbl = dayLabels[r, c];
                    lbl.Text = "";
                    lbl.Tag = null;
                    lbl.BackColor = Color.White;
                    lbl.ForeColor = Color.Black;
                    lbl.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                }
            }

            // Điền ngày
            int day = 1;
            for (int i = 0; i < daysInMonth; i++)
            {
                int row = (i + startCol) / 7;
                int col = (i + startCol) % 7;

                Label lbl = dayLabels[row, col];
                DateTime date = new DateTime(month.Year, month.Month, day);

                lbl.Text = day.ToString();
                lbl.Tag = date;

                // Ngày hôm nay
                if (date.Date == DateTime.Today)
                {
                    lbl.BackColor = Color.Aquamarine;
                    lbl.ForeColor = Color.DarkBlue;
                    lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }

                // Tô đỏ nếu có sự kiện
                if (HasEventOnDate(date))
                {
                    lbl.BackColor = Color.LightPink;
                    lbl.ForeColor = Color.DarkRed;
                    lbl.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                }

                day++;
            }

            tblCalendar.ResumeLayout();
        }

        //Hàm phụ
        private bool HasEventOnDate(DateTime date)
        {
            if (currentUser_Sched == null || currentUser_Sched.Events == null)
                return false;

            foreach (EventBase ev in currentUser_Sched.Events)
            {
                DateTime startDate = ev.Start.Date;
                DateTime endDate = ev.End.Date;

                if (date >= startDate && date <= endDate)
                    return true;
            }

            return false;
        }




        /// <summary>
        /// Xử lý click vào ngày
        /// </summary>
        private void Day_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null || lbl.Tag == null)
                return;

            DateTime selectedDate = (DateTime)lbl.Tag;

            // Nếu chưa có dữ liệu lịch, thoát
            if (currentUser_Sched == null || currentUser_Sched.Events == null)
                return;

            // Tạo danh sách sự kiện cho ngày được chọn
            List<EventBase> eventsInDay = new List<EventBase>();

            foreach (EventBase ev in currentUser_Sched.Events)
            {
                DateTime startDate = ev.Start.Date;
                DateTime endDate = ev.End.Date;

                if (selectedDate >= startDate && selectedDate <= endDate)
                {
                    eventsInDay.Add(ev);
                }
            }

            // Nếu có sự kiện → mở form hiển thị
            if (eventsInDay.Count > 0)
            {
                FormEvents frm = new FormEvents(eventsInDay, selectedDate);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Không có sự kiện nào trong ngày này.",
                                "Thông báo",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }
      

        /// <summary>
        /// Tăng tháng
        /// </summary>
        /// 
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            DisplayCalendar(currentMonth);
        }

        /// <summary>
        /// Lùi tháng
        /// </summary>

        private void btnPrev_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(-1);
            DisplayCalendar(currentMonth);
        }


        /// <summary>
        /// Load Form
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            tS_totalEvent.Text = $"Tổng số việc hiện tại: {currentUser_Sched.Events.Count}";


            // Cho phép chọn ngày + giờ
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpStart.ShowUpDown = false;

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpEnd.ShowUpDown = false;

            dgvEvents.AutoGenerateColumns = true;
            dgvEvents.DataSource = null;
            dgvEvents.DataSource = allEvents;
            dgvEvents.Columns["Start"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvEvents.Columns["End"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvEvents.Columns["Reminder"].Visible = false;
            dgvEvents.Columns["DaNhacNho"].Visible = false;
            DisplayCalendar(currentMonth);
            foreach (EventBase ev in allEvents)
            {
                if (ev.Reminder != null)
                    ev.Reminder.OnReminderTriggered += Reminder_OnTriggered;
            }

        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            // 🧩 Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề cho sự kiện!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEnd.Value <= dtpStart.Value)
            {
                MessageBox.Show("Thời gian kết thúc phải sau thời gian bắt đầu!", "Lỗi thời gian",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cbPriority.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn mức độ ưu tiên!", "Thiếu thông tin",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 🧠 Tạo sự kiện lặp lại hoặc 1 lần
            if (cbRepeat.Checked && recurringEvt != null)
            {
                // Gán Reminder mặc định cho sự kiện lặp lại
                recurringEvt.Reminder = new Reminder(
                    TimeSpan.FromMinutes(1), TimeSpan.Zero,
                    "Chuẩn bị cho sự kiện lặp lại sắp diễn ra!"
                );

                allEvents.Add(recurringEvt);
                DisplayCalendar(currentMonth);

                if (recurringEvt.Reminder != null)
                {
                    recurringEvt.Reminder.OnReminderTriggered += Reminder_OnTriggered;
                    DateTime remindTime = recurringEvt.Start - recurringEvt.Reminder.BeforeStart;
                    if (DateTime.Now >= remindTime && DateTime.Now < recurringEvt.Start)
                    {
                        // 👉 Nhắc ngay
                        recurringEvt.Reminder.Trigger(recurringEvt);
                        recurringEvt.DaNhacNho = true;
                    }
                }
            }
            else
            {
                // Sự kiện 1 lần
                OneTimeEvent oneTimeEvent = new OneTimeEvent
                {
                    Title = txtTitle.Text,
                    Start = dtpStart.Value,
                    End = dtpEnd.Value,
                    Priority = cbPriority.SelectedItem.ToString(),
                    Type = cbType.SelectedItem != null ? cbType.SelectedItem.ToString() : "Công việc",
                    Reminder = new Reminder(
                        TimeSpan.FromMinutes(10), TimeSpan.Zero,
                        "Chuẩn bị cho sự kiện sắp diễn ra!"
                    
                    )

                };

                allEvents.Add(oneTimeEvent);
                DisplayCalendar(currentMonth);

                if (oneTimeEvent.Reminder != null)
                {
                    oneTimeEvent.Reminder.OnReminderTriggered += Reminder_OnTriggered;
                    DateTime remindTime = oneTimeEvent.Start - oneTimeEvent.Reminder.BeforeStart;
                    if (DateTime.Now >= remindTime && DateTime.Now < oneTimeEvent.Start)
                    {
                        // 👉 Nhắc ngay
                        oneTimeEvent.Reminder.Trigger(oneTimeEvent);
                        oneTimeEvent.DaNhacNho = true;
                    }
                }
            }

            // 🔄 Làm mới hiển thị lịch
            DisplayCalendar(currentMonth);

            // 🪶 Thông báo xác nhận
            MessageBox.Show("Đã thêm sự kiện thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Reminder_OnTriggered(Reminder sender, EventBase ev)
        {
            ev.DaNhacNho = true;
                MessageBox.Show(
                    $"⏰ {sender.Message}\nSự kiện: {ev.Title}\nBắt đầu lúc: {ev.Start:g}",
                    "Nhắc nhở",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                ); 
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // tránh flicker + tăng tốc cho bảng
            tblCalendar.DoubleBuffered(true);

            // Ngăn form tự scale theo DPI/font
            this.AutoScaleMode = AutoScaleMode.None;
            this.Scale(new SizeF(1f, 1f));

            // (tuỳ chọn) ép kích thước gốc, chỉ dùng nếu nó vẫn bị to bất thường
            // this.Size = new Size(1200, 764);
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Xóa nội dung TextBox
            txtTitle.Text = string.Empty;

            // Đặt lại DateTimePicker về ngày hiện tại
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;

            // Đặt lại ComboBox về item đầu tiên (nếu có)
            if (cbType.Items.Count > 0)
                cbType.SelectedIndex = 0;

            if (cbPriority.Items.Count > 0)
                cbPriority.SelectedIndex = 0;

            // Thông báo nhỏ để người dùng biết
            MessageBox.Show("Đã hủy nhập sự kiện!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toolStripButtonThem_Click(object sender, EventArgs e)
        {
            txtTitle.Text = "";
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
            if (cbType.Items.Count > 0) cbType.SelectedIndex = 0;
            if (cbPriority.Items.Count > 0) cbPriority.SelectedIndex = 0;
        }

        private void toolStripButtonLuu_Click(object sender, EventArgs e)
        {

            string tieuDe = txtTitle.Text;
            DateTime batDau = dtpStart.Value;
            DateTime ketThuc = dtpEnd.Value;
            string loai = cbType.SelectedItem != null ? cbType.SelectedItem.ToString() : "";
            string uuTien = cbPriority.SelectedItem != null ? cbPriority.SelectedItem.ToString() : "";

            dgvEvents.Rows.Add(tieuDe, batDau, ketThuc, loai, uuTien);

            MessageBox.Show("Đã lưu sự kiện!");
        }

        private void toolStripButtonSua_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                DataGridViewRow row = dgvEvents.CurrentRow;

                row.Cells[0].Value = txtTitle.Text;
                row.Cells[1].Value = dtpStart.Value;
                row.Cells[2].Value = dtpEnd.Value;
                row.Cells[3].Value = cbType.SelectedItem != null ? cbType.SelectedItem.ToString() : "";
                row.Cells[4].Value = cbPriority.SelectedItem != null ? cbPriority.SelectedItem.ToString() : "";

                MessageBox.Show("Đã cập nhật sự kiện!");
            }
        }

        private void toolStripButtonXoa_Click(object sender, EventArgs e)
        {
            if (dgvEvents.CurrentRow != null)
            {
                dgvEvents.Rows.Remove(dgvEvents.CurrentRow);
                MessageBox.Show("Đã xóa sự kiện!");
            }
        }

        private void toolStripButtonTai_Click(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines("sukien.csv");
            dgvEvents.Rows.Clear();

            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                dgvEvents.Rows.Add(parts);
            }

            MessageBox.Show("Đã tải dữ liệu!");
        }

        private void toolStripButtonXuatCSV_Click(object sender, EventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("sukien.csv"))
            {
                foreach (DataGridViewRow row in dgvEvents.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        string line = string.Join(",",
                            row.Cells[0].Value,
                            row.Cells[1].Value,
                            row.Cells[2].Value,
                            row.Cells[3].Value,
                            row.Cells[4].Value);
                        sw.WriteLine(line);
                    }
                }
            }

            MessageBox.Show("Đã xuất file CSV!");
        }




      


        private void tblCalendar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblUuTien_Click(object sender, EventArgs e)
        {

        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lblMonthYear_Click(object sender, EventArgs e)
        {

        }

        private void Calendar_statusStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbRepeat_CheckedChanged(object sender, EventArgs e)
        {
            if (cbRepeat.Checked)
            {
                // 🧩 Kiểm tra xem người dùng đã nhập dữ liệu cơ bản chưa
                if (string.IsNullOrWhiteSpace(txtTitle.Text))
                {
                    MessageBox.Show("Vui lòng nhập tiêu đề sự kiện trước khi đặt lặp lại!",
                        "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRepeat.Checked = false; // Tắt lại checkbox
                    return;
                }

                if (dtpEnd.Value <= dtpStart.Value)
                {
                    MessageBox.Show("Thời gian kết thúc phải sau thời gian bắt đầu!",
                        "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRepeat.Checked = false;
                    return;
                }

                if (cbPriority.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn mức độ ưu tiên!",
                        "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRepeat.Checked = false;
                    return;
                }

                // ✅ Nếu hợp lệ thì tạo recurring event và mở form cấu hình
                this.recurringEvt = new RecurringEvent
                {
                    Title = txtTitle.Text,
                    Start = dtpStart.Value,
                    End = dtpEnd.Value,
                    Priority = cbPriority.SelectedItem.ToString()
                    
                };

                RecurringEvtSettingForm repeatForm = new RecurringEvtSettingForm(recurringEvt);
                this.SubscribeToRecurrEvtForm(repeatForm);
                repeatForm.ShowDialog();
            }
            else
            {
                this.recurringEvt = null;
            }
        }


        private void comboBoxText_TextChanged(object sender, EventArgs e)
        {

        }


        private void timerReminder_Tick(object sender, EventArgs e)
        {
            foreach (EventBase ev in currentUser_Sched.Events)
            {
                if (ev.Reminder == null || ev.DaNhacNho) continue;

                DateTime remindTime = ev.Start - ev.Reminder.BeforeStart;
                if (DateTime.Now >= remindTime && !ev.DaNhacNho)
                {
                    // 👉 Kích hoạt sự kiện Reminder
                    ev.Reminder.Trigger(ev);
                    
                }
            }
        }

        private void SubscribeToRecurrEvtForm(RecurringEvtSettingForm r)
        {
            r.OnRecurrEvtSaved += RecurrEvtSavedHandler;
        }

        private void RecurrEvtSavedHandler(RecurringEvent e)
        {
            this.recurringEvt = e; // copy toàn bộ object
            MessageBox.Show($"Đã lưu cấu hình lặp lại: mỗi {e.RepeatIntervalDays} {e.RepeatUnit.ToLower()}");
            if (recurringEvt.Days != null)
            {
                this.txtRepeatDetail.Text = $"{recurringEvt.ToString().Replace("\n", "\r\n")}";
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    /// <summary>
    /// Lớp sự kiện
    /// </summary>


    public static class ControlExtensions
    {
        public static void DoubleBuffered(this Control control, bool enable)
        {
            System.Reflection.PropertyInfo prop =
                typeof(Control).GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance);
            prop.SetValue(control, enable, null);
        }
    }
}