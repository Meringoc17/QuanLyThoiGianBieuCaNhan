namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelRight = new System.Windows.Forms.Panel();
            this.dgvEvents = new System.Windows.Forms.DataGridView();
            this.panelunder = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.cbPriority = new System.Windows.Forms.ComboBox();
            this.lblUuTien = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblBatDau = new System.Windows.Forms.Label();
            this.lblKetThuc = new System.Windows.Forms.Label();
            this.lblLoai = new System.Windows.Forms.Label();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tblCalendar = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonThem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLuu = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSua = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonXoa = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonXuatCSV = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTai = new System.Windows.Forms.ToolStripButton();
            this.tệpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sựKiệnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trợGiúpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.panelunder.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.6383F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.3617F));
            this.tableLayoutPanel1.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 90);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1154, 612);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dgvEvents);
            this.panelRight.Controls.Add(this.panelunder);
            this.panelRight.Location = new System.Drawing.Point(452, 8);
            this.panelRight.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(695, 596);
            this.panelRight.TabIndex = 1;
            // 
            // dgvEvents
            // 
            this.dgvEvents.AllowUserToResizeColumns = false;
            this.dgvEvents.AllowUserToResizeRows = false;
            this.dgvEvents.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(9, 5);
            this.dgvEvents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.RowHeadersWidth = 82;
            this.dgvEvents.Size = new System.Drawing.Size(688, 303);
            this.dgvEvents.TabIndex = 1;
            this.dgvEvents.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEvents_CellContentClick);
            // 
            // panelunder
            // 
            this.panelunder.BackColor = System.Drawing.Color.White;
            this.panelunder.Controls.Add(this.btnCancel);
            this.panelunder.Controls.Add(this.btnSave);
            this.panelunder.Controls.Add(this.cbPriority);
            this.panelunder.Controls.Add(this.lblUuTien);
            this.panelunder.Controls.Add(this.cbType);
            this.panelunder.Controls.Add(this.dtpEnd);
            this.panelunder.Controls.Add(this.dtpStart);
            this.panelunder.Controls.Add(this.txtTitle);
            this.panelunder.Controls.Add(this.lblBatDau);
            this.panelunder.Controls.Add(this.lblKetThuc);
            this.panelunder.Controls.Add(this.lblLoai);
            this.panelunder.Controls.Add(this.lblTieuDe);
            this.panelunder.Controls.Add(this.label1);
            this.panelunder.Location = new System.Drawing.Point(9, 318);
            this.panelunder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelunder.Name = "panelunder";
            this.panelunder.Size = new System.Drawing.Size(688, 276);
            this.panelunder.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCancel.Location = new System.Drawing.Point(376, 215);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(89, 46);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnSave.Location = new System.Drawing.Point(231, 215);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 46);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // cbPriority
            // 
            this.cbPriority.FormattingEnabled = true;
            this.cbPriority.Items.AddRange(new object[] {
            "Cao",
            "Trung bình",
            "Thấp",
            ""});
            this.cbPriority.Location = new System.Drawing.Point(487, 163);
            this.cbPriority.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(108, 28);
            this.cbPriority.TabIndex = 10;
            // 
            // lblUuTien
            // 
            this.lblUuTien.BackColor = System.Drawing.SystemColors.Control;
            this.lblUuTien.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUuTien.Location = new System.Drawing.Point(371, 161);
            this.lblUuTien.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUuTien.Name = "lblUuTien";
            this.lblUuTien.Size = new System.Drawing.Size(94, 31);
            this.lblUuTien.TabIndex = 9;
            this.lblUuTien.Text = "Ưu Tiên";
            this.lblUuTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblUuTien.Click += new System.EventHandler(this.lblUuTien_Click);
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "Công Việc",
            "Cá Nhân ",
            "Lịch Họp",
            "Giải Trí",
            "Tiệc (Sinh nhật, Thôi nôi, Đám Cưới,..)"});
            this.cbType.Location = new System.Drawing.Point(142, 163);
            this.cbType.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(152, 28);
            this.cbType.TabIndex = 8;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEnd.Location = new System.Drawing.Point(487, 105);
            this.dtpEnd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(187, 29);
            this.dtpEnd.TabIndex = 7;
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(142, 105);
            this.dtpStart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(187, 29);
            this.dtpStart.TabIndex = 6;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(142, 54);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(306, 26);
            this.txtTitle.TabIndex = 5;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTitle.TextChanged += new System.EventHandler(this.txtTitle_TextChanged);
            // 
            // lblBatDau
            // 
            this.lblBatDau.BackColor = System.Drawing.SystemColors.Control;
            this.lblBatDau.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatDau.Location = new System.Drawing.Point(27, 106);
            this.lblBatDau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(93, 29);
            this.lblBatDau.TabIndex = 4;
            this.lblBatDau.Text = "Bắt Đầu";
            this.lblBatDau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKetThuc
            // 
            this.lblKetThuc.BackColor = System.Drawing.SystemColors.Control;
            this.lblKetThuc.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetThuc.Location = new System.Drawing.Point(371, 105);
            this.lblKetThuc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(94, 30);
            this.lblKetThuc.TabIndex = 3;
            this.lblKetThuc.Text = "Kết Thúc";
            this.lblKetThuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoai
            // 
            this.lblLoai.BackColor = System.Drawing.SystemColors.Control;
            this.lblLoai.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.Location = new System.Drawing.Point(27, 161);
            this.lblLoai.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(93, 31);
            this.lblLoai.TabIndex = 2;
            this.lblLoai.Text = "Loại";
            this.lblLoai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.SystemColors.Control;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(27, 54);
            this.lblTieuDe.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(93, 27);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "Tiêu Đề";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(237)))), ((int)(((byte)(254)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(688, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm Sự Kiện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Controls.Add(this.tblCalendar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(7, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(434, 596);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetDouble;
            this.tableLayoutPanel2.ColumnCount = 7;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.46905F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.24986F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.64027F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.02116F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.02116F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.55026F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.tableLayoutPanel2.Controls.Add(this.label7, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(27, 76);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(381, 61);
            this.tableLayoutPanel2.TabIndex = 2;
            this.tableLayoutPanel2.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel2_Paint);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(69)))), ((int)(((byte)(163)))));
            this.label7.Location = new System.Drawing.Point(270, 3);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 52);
            this.label7.TabIndex = 5;
            this.label7.Text = "T7";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(69)))), ((int)(((byte)(163)))));
            this.label6.Location = new System.Drawing.Point(217, 3);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 52);
            this.label6.TabIndex = 4;
            this.label6.Text = "T6";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(69)))), ((int)(((byte)(163)))));
            this.label5.Location = new System.Drawing.Point(164, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 52);
            this.label5.TabIndex = 3;
            this.label5.Text = "T5";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(69)))), ((int)(((byte)(163)))));
            this.label4.Location = new System.Drawing.Point(109, 3);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 52);
            this.label4.TabIndex = 2;
            this.label4.Text = "T4";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(69)))), ((int)(((byte)(163)))));
            this.label3.Location = new System.Drawing.Point(56, 3);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 52);
            this.label3.TabIndex = 1;
            this.label3.Text = "T3";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(69)))), ((int)(((byte)(163)))));
            this.label2.Location = new System.Drawing.Point(5, 3);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 52);
            this.label2.TabIndex = 0;
            this.label2.Text = "T2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(69)))), ((int)(((byte)(163)))));
            this.label8.Location = new System.Drawing.Point(325, 3);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 52);
            this.label8.TabIndex = 6;
            this.label8.Text = "CN";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblCalendar
            // 
            this.tblCalendar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tblCalendar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tblCalendar.ColumnCount = 7;
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.49206F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.75661F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.81481F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.02116F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.02116F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.07936F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.75661F));
            this.tblCalendar.Location = new System.Drawing.Point(27, 136);
            this.tblCalendar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tblCalendar.Name = "tblCalendar";
            this.tblCalendar.RowCount = 6;
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.Size = new System.Drawing.Size(381, 298);
            this.tblCalendar.TabIndex = 1;
            this.tblCalendar.Paint += new System.Windows.Forms.PaintEventHandler(this.tblCalendar_Paint);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightYellow;
            this.panel2.Controls.Add(this.lblMonthYear);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPrev);
            this.panel2.Location = new System.Drawing.Point(27, 23);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(381, 50);
            this.panel2.TabIndex = 0;
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(228)))), ((int)(((byte)(252)))));
            this.lblMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMonthYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(69)))), ((int)(((byte)(163)))));
            this.lblMonthYear.Location = new System.Drawing.Point(53, 5);
            this.lblMonthYear.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(272, 42);
            this.lblMonthYear.TabIndex = 1;
            this.lblMonthYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMonthYear.Click += new System.EventHandler(this.lblMonthYear_Click);
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNext.Location = new System.Drawing.Point(334, 5);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(43, 42);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPrev.Location = new System.Drawing.Point(3, 5);
            this.btnPrev.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(42, 42);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            this.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonThem,
            this.toolStripButtonLuu,
            this.toolStripButtonSua,
            this.toolStripButtonXoa,
            this.toolStripButtonXuatCSV,
            this.toolStripButtonTai});
            this.toolStrip.Location = new System.Drawing.Point(0, 33);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip.Size = new System.Drawing.Size(1178, 54);
            this.toolStrip.TabIndex = 2;
            this.toolStrip.Text = "ToolBar";
            // 
            // toolStripButtonThem
            // 
            this.toolStripButtonThem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonThem.Image")));
            this.toolStripButtonThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonThem.Name = "toolStripButtonThem";
            this.toolStripButtonThem.Size = new System.Drawing.Size(92, 49);
            this.toolStripButtonThem.Text = "Thêm";
            this.toolStripButtonThem.Click += new System.EventHandler(this.toolStripButtonThem_Click);
            // 
            // toolStripButtonLuu
            // 
            this.toolStripButtonLuu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLuu.Image")));
            this.toolStripButtonLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLuu.Name = "toolStripButtonLuu";
            this.toolStripButtonLuu.Size = new System.Drawing.Size(77, 49);
            this.toolStripButtonLuu.Text = "Lưu";
            this.toolStripButtonLuu.Click += new System.EventHandler(this.toolStripButtonLuu_Click);
            // 
            // toolStripButtonSua
            // 
            this.toolStripButtonSua.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSua.Image")));
            this.toolStripButtonSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSua.Name = "toolStripButtonSua";
            this.toolStripButtonSua.Size = new System.Drawing.Size(78, 49);
            this.toolStripButtonSua.Text = "Sửa";
            this.toolStripButtonSua.Click += new System.EventHandler(this.toolStripButtonSua_Click);
            // 
            // toolStripButtonXoa
            // 
            this.toolStripButtonXoa.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonXoa.Image")));
            this.toolStripButtonXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXoa.Name = "toolStripButtonXoa";
            this.toolStripButtonXoa.Size = new System.Drawing.Size(79, 49);
            this.toolStripButtonXoa.Text = "Xóa";
            this.toolStripButtonXoa.Click += new System.EventHandler(this.toolStripButtonXoa_Click);
            // 
            // toolStripButtonXuatCSV
            // 
            this.toolStripButtonXuatCSV.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonXuatCSV.Image")));
            this.toolStripButtonXuatCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXuatCSV.Name = "toolStripButtonXuatCSV";
            this.toolStripButtonXuatCSV.Size = new System.Drawing.Size(121, 49);
            this.toolStripButtonXuatCSV.Text = "Xuất CSV";
            this.toolStripButtonXuatCSV.Click += new System.EventHandler(this.toolStripButtonXuatCSV_Click);
            // 
            // toolStripButtonTai
            // 
            this.toolStripButtonTai.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTai.Name = "toolStripButtonTai";
            this.toolStripButtonTai.Size = new System.Drawing.Size(38, 49);
            this.toolStripButtonTai.Text = "Tải";
            this.toolStripButtonTai.Click += new System.EventHandler(this.toolStripButtonTai_Click);
            // 
            // tệpToolStripMenuItem
            // 
            this.tệpToolStripMenuItem.Name = "tệpToolStripMenuItem";
            this.tệpToolStripMenuItem.Size = new System.Drawing.Size(62, 29);
            this.tệpToolStripMenuItem.Text = "Tệp ";
            // 
            // sựKiệnToolStripMenuItem
            // 
            this.sựKiệnToolStripMenuItem.Name = "sựKiệnToolStripMenuItem";
            this.sựKiệnToolStripMenuItem.Size = new System.Drawing.Size(87, 29);
            this.sựKiệnToolStripMenuItem.Text = "Sự Kiện";
            // 
            // xemToolStripMenuItem
            // 
            this.xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            this.xemToolStripMenuItem.Size = new System.Drawing.Size(64, 29);
            this.xemToolStripMenuItem.Text = "Xem";
            // 
            // trợGiúpToolStripMenuItem1
            // 
            this.trợGiúpToolStripMenuItem1.Name = "trợGiúpToolStripMenuItem1";
            this.trợGiúpToolStripMenuItem1.Size = new System.Drawing.Size(94, 29);
            this.trợGiúpToolStripMenuItem1.Text = "Trợ Giúp";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tệpToolStripMenuItem,
            this.sựKiệnToolStripMenuItem,
            this.xemToolStripMenuItem,
            this.trợGiúpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1178, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(222)))), ((int)(((byte)(254)))));
            this.ClientSize = new System.Drawing.Size(1178, 714);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "Quản Lý Thời Gian Biểu Cá Nhân";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.panelunder.ResumeLayout(false);
            this.panelunder.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton toolStripButtonThem;
        private System.Windows.Forms.ToolStripButton toolStripButtonLuu;
        private System.Windows.Forms.ToolStripButton toolStripButtonSua;
        private System.Windows.Forms.ToolStripButton toolStripButtonXoa;
        private System.Windows.Forms.ToolStripButton toolStripButtonXuatCSV;
        private System.Windows.Forms.ToolStripButton toolStripButtonTai;
        private System.Windows.Forms.ToolStripMenuItem tệpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sựKiệnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trợGiúpToolStripMenuItem1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblMonthYear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.TableLayoutPanel tblCalendar;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.DataGridView dgvEvents;
       
        private System.Windows.Forms.Panel panelunder;
        private System.Windows.Forms.Label lblBatDau;
        private System.Windows.Forms.Label lblKetThuc;
        private System.Windows.Forms.Label lblLoai;
        private System.Windows.Forms.Label lblTieuDe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.ComboBox cbPriority;
        private System.Windows.Forms.Label lblUuTien;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

