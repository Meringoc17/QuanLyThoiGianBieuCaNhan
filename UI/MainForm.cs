using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Exceptions;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Models;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.Services;
using QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    public partial class pnSort : Form
    {

        private DateTime currentMonth = DateTime.Today;

        private Label[,] dayLabels = new Label[6, 7]; // 42 ô ngày

        private Timer timerReminder;

        private User currentUser;
        private Schedule currentUser_Sched;
        private string scheduleFilePath;

        private Form dropDownForm;
        private RecurringEvent recurringEvt = new RecurringEvent();
        private BindingList<EventBase> allEvents;

        //=========================================================================

        public pnSort(User user)
        {
            this.AutoScaleMode = AutoScaleMode.None; // Ngắt autoscale
            this.Font = SystemFonts.DefaultFont;     // Reset font về chuẩn
            InitializeComponent();
            currentUser = user;
            scheduleFilePath = Path.Combine(
             Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
              $"schedule_{currentUser.Name}.dat"
);

            //currentUser_Sched = ScheduleService.ScheduleLoad(currentUser);

            // 🔹 Tự động load dữ liệu sự kiện của user từ file .dat
            if (File.Exists(scheduleFilePath))
            {
                try
                {
                    using (FileStream fs = new FileStream(scheduleFilePath, FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        currentUser_Sched = (Schedule)bf.Deserialize(fs);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi đọc file lịch: {ex.Message}");
                    currentUser_Sched = new Schedule(currentUser);
                }
            }
            else
            {
                // 🔹 Nếu chưa có file => tạo mới Schedule trống
                currentUser_Sched = new Schedule(currentUser);
            }

            // ✅ Luôn đảm bảo allEvents không null
            allEvents = new BindingList<EventBase>(currentUser_Sched.Events);
            InitCalendarGrid();

            try
            {
                // Gán BindingList vào DataGridView
                allEvents.ListChanged += (s, e) =>
                {
                    if (e.ListChangedType == ListChangedType.ItemAdded)
                    {
                        EventBase added = allEvents[e.NewIndex];
                        if (!currentUser_Sched.Events.Contains(added))
                        {
                            currentUser_Sched.AddEvent(added);
                        }

                    }
                    else if (e.ListChangedType == ListChangedType.ItemDeleted)
                    {
                        // Cập nhật theo index
                        if (e.NewIndex >= 0 && e.NewIndex < currentUser_Sched.Events.Count)
                            currentUser_Sched.Events = allEvents.ToList();
                        statusStrip_Update();
                        if (File.Exists(scheduleFilePath))
                        {
                            try
                            {
                                using (FileStream fs = new FileStream(scheduleFilePath, FileMode.Create))
                                {
                                    BinaryFormatter bf = new BinaryFormatter();
                                    bf.Serialize(fs, currentUser_Sched); // ✅ Serialize nguyên Schedule
                                }
                            }
                            catch (DataFileException ex)
                            {
                                MessageBox.Show($"Lỗi khi đọc file lịch: {ex.Message}");
                                allEvents = new BindingList<EventBase>(new List<EventBase>());
                                throw new DataFileException("Lỗi khi đọc file lịch.", ex);
                            }
                        }

                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine("Có lỗi trong BindingList handler: " + ex.Message);
                throw; // vẫn giữ nguyên lỗi gốc
            }

            dgvEvents.DataSource = allEvents;
            dgvEvents.ClearSelection();
            if (dgvEvents.Rows.Count > 0)
            {
                dgvEvents.CurrentCell = dgvEvents.Rows[0].Cells[0];
                dgvEvents.Rows[0].Selected = true;
            }

            // Khởi tạo Timer
            timerReminder = new Timer();
            timerReminder.Interval = 1000; // 1 min
            timerReminder.Tick += timerReminder_Tick;
            timerReminder.Start();
            timer_Time.Interval = 1000;
            timer_Time.Start();
            string dateTime = DateTime.Now.ToString("HH:mm:ss");
            tS_Time.Text = "Time: " + dateTime.ToString();
            lbl_SignInName.Text = $"Đang đăng nhập dưới tên {currentUser.Name}";

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

        private void Form1_Load(object sender, EventArgs e)
        {
            statusStrip_Update();

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
            dgvEvents.Columns["EnableReminder"].Visible = false;

            // ⚙️ Tạo cột checkbox "Hoàn thành" nếu chưa có
            if (!dgvEvents.Columns.Contains("Status"))
            {
                DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
                chkCol.HeaderText = "Hoàn thành";
                chkCol.Name = "Status";
                chkCol.DataPropertyName = "Status"; // phải trùng property trong EventBase
                dgvEvents.Columns.Add(chkCol);
            }

            // ⚙️ Gắn sự kiện thủ công (không dùng lambda)
            dgvEvents.CurrentCellDirtyStateChanged += dgvEvents_CurrentCellDirtyStateChanged;
            dgvEvents.CellValueChanged += dgvEvents_CellValueChanged;
            DisplayCalendar(currentMonth);
            foreach (EventBase ev in allEvents)
            {
                if (ev.Reminder != null && ev.EnableReminder)
                    ev.Reminder.OnReminderTriggered += Reminder_OnTriggered;
            }

            GenerateRecurringEventsOnLoad();

        }



        //------------------------------code cho sự kiện lịch ---------------------------------
        /// <summary>
        /// Khởi tạo 42 ô label trong bảng lịch
        /// </summary>
        /// 
        private void GenerateRecurringEventsOnLoad()
        {
            List<RecurringEvent> newEvents = new List<RecurringEvent>();

            foreach (EventBase ev in currentUser_Sched.Events)
            {
                if (ev is RecurringEvent r)
                {
                    while (r.End < DateTime.Now &&
                          (r.EndDate == DateTime.MinValue || r.EndDate > DateTime.Now) &&
                          (r.Occurrences == null || r.Occurrences > 0))
                    {
                        RecurringEvent newEvt = EventManager.RCEvt_AutoGenerate(currentUser_Sched, r);
                        if (newEvt == null) break;
                        newEvents.Add(newEvt);

                        // Cập nhật r để tiếp tục sinh event tiếp theo
                        r = newEvt;
                    }
                }
            }

            foreach (RecurringEvent ev in newEvents)
                allEvents.Add(ev);

            DisplayCalendar(currentMonth);
        }
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

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép chữ số và phím điều khiển (Backspace, Delete, v.v.)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // chặn ký tự không hợp lệ
            }
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


        private void dgvEvents_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dgvEvents.IsCurrentCellDirty)
            {
                dgvEvents.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dgvEvents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvEvents.Columns[e.ColumnIndex].Name == "Status")
            {
                DataGridViewRow row = dgvEvents.Rows[e.RowIndex];
                bool isDone = false;

                if (row.Cells["Status"].Value != null)
                    isDone = Convert.ToBoolean(row.Cells["Status"].Value);

                // ✅ Đổi màu nền và chữ
                if (isDone)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.Green;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                    row.DefaultCellStyle.ForeColor = Color.Black;
                }

                // ✅ Cập nhật dữ liệu thật
                if (e.RowIndex < allEvents.Count)
                {
                    allEvents[e.RowIndex].Status = isDone;
                }

                statusStrip_Update();
            }
            // Lưu file khi có thay đổi trạng thái
            try
            {
                using (FileStream fs = new FileStream(scheduleFilePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, currentUser_Sched);
                }
            }
            catch (DataFileException ex)
            {
                throw new DataFileException("Lỗi khi auto-save sự kiện", ex);
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

            if (dtpStart.Value < DateTime.Now)
            {
                MessageBox.Show("Vui lòng chọn lại thời gian bắt đầu, đúng hoặc sau thời gian hiện tại !",
                    "Không hợp lệ",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                recurringEvt.EnableReminder = cB_ReminderOn.Checked;

                // 🧠 Tạo sự kiện lặp lại hoặc 1 lần

                if (cbRepeat.Checked && recurringEvt != null)
                {
                    try
                    {
                        if (recurringEvt.EnableReminder)
                        {
                            int result;
                            if (int.TryParse(txtTimeb4Event.Text, out result))
                            {
                                recurringEvt.Reminder = ReminderService.CreateReminder(
                                    ReminderService.UnitConverter(result, cboBox_TimeUnit.SelectedItem.ToString())
                                );
                            }
                            else
                            {
                                MessageBox.Show("Giá trị thời gian không hợp lệ!");
                            }
                        }
                        allEvents.Add(new RecurringEvent(recurringEvt));
                        DisplayCalendar(currentMonth);

                        if (recurringEvt.Reminder != null && recurringEvt.EnableReminder)
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
                    catch (Exception ex)
                    {
                        throw new RcEvtException("Lỗi không lưu được sự kiện lặp lại", ex);
                    }
                }
                else
                {
                    try
                    {
                        bool enbReminder = cB_ReminderOn.Checked;
                        Reminder reminder = new Reminder();
                        if (enbReminder)
                        {
                            int result;
                            if (int.TryParse(txtTimeb4Event.Text, out result))
                            {
                                reminder = ReminderService.CreateReminder(
                                    ReminderService.UnitConverter(result, cboBox_TimeUnit.SelectedItem.ToString())
                                );
                            }
                            else
                            {
                                MessageBox.Show("Giá trị thời gian không hợp lệ!");
                            }
                        }
                        // Sự kiện 1 lần
                        OneTimeEvent oneTimeEvent = new OneTimeEvent
                        {
                            Title = txtTitle.Text,
                            Start = dtpStart.Value,
                            End = dtpEnd.Value,
                            Priority = cbPriority.SelectedItem.ToString(),
                            Type = cbType.SelectedItem != null ? cbType.SelectedItem.ToString() : "Công việc",
                            EnableReminder = enbReminder,
                            //if (cB_ReminderOn.Checked)
                            Reminder = reminder

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
                    catch (Exception ex)
                    {
                        throw new OTEvtException("Lỗi không lưu được sự kiện", ex);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm vào sự kiện: " + ex.Message);
                throw;
            }

            // 🔄 Làm mới hiển thị lịch
            DisplayCalendar(currentMonth);
            statusStrip_Update();

            // 🪶 Thông báo xác nhận
            MessageBox.Show("Đã thêm sự kiện thành công!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            // 💾 Lưu lại dữ liệu sự kiện vào file binary
            try
            {
                using (FileStream fs = new FileStream(scheduleFilePath, FileMode.Create))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, currentUser_Sched);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu file sự kiện: " + ex.Message);
            }

        }

        private void statusStrip_Update()
        {
            tS_totalEvent.Text = $" Tổng số việc hiện tại: {currentUser_Sched.Events.Count} ";
            int done = 0;
            int undone = 0;

            foreach (EventBase ev in currentUser_Sched.Events)
            {
                if (ev.Status)
                {
                    done++;
                }
                else
                {
                    undone++;
                }
            }
            tS_Finished.Text = $" Đã làm xong: {done} ";
            tS_Undone.Text = $" Chưa làm xong: {undone} ";

        }

        private void Reminder_OnTriggered(Reminder sender, EventBase ev)
        {
            if (ev.EnableReminder)
            {
                ev.DaNhacNho = true;
                MessageBox.Show(
                    $"⏰ {sender.Message}\nSự kiện: {ev.Title}\nBắt đầu lúc: {ev.Start:g}",
                    "Nhắc nhở",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
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
            if (dgvEvents.CurrentRow != null && dgvEvents.SelectedRows.Count == 1)
            {
                int index = dgvEvents.CurrentRow.Index;

                if (index >= 0 && index < allEvents.Count)
                {
                    EventBase ev = (EventBase)dgvEvents.CurrentRow.DataBoundItem;
                    allEvents.Remove(ev);
                }
            }
            else if (dgvEvents.CurrentRow != null && dgvEvents.SelectedRows.Count > 1)
            {
                for (int i = 0; i < dgvEvents.SelectedRows.Count; i++)
                {
                    EventBase ev = (EventBase)dgvEvents.SelectedRows[i].DataBoundItem;
                    allEvents.Remove(ev);
                }
                EventBase ev2 = (EventBase)dgvEvents.SelectedRows[0].DataBoundItem;
                allEvents.Remove(ev2);
            }

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

                if (dtpStart.Value <= DateTime.Now)
                {
                    MessageBox.Show("Thời gian bắt đầu phải sau thời gian hiện tại!",
                        "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRepeat.Checked = false;
                    return;
                }

                if (dtpEnd.Value <= DateTime.Now)
                {
                    MessageBox.Show("Thời gian kết thúc thời gian hiện tại!",
                        "Lỗi thời gian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbRepeat.Checked = false;
                    return;
                }

                if (string.IsNullOrEmpty(txtRepeatDetail.Text))
                {
                    // ✅ Nếu hợp lệ thì tạo recurring event và mở form cấu hình
                    this.recurringEvt = new RecurringEvent
                    {
                        Title = txtTitle.Text,
                        Start = dtpStart.Value,
                        End = dtpEnd.Value,
                        Priority = cbPriority.SelectedItem.ToString(),
                        Type = cbType.SelectedItem != null ? cbType.SelectedItem.ToString() : ""
                    };

                    RecurringEvtSettingForm repeatForm = new RecurringEvtSettingForm(recurringEvt);
                    this.SubscribeToRecurrEvtForm(repeatForm);
                    repeatForm.ShowDialog();
                }
                else
                {
                    RecurringEvtSettingForm repeatForm = new RecurringEvtSettingForm(recurringEvt);
                    this.SubscribeToRecurrEvtForm(repeatForm);
                    repeatForm.ShowDialog();
                } 
                    
            }
            else
            {
                //this.recurringEvt = null;
            }
        }

        private void timerReminder_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            //now = new DateTime(now.Year, now.Month, now.Day, now.Hour, now.Minute, 0);

            // 🔔 1. Kiểm tra các sự kiện có Reminder
            foreach (EventBase ev in currentUser_Sched.Events)
            {
                if (ev == null || !ev.EnableReminder || ev.DaNhacNho)
                    continue;

                DateTime remindTime = ev.Start - ev.Reminder.BeforeStart;

                // Nếu đã đến thời gian nhắc nhở
                if (now >= remindTime && !ev.DaNhacNho)
                {
                    ev.Reminder.Trigger(ev);
                    ev.DaNhacNho = true;
                }
            }

            // 🎨 2. Cập nhật màu trong DataGridView
            foreach (DataGridViewRow row in dgvEvents.Rows)
            {
                if (row.IsNewRow) continue;

                bool isDone = false;
                if (row.Cells["Status"].Value != null)
                    isDone = Convert.ToBoolean(row.Cells["Status"].Value);

                // Mặc định
                row.DefaultCellStyle.ForeColor = Color.Black;
                row.DefaultCellStyle.BackColor = Color.White;

                // Đã hoàn thành ✅
                if (isDone)
                {
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    continue;
                }

                // Chưa hoàn thành → kiểm tra thời gian
                if (DateTime.TryParse(row.Cells["Start"].Value?.ToString(), out DateTime startTime) &&
                    DateTime.TryParse(row.Cells["End"].Value?.ToString(), out DateTime endTime))
                {

                    if (now > endTime)
                    {
                        // ⛔ Quá hạn
                        row.DefaultCellStyle.ForeColor = Color.Red;
                        row.DefaultCellStyle.BackColor = Color.MistyRose;

                        List<RecurringEvent> newEvents = new List<RecurringEvent>();
                        List<RecurringEvent> removeOldEvts = new List<RecurringEvent>();

                        foreach (EventBase re in currentUser_Sched.Events)
                        {
                            if (re is RecurringEvent r)
                            {
                                RecurringEvent newEvt = EventManager.rcEvt_EndGenLoop(currentUser_Sched, r);
                                if (newEvt != null)
                                    newEvents.Add(newEvt);
                                removeOldEvts.Add(r);
                            }

                        }

                        // ✅ Add vào cả Schedule lẫn UI BindingList
                        foreach (RecurringEvent ev in newEvents)
                        {
                            allEvents.Add(ev);
                        }

                        foreach (RecurringEvent ev in removeOldEvts)
                        {
                            allEvents.Remove(ev);
                        }

                        if (newEvents.Count > 0)
                        {
                            DisplayCalendar(currentMonth); // cập nhật lịch
                            allEvents.ResetBindings();     // cập nhật bảng
                        }

                    }
                    else if (now >= startTime && now <= endTime)
                    {
                        // 🔵 Đang diễn ra
                        row.DefaultCellStyle.ForeColor = Color.RoyalBlue;
                        row.DefaultCellStyle.BackColor = Color.LightCyan;
                    }
                    else
                    {
                        // 🟡 Chưa tới (sắp diễn ra)
                        TimeSpan timeLeft = startTime - now;
                        if (timeLeft.TotalMinutes <= 15) // ví dụ: nhắc màu vàng nếu còn ≤15 phút
                        {
                            row.DefaultCellStyle.ForeColor = Color.DarkOrange;
                            row.DefaultCellStyle.BackColor = Color.LemonChiffon;
                        }
                    }
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

        private void lblSignOut_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn muốn đăng xuất ?",
                "Đăng Xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
             );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Đã đăng xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Hide();
                UserLogin login = new UserLogin();
                login.ShowDialog();
                this.Close();
            }

            if (result == DialogResult.No)
            {
                result = DialogResult.OK;
            }

        }

        private void timer_Time_Tick(object sender, EventArgs e)
        {
            // Gọi hàm kiểm tra nhắc nhở
            ReminderService.CheckReminders(currentUser_Sched.Events);
            string dateTime = DateTime.Now.ToString("HH:mm:ss");
            tS_Time.Text = "Time:  " + dateTime.ToString();

        }

        private void cB_ReminderOn_CheckedChanged(object sender, EventArgs e)
        {
            if (cB_ReminderOn.Checked)
            {
                txtTimeb4Event.Enabled = true;
                cboBox_TimeUnit.Enabled = true;
            }
            else
            {
                txtTimeb4Event.Enabled = false;
                cboBox_TimeUnit.Enabled = false;
            }
        }

        private void toolStripBtnEvtDetail_Click(object sender, EventArgs e)
        {
            if (dgvEvents.SelectedRows.Count > 1)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng sự kiện để xem!");
                return;

            }
            else if (dgvEvents.SelectedRows.Count == 1)
            {
                EventDetailForm f = new EventDetailForm((EventBase)dgvEvents.SelectedRows[0].DataBoundItem);
                f.ShowDialog();
            }    
        }

        private void cbCategory_CheckedChanged(object sender, EventArgs e)
        {

        }
    }


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