namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblCalendar = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblMonthYear = new System.Windows.Forms.Label();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnPrev = new System.Windows.Forms.Button();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
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
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panelRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).BeginInit();
            this.panelunder.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.OutsetPartial;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.08864F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.91136F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelRight, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 65);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(722, 362);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tblCalendar);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 275);
            this.panel1.TabIndex = 0;
            // 
            // tblCalendar
            // 
            this.tblCalendar.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.InsetDouble;
            this.tblCalendar.ColumnCount = 7;
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tblCalendar.Location = new System.Drawing.Point(3, 29);
            this.tblCalendar.Name = "tblCalendar";
            this.tblCalendar.RowCount = 6;
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tblCalendar.Size = new System.Drawing.Size(263, 246);
            this.tblCalendar.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblMonthYear);
            this.panel2.Controls.Add(this.btnNext);
            this.panel2.Controls.Add(this.btnPrev);
            this.panel2.Location = new System.Drawing.Point(-3, -3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(272, 29);
            this.panel2.TabIndex = 0;
            // 
            // lblMonthYear
            // 
            this.lblMonthYear.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblMonthYear.Location = new System.Drawing.Point(43, 3);
            this.lblMonthYear.Name = "lblMonthYear";
            this.lblMonthYear.Size = new System.Drawing.Size(185, 26);
            this.lblMonthYear.TabIndex = 1;
            this.lblMonthYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNext
            // 
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnNext.Location = new System.Drawing.Point(228, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(40, 26);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = ">";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnPrev
            // 
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnPrev.Location = new System.Drawing.Point(3, 3);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(40, 26);
            this.btnPrev.TabIndex = 0;
            this.btnPrev.Text = "<";
            this.btnPrev.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.dgvEvents);
            this.panelRight.Controls.Add(this.panelunder);
            this.panelRight.Location = new System.Drawing.Point(280, 6);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(436, 350);
            this.panelRight.TabIndex = 1;
            // 
            // dgvEvents
            // 
            this.dgvEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvents.Location = new System.Drawing.Point(0, 0);
            this.dgvEvents.Name = "dgvEvents";
            this.dgvEvents.RowHeadersWidth = 82;
            this.dgvEvents.Size = new System.Drawing.Size(436, 197);
            this.dgvEvents.TabIndex = 1;
            // 
            // panelunder
            // 
            this.panelunder.BackColor = System.Drawing.SystemColors.ControlLightLight;
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
            this.panelunder.Location = new System.Drawing.Point(-2, 197);
            this.panelunder.Name = "panelunder";
            this.panelunder.Size = new System.Drawing.Size(438, 153);
            this.panelunder.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnCancel.Location = new System.Drawing.Point(220, 127);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(56, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.HighlightText;
            this.btnSave.Location = new System.Drawing.Point(147, 127);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(56, 23);
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
            this.cbPriority.Location = new System.Drawing.Point(305, 104);
            this.cbPriority.Name = "cbPriority";
            this.cbPriority.Size = new System.Drawing.Size(73, 21);
            this.cbPriority.TabIndex = 10;
            // 
            // lblUuTien
            // 
            this.lblUuTien.BackColor = System.Drawing.SystemColors.Control;
            this.lblUuTien.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUuTien.Location = new System.Drawing.Point(236, 101);
            this.lblUuTien.Name = "lblUuTien";
            this.lblUuTien.Size = new System.Drawing.Size(63, 22);
            this.lblUuTien.TabIndex = 9;
            this.lblUuTien.Text = "Ưu Tiẻn";
            this.lblUuTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.cbType.Location = new System.Drawing.Point(74, 104);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(103, 21);
            this.cbType.TabIndex = 8;
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpEnd.Location = new System.Drawing.Point(305, 70);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(124, 22);
            this.dtpEnd.TabIndex = 7;
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(74, 67);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(125, 22);
            this.dtpStart.TabIndex = 6;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(74, 32);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(205, 20);
            this.txtTitle.TabIndex = 5;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblBatDau
            // 
            this.lblBatDau.BackColor = System.Drawing.SystemColors.Control;
            this.lblBatDau.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatDau.Location = new System.Drawing.Point(5, 67);
            this.lblBatDau.Name = "lblBatDau";
            this.lblBatDau.Size = new System.Drawing.Size(59, 22);
            this.lblBatDau.TabIndex = 4;
            this.lblBatDau.Text = "Bắt Đầu";
            this.lblBatDau.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblKetThuc
            // 
            this.lblKetThuc.BackColor = System.Drawing.SystemColors.Control;
            this.lblKetThuc.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKetThuc.Location = new System.Drawing.Point(236, 67);
            this.lblKetThuc.Name = "lblKetThuc";
            this.lblKetThuc.Size = new System.Drawing.Size(63, 22);
            this.lblKetThuc.TabIndex = 3;
            this.lblKetThuc.Text = "Kết Thúc";
            this.lblKetThuc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLoai
            // 
            this.lblLoai.BackColor = System.Drawing.SystemColors.Control;
            this.lblLoai.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoai.Location = new System.Drawing.Point(5, 101);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(50, 22);
            this.lblLoai.TabIndex = 2;
            this.lblLoai.Text = "Loại";
            this.lblLoai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.BackColor = System.Drawing.SystemColors.Control;
            this.lblTieuDe.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTieuDe.Location = new System.Drawing.Point(5, 32);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(62, 21);
            this.lblTieuDe.TabIndex = 1;
            this.lblTieuDe.Text = "Tiêu Đề";
            this.lblTieuDe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.Location = new System.Drawing.Point(2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(436, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Thêm Sự Kiện";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonThem,
            this.toolStripButtonLuu,
            this.toolStripButtonSua,
            this.toolStripButtonXoa,
            this.toolStripButtonXuatCSV,
            this.toolStripButtonTai});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(722, 26);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonThem
            // 
            this.toolStripButtonThem.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonThem.Image")));
            this.toolStripButtonThem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonThem.Name = "toolStripButtonThem";
            this.toolStripButtonThem.Size = new System.Drawing.Size(74, 23);
            this.toolStripButtonThem.Text = "Thêm";
            this.toolStripButtonThem.Click += new System.EventHandler(this.toolStripButtonThem_Click);
            // 
            // toolStripButtonLuu
            // 
            this.toolStripButtonLuu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLuu.Image")));
            this.toolStripButtonLuu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLuu.Name = "toolStripButtonLuu";
            this.toolStripButtonLuu.Size = new System.Drawing.Size(63, 23);
            this.toolStripButtonLuu.Text = "Lưu";
            this.toolStripButtonLuu.Click += new System.EventHandler(this.toolStripButtonLuu_Click);
            // 
            // toolStripButtonSua
            // 
            this.toolStripButtonSua.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSua.Image")));
            this.toolStripButtonSua.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSua.Name = "toolStripButtonSua";
            this.toolStripButtonSua.Size = new System.Drawing.Size(62, 23);
            this.toolStripButtonSua.Text = "Sửa";
            this.toolStripButtonSua.Click += new System.EventHandler(this.toolStripButtonSua_Click);
            // 
            // toolStripButtonXoa
            // 
            this.toolStripButtonXoa.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonXoa.Image")));
            this.toolStripButtonXoa.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXoa.Name = "toolStripButtonXoa";
            this.toolStripButtonXoa.Size = new System.Drawing.Size(63, 23);
            this.toolStripButtonXoa.Text = "Xóa";
            this.toolStripButtonXoa.Click += new System.EventHandler(this.toolStripButtonXoa_Click);
            // 
            // toolStripButtonXuatCSV
            // 
            this.toolStripButtonXuatCSV.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonXuatCSV.Image")));
            this.toolStripButtonXuatCSV.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonXuatCSV.Name = "toolStripButtonXuatCSV";
            this.toolStripButtonXuatCSV.Size = new System.Drawing.Size(91, 23);
            this.toolStripButtonXuatCSV.Text = "Xuất CSV";
            this.toolStripButtonXuatCSV.Click += new System.EventHandler(this.toolStripButtonXuatCSV_Click);
            // 
            // toolStripButtonTai
            // 
            this.toolStripButtonTai.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTai.Name = "toolStripButtonTai";
            this.toolStripButtonTai.Size = new System.Drawing.Size(27, 23);
            this.toolStripButtonTai.Text = "Tải";
            this.toolStripButtonTai.Click += new System.EventHandler(this.toolStripButtonTai_Click);
            // 
            // tệpToolStripMenuItem
            // 
            this.tệpToolStripMenuItem.Name = "tệpToolStripMenuItem";
            this.tệpToolStripMenuItem.Size = new System.Drawing.Size(42, 22);
            this.tệpToolStripMenuItem.Text = "Tệp ";
            // 
            // sựKiệnToolStripMenuItem
            // 
            this.sựKiệnToolStripMenuItem.Name = "sựKiệnToolStripMenuItem";
            this.sựKiệnToolStripMenuItem.Size = new System.Drawing.Size(58, 22);
            this.sựKiệnToolStripMenuItem.Text = "Sự Kiện";
            // 
            // xemToolStripMenuItem
            // 
            this.xemToolStripMenuItem.Name = "xemToolStripMenuItem";
            this.xemToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.xemToolStripMenuItem.Text = "Xem";
            // 
            // trợGiúpToolStripMenuItem1
            // 
            this.trợGiúpToolStripMenuItem1.Name = "trợGiúpToolStripMenuItem1";
            this.trợGiúpToolStripMenuItem1.Size = new System.Drawing.Size(72, 22);
            this.trợGiúpToolStripMenuItem1.Text = "? Trợ Giúp";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tệpToolStripMenuItem,
            this.sựKiệnToolStripMenuItem,
            this.xemToolStripMenuItem,
            this.trợGiúpToolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(722, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 60000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 427);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Quản Lý Thời Gian Biểu Cá Nhân";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panelRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvents)).EndInit();
            this.panelunder.ResumeLayout(false);
            this.panelunder.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip1;
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
    }
}

