using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    public partial class MainForm : Form
    {
        private DateTime currentMonth = DateTime.Today;

        private Label[,] dayLabels = new Label[6, 7]; // 42 ô ngày
        BindingList<MyEvent> allEvents = new BindingList<MyEvent>();
        private Timer timerReminder;



        public MainForm()
        {
            this.AutoScaleMode = AutoScaleMode.None; // Ngắt autoscale
            this.Font = SystemFonts.DefaultFont;     // Reset font về chuẩn

            InitializeComponent();
            InitCalendarGrid();

            // Gán BindingList vào DataGridView
            dgvEvents.DataSource = allEvents;

            // Khởi tạo Timer
            timerReminder = new Timer();
            timerReminder.Interval = 10000; // 1 phút
            timerReminder.Tick += timerReminder_Tick;
            timerReminder.Start();
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
         
            lblMonthYear.Text = $"Tháng {month.Month} năm {month.Year}";
            DateTime firstDay = new DateTime(month.Year, month.Month, 1);
            int daysInMonth = DateTime.DaysInMonth(month.Year, month.Month);
            int startCol = ((int)firstDay.DayOfWeek + 6) % 7;

            foreach (Label lbl in dayLabels)
            {
                lbl.Text = "";
                //lbl.BackColor = Color.White;
                //lbl.ForeColor = Color.Black;
                lbl.Tag = null;
            }

            int day = 1;
            for (int i = 0; i < daysInMonth; i++)
            {
                int row = (i + startCol) / 7;
                int col = (i + startCol) % 7;

                Label lbl = dayLabels[row, col];
                DateTime date = new DateTime(month.Year, month.Month, day);

                lbl.Text = day.ToString();
                lbl.Tag = date;

                if (date.Date == DateTime.Today)
                {
                    lbl.BackColor = Color.Aquamarine;
                    lbl.ForeColor = Color.DarkBlue;
                    lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                }

                if (allEvents.Any(ev => ev.Start.Date == date.Date))
                    lbl.ForeColor = Color.Red;

                day++;
            }

            tblCalendar.ResumeLayout();
        }


        /// <summary>
        /// Xử lý click vào ngày
        /// </summary>
        private void Day_Click(object sender, EventArgs e)
        {
            Label lbl = sender as Label;
            if (lbl == null || lbl.Tag == null) return;

            DateTime date = (DateTime)lbl.Tag;
            List<MyEvent> eventsForDay = allEvents
                .Where(ev => ev.Start.Date == date.Date)
                .ToList();

            FormEvents frm = new FormEvents(date, eventsForDay);
            frm.ShowDialog();
        }

        /// <summary>
        /// Lùi tháng
        /// </summary>


        /// <summary>
        /// Tăng tháng
        /// </summary>
        /// 
        private void btnNext_Click(object sender, EventArgs e)
        {
            currentMonth = currentMonth.AddMonths(1);
            DisplayCalendar(currentMonth);
        }
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
            // Cho phép chọn ngày + giờ
            dtpStart.Format = DateTimePickerFormat.Custom;
            dtpStart.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpStart.ShowUpDown = true;   // Hiển thị dạng spinner, dễ chỉnh giờ

            dtpEnd.Format = DateTimePickerFormat.Custom;
            dtpEnd.CustomFormat = "dd/MM/yyyy HH:mm";
            dtpEnd.ShowUpDown = true;

            dgvEvents.AutoGenerateColumns = true;
            dgvEvents.DataSource = null;
            dgvEvents.DataSource = allEvents;
            dgvEvents.Columns["Start"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgvEvents.Columns["End"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";


            DisplayCalendar(currentMonth);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MyEvent newEvent = new MyEvent
            {
                Title = txtTitle.Text,
                Start = dtpStart.Value,
                End = dtpEnd.Value,
                Type = cbType.Text,
                Priority = cbPriority.Text
            };

            allEvents.Add(newEvent); // ✅ BindingList tự động refresh DataGridView

            // Làm mới lịch (tô đỏ ngày có sự kiện)
            DisplayCalendar(currentMonth);

            MessageBox.Show("Đã thêm sự kiện thành công!");
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
        private void timerReminder_Tick(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            foreach (MyEvent sk in allEvents)
            {
                // Nếu còn <= 5 phút và chưa nhắc nhở
                if (!sk.DaNhacNho && sk.End > now && (sk.End - now).TotalMinutes <= 5)
                {
                    MessageBox.Show(
                        "Sắp đến hạn công việc: " + sk.Title +
                        "\nDeadline: " + sk.End.ToString("dd/MM/yyyy HH:mm"),
                        "Nhắc nhở",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );

                    sk.DaNhacNho = true; // đánh dấu đã nhắc
                }
            }
        }


        private void dgvEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
    }

    /// <summary>
    /// Lớp sự kiện
    /// </summary>
    public class MyEvent
    {
        public bool DaNhacNho { get; set; } = false;
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Type { get; set; }
        public string Priority { get; set; }
        // Thêm cờ để đánh dấu đã nhắc nhở rồi (tránh popup lặp nhiều lần)
        
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





    //  ------------------------------code cho phần thêm sự kiện ----------

}