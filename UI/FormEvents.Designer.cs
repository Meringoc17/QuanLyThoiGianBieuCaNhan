namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN
{
    partial class FormEvents
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
            this.lstEvents = new System.Windows.Forms.ListBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstEvents
            // 
            this.lstEvents.ForeColor = System.Drawing.Color.Black;
            this.lstEvents.FormattingEnabled = true;
            this.lstEvents.ItemHeight = 20;
            this.lstEvents.Location = new System.Drawing.Point(56, 101);
            this.lstEvents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lstEvents.Name = "lstEvents";
            this.lstEvents.Size = new System.Drawing.Size(416, 124);
            this.lstEvents.TabIndex = 0;
            // 
            // lblDate
            // 
            this.lblDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(211)))), ((int)(((byte)(254)))), ((int)(((byte)(233)))));
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblDate.ForeColor = System.Drawing.Color.Teal;
            this.lblDate.Location = new System.Drawing.Point(78, 37);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(371, 44);
            this.lblDate.TabIndex = 1;
            this.lblDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDate.Click += new System.EventHandler(this.lblDate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnClose.Location = new System.Drawing.Point(202, 248);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 49);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Đóng";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // FormEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(242)))), ((int)(((byte)(243)))));
            this.ClientSize = new System.Drawing.Size(531, 311);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lstEvents);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormEvents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormEvents_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lstEvents;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnClose;
    }
}