namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    partial class RecurringEvtSettingForm
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
            this.pnRepeatAfterTimeUnit = new System.Windows.Forms.Panel();
            this.lblEveryMonth = new System.Windows.Forms.Label();
            this.cLB_UnitTimeSelect = new System.Windows.Forms.CheckedListBox();
            this.txtBox_NumTimeUnit = new System.Windows.Forms.TextBox();
            this.lblRepeat = new System.Windows.Forms.Label();
            this.pnRepeatDays = new System.Windows.Forms.Panel();
            this.cbAllWeek = new System.Windows.Forms.CheckBox();
            this.cB_Sun = new System.Windows.Forms.CheckBox();
            this.cB_Fri = new System.Windows.Forms.CheckBox();
            this.cB_Sat = new System.Windows.Forms.CheckBox();
            this.cB_Thurs = new System.Windows.Forms.CheckBox();
            this.cB_Weds = new System.Windows.Forms.CheckBox();
            this.cB_Tues = new System.Windows.Forms.CheckBox();
            this.cB_Mon = new System.Windows.Forms.CheckBox();
            this.lblRepeatDays = new System.Windows.Forms.Label();
            this.pnOverSetting = new System.Windows.Forms.Panel();
            this.txtBox_Times = new System.Windows.Forms.TextBox();
            this.dtPicker_DaySelect = new System.Windows.Forms.DateTimePicker();
            this.cB_AfterTimes = new System.Windows.Forms.CheckBox();
            this.cB_Overday = new System.Windows.Forms.CheckBox();
            this.cB_Never = new System.Windows.Forms.CheckBox();
            this.lblEnd = new System.Windows.Forms.Label();
            this.btn_Done = new System.Windows.Forms.Button();
            this.lblConfigTitle = new System.Windows.Forms.Label();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.pnRepeatAfterTimeUnit.SuspendLayout();
            this.pnRepeatDays.SuspendLayout();
            this.pnOverSetting.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnRepeatAfterTimeUnit
            // 
            this.pnRepeatAfterTimeUnit.Controls.Add(this.lblEveryMonth);
            this.pnRepeatAfterTimeUnit.Controls.Add(this.cLB_UnitTimeSelect);
            this.pnRepeatAfterTimeUnit.Controls.Add(this.txtBox_NumTimeUnit);
            this.pnRepeatAfterTimeUnit.Controls.Add(this.lblRepeat);
            this.pnRepeatAfterTimeUnit.Location = new System.Drawing.Point(12, 57);
            this.pnRepeatAfterTimeUnit.Name = "pnRepeatAfterTimeUnit";
            this.pnRepeatAfterTimeUnit.Size = new System.Drawing.Size(418, 110);
            this.pnRepeatAfterTimeUnit.TabIndex = 0;
            // 
            // lblEveryMonth
            // 
            this.lblEveryMonth.AutoSize = true;
            this.lblEveryMonth.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblEveryMonth.Location = new System.Drawing.Point(177, 81);
            this.lblEveryMonth.Name = "lblEveryMonth";
            this.lblEveryMonth.Size = new System.Drawing.Size(229, 20);
            this.lblEveryMonth.TabIndex = 3;
            this.lblEveryMonth.Text = "Lặp lại vào ngày __ hằng tháng";
            this.lblEveryMonth.Visible = false;
            // 
            // cLB_UnitTimeSelect
            // 
            this.cLB_UnitTimeSelect.CheckOnClick = true;
            this.cLB_UnitTimeSelect.FormattingEnabled = true;
            this.cLB_UnitTimeSelect.Location = new System.Drawing.Point(74, 42);
            this.cLB_UnitTimeSelect.Name = "cLB_UnitTimeSelect";
            this.cLB_UnitTimeSelect.Size = new System.Drawing.Size(164, 27);
            this.cLB_UnitTimeSelect.TabIndex = 2;
            this.cLB_UnitTimeSelect.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.cLB_UnitTimeSelect_ItemCheck);
            // 
            // txtBox_NumTimeUnit
            // 
            this.txtBox_NumTimeUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox_NumTimeUnit.Location = new System.Drawing.Point(14, 42);
            this.txtBox_NumTimeUnit.Name = "txtBox_NumTimeUnit";
            this.txtBox_NumTimeUnit.Size = new System.Drawing.Size(47, 26);
            this.txtBox_NumTimeUnit.TabIndex = 1;
            this.txtBox_NumTimeUnit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // lblRepeat
            // 
            this.lblRepeat.AutoSize = true;
            this.lblRepeat.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeat.Location = new System.Drawing.Point(3, 9);
            this.lblRepeat.Name = "lblRepeat";
            this.lblRepeat.Size = new System.Drawing.Size(116, 21);
            this.lblRepeat.TabIndex = 0;
            this.lblRepeat.Text = "Lặp lại sau mỗi";
            // 
            // pnRepeatDays
            // 
            this.pnRepeatDays.Controls.Add(this.cbAllWeek);
            this.pnRepeatDays.Controls.Add(this.cB_Sun);
            this.pnRepeatDays.Controls.Add(this.cB_Fri);
            this.pnRepeatDays.Controls.Add(this.cB_Sat);
            this.pnRepeatDays.Controls.Add(this.cB_Thurs);
            this.pnRepeatDays.Controls.Add(this.cB_Weds);
            this.pnRepeatDays.Controls.Add(this.cB_Tues);
            this.pnRepeatDays.Controls.Add(this.cB_Mon);
            this.pnRepeatDays.Controls.Add(this.lblRepeatDays);
            this.pnRepeatDays.Enabled = false;
            this.pnRepeatDays.Location = new System.Drawing.Point(12, 173);
            this.pnRepeatDays.Name = "pnRepeatDays";
            this.pnRepeatDays.Size = new System.Drawing.Size(418, 110);
            this.pnRepeatDays.TabIndex = 1;
            // 
            // cbAllWeek
            // 
            this.cbAllWeek.AutoSize = true;
            this.cbAllWeek.Location = new System.Drawing.Point(95, 9);
            this.cbAllWeek.Name = "cbAllWeek";
            this.cbAllWeek.Size = new System.Drawing.Size(95, 24);
            this.cbAllWeek.TabIndex = 12;
            this.cbAllWeek.Text = "Cả Tuần";
            this.cbAllWeek.UseVisualStyleBackColor = true;
            this.cbAllWeek.CheckedChanged += new System.EventHandler(this.cbAllWeek_CheckedChanged);
            // 
            // cB_Sun
            // 
            this.cB_Sun.AutoSize = true;
            this.cB_Sun.Location = new System.Drawing.Point(269, 73);
            this.cB_Sun.Name = "cB_Sun";
            this.cB_Sun.Size = new System.Drawing.Size(102, 24);
            this.cB_Sun.TabIndex = 11;
            this.cB_Sun.Text = "Chủ Nhật";
            this.cB_Sun.UseVisualStyleBackColor = true;
            this.cB_Sun.CheckedChanged += new System.EventHandler(this.pn_DaysCB_CheckedChanged);
            // 
            // cB_Fri
            // 
            this.cB_Fri.AutoSize = true;
            this.cB_Fri.Location = new System.Drawing.Point(59, 73);
            this.cB_Fri.Name = "cB_Fri";
            this.cB_Fri.Size = new System.Drawing.Size(75, 24);
            this.cB_Fri.TabIndex = 10;
            this.cB_Fri.Text = "Thứ 6";
            this.cB_Fri.UseVisualStyleBackColor = true;
            this.cB_Fri.CheckedChanged += new System.EventHandler(this.pn_DaysCB_CheckedChanged);
            // 
            // cB_Sat
            // 
            this.cB_Sat.AutoSize = true;
            this.cB_Sat.Location = new System.Drawing.Point(163, 73);
            this.cB_Sat.Name = "cB_Sat";
            this.cB_Sat.Size = new System.Drawing.Size(75, 24);
            this.cB_Sat.TabIndex = 9;
            this.cB_Sat.Text = "Thứ 7";
            this.cB_Sat.UseVisualStyleBackColor = true;
            this.cB_Sat.CheckedChanged += new System.EventHandler(this.pn_DaysCB_CheckedChanged);
            // 
            // cB_Thurs
            // 
            this.cB_Thurs.AutoSize = true;
            this.cB_Thurs.Location = new System.Drawing.Point(331, 43);
            this.cB_Thurs.Name = "cB_Thurs";
            this.cB_Thurs.Size = new System.Drawing.Size(75, 24);
            this.cB_Thurs.TabIndex = 8;
            this.cB_Thurs.Text = "Thứ 5";
            this.cB_Thurs.UseVisualStyleBackColor = true;
            this.cB_Thurs.CheckedChanged += new System.EventHandler(this.pn_DaysCB_CheckedChanged);
            // 
            // cB_Weds
            // 
            this.cB_Weds.AutoSize = true;
            this.cB_Weds.Location = new System.Drawing.Point(223, 43);
            this.cB_Weds.Name = "cB_Weds";
            this.cB_Weds.Size = new System.Drawing.Size(75, 24);
            this.cB_Weds.TabIndex = 7;
            this.cB_Weds.Text = "Thứ 4";
            this.cB_Weds.UseVisualStyleBackColor = true;
            this.cB_Weds.CheckedChanged += new System.EventHandler(this.pn_DaysCB_CheckedChanged);
            // 
            // cB_Tues
            // 
            this.cB_Tues.AutoSize = true;
            this.cB_Tues.Location = new System.Drawing.Point(110, 43);
            this.cB_Tues.Name = "cB_Tues";
            this.cB_Tues.Size = new System.Drawing.Size(75, 24);
            this.cB_Tues.TabIndex = 6;
            this.cB_Tues.Text = "Thứ 3";
            this.cB_Tues.UseVisualStyleBackColor = true;
            this.cB_Tues.CheckedChanged += new System.EventHandler(this.pn_DaysCB_CheckedChanged);
            // 
            // cB_Mon
            // 
            this.cB_Mon.AutoSize = true;
            this.cB_Mon.Location = new System.Drawing.Point(14, 43);
            this.cB_Mon.Name = "cB_Mon";
            this.cB_Mon.Size = new System.Drawing.Size(75, 24);
            this.cB_Mon.TabIndex = 5;
            this.cB_Mon.Text = "Thứ 2";
            this.cB_Mon.UseVisualStyleBackColor = true;
            this.cB_Mon.CheckedChanged += new System.EventHandler(this.pn_DaysCB_CheckedChanged);
            // 
            // lblRepeatDays
            // 
            this.lblRepeatDays.AutoSize = true;
            this.lblRepeatDays.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatDays.Location = new System.Drawing.Point(3, 9);
            this.lblRepeatDays.Name = "lblRepeatDays";
            this.lblRepeatDays.Size = new System.Drawing.Size(86, 21);
            this.lblRepeatDays.TabIndex = 0;
            this.lblRepeatDays.Text = "Lặp lại vào";
            // 
            // pnOverSetting
            // 
            this.pnOverSetting.Controls.Add(this.txtBox_Times);
            this.pnOverSetting.Controls.Add(this.dtPicker_DaySelect);
            this.pnOverSetting.Controls.Add(this.cB_AfterTimes);
            this.pnOverSetting.Controls.Add(this.cB_Overday);
            this.pnOverSetting.Controls.Add(this.cB_Never);
            this.pnOverSetting.Controls.Add(this.lblEnd);
            this.pnOverSetting.Location = new System.Drawing.Point(12, 289);
            this.pnOverSetting.Name = "pnOverSetting";
            this.pnOverSetting.Size = new System.Drawing.Size(418, 139);
            this.pnOverSetting.TabIndex = 2;
            // 
            // txtBox_Times
            // 
            this.txtBox_Times.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBox_Times.Location = new System.Drawing.Point(74, 100);
            this.txtBox_Times.Name = "txtBox_Times";
            this.txtBox_Times.Size = new System.Drawing.Size(42, 26);
            this.txtBox_Times.TabIndex = 5;
            // 
            // dtPicker_DaySelect
            // 
            this.dtPicker_DaySelect.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPicker_DaySelect.Location = new System.Drawing.Point(122, 70);
            this.dtPicker_DaySelect.Name = "dtPicker_DaySelect";
            this.dtPicker_DaySelect.Size = new System.Drawing.Size(116, 26);
            this.dtPicker_DaySelect.TabIndex = 4;
            // 
            // cB_AfterTimes
            // 
            this.cB_AfterTimes.AutoSize = true;
            this.cB_AfterTimes.Location = new System.Drawing.Point(14, 102);
            this.cB_AfterTimes.Name = "cB_AfterTimes";
            this.cB_AfterTimes.Size = new System.Drawing.Size(189, 24);
            this.cB_AfterTimes.TabIndex = 3;
            this.cB_AfterTimes.Text = "Sau  ____  lần diễn ra";
            this.cB_AfterTimes.UseVisualStyleBackColor = true;
            this.cB_AfterTimes.CheckedChanged += new System.EventHandler(this.OSCheckBox_CheckedChanged);
            // 
            // cB_Overday
            // 
            this.cB_Overday.AutoSize = true;
            this.cB_Overday.Location = new System.Drawing.Point(14, 72);
            this.cB_Overday.Name = "cB_Overday";
            this.cB_Overday.Size = new System.Drawing.Size(102, 24);
            this.cB_Overday.TabIndex = 2;
            this.cB_Overday.Text = "Vào ngày";
            this.cB_Overday.UseVisualStyleBackColor = true;
            this.cB_Overday.CheckedChanged += new System.EventHandler(this.OSCheckBox_CheckedChanged);
            // 
            // cB_Never
            // 
            this.cB_Never.AutoSize = true;
            this.cB_Never.Location = new System.Drawing.Point(14, 42);
            this.cB_Never.Name = "cB_Never";
            this.cB_Never.Size = new System.Drawing.Size(137, 24);
            this.cB_Never.TabIndex = 1;
            this.cB_Never.Text = "Không bao giờ";
            this.cB_Never.UseVisualStyleBackColor = true;
            this.cB_Never.CheckedChanged += new System.EventHandler(this.OSCheckBox_CheckedChanged);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnd.Location = new System.Drawing.Point(3, 9);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(71, 21);
            this.lblEnd.TabIndex = 0;
            this.lblEnd.Text = "Kết thúc";
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(328, 446);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(101, 51);
            this.btn_Done.TabIndex = 3;
            this.btn_Done.Text = "Xong";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // lblConfigTitle
            // 
            this.lblConfigTitle.AutoSize = true;
            this.lblConfigTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConfigTitle.Location = new System.Drawing.Point(7, 18);
            this.lblConfigTitle.Name = "lblConfigTitle";
            this.lblConfigTitle.Size = new System.Drawing.Size(168, 28);
            this.lblConfigTitle.TabIndex = 4;
            this.lblConfigTitle.Text = "Tùy chỉnh lặp lại";
            // 
            // btn_Reset
            // 
            this.btn_Reset.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Reset.Location = new System.Drawing.Point(181, 12);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(36, 39);
            this.btn_Reset.TabIndex = 5;
            this.btn_Reset.Text = "⟳";
            this.btn_Reset.UseVisualStyleBackColor = true;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // RecurringEvtSettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(441, 514);
            this.Controls.Add(this.btn_Reset);
            this.Controls.Add(this.lblConfigTitle);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.pnOverSetting);
            this.Controls.Add(this.pnRepeatDays);
            this.Controls.Add(this.pnRepeatAfterTimeUnit);
            this.MaximizeBox = false;
            this.Name = "RecurringEvtSettingForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RecurringEvtSettingForm";
            this.pnRepeatAfterTimeUnit.ResumeLayout(false);
            this.pnRepeatAfterTimeUnit.PerformLayout();
            this.pnRepeatDays.ResumeLayout(false);
            this.pnRepeatDays.PerformLayout();
            this.pnOverSetting.ResumeLayout(false);
            this.pnOverSetting.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnRepeatAfterTimeUnit;
        private System.Windows.Forms.Label lblRepeat;
        private System.Windows.Forms.Panel pnRepeatDays;
        private System.Windows.Forms.Label lblRepeatDays;
        private System.Windows.Forms.Panel pnOverSetting;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Label lblConfigTitle;
        private System.Windows.Forms.TextBox txtBox_NumTimeUnit;
        private System.Windows.Forms.CheckedListBox cLB_UnitTimeSelect;
        private System.Windows.Forms.CheckBox cB_Sun;
        private System.Windows.Forms.CheckBox cB_Fri;
        private System.Windows.Forms.CheckBox cB_Sat;
        private System.Windows.Forms.CheckBox cB_Thurs;
        private System.Windows.Forms.CheckBox cB_Weds;
        private System.Windows.Forms.CheckBox cB_Tues;
        private System.Windows.Forms.CheckBox cB_Mon;
        private System.Windows.Forms.TextBox txtBox_Times;
        private System.Windows.Forms.DateTimePicker dtPicker_DaySelect;
        private System.Windows.Forms.CheckBox cB_AfterTimes;
        private System.Windows.Forms.CheckBox cB_Overday;
        private System.Windows.Forms.CheckBox cB_Never;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Label lblEveryMonth;
        private System.Windows.Forms.CheckBox cbAllWeek;
    }
}