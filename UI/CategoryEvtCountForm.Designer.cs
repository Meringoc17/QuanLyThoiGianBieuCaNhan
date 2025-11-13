namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    partial class CategoryEvtCountForm
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
            this.txtboxDetail = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtboxDetail
            // 
            this.txtboxDetail.Location = new System.Drawing.Point(39, 33);
            this.txtboxDetail.Multiline = true;
            this.txtboxDetail.Name = "txtboxDetail";
            this.txtboxDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtboxDetail.Size = new System.Drawing.Size(323, 251);
            this.txtboxDetail.TabIndex = 0;
            // 
            // CategoryEvtCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(405, 314);
            this.Controls.Add(this.txtboxDetail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CategoryEvtCountForm";
            this.ShowIcon = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxDetail;
    }
}