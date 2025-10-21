namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    partial class UserSignUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSignUp));
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_CreatePass = new System.Windows.Forms.Label();
            this.lbl_ConfirmPass = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_Done = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(19, 34);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(118, 20);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Tên/Username:";
            // 
            // lbl_CreatePass
            // 
            this.lbl_CreatePass.AutoSize = true;
            this.lbl_CreatePass.Location = new System.Drawing.Point(19, 94);
            this.lbl_CreatePass.Name = "lbl_CreatePass";
            this.lbl_CreatePass.Size = new System.Drawing.Size(110, 20);
            this.lbl_CreatePass.TabIndex = 1;
            this.lbl_CreatePass.Text = "Tạo mật khẩu:";
            // 
            // lbl_ConfirmPass
            // 
            this.lbl_ConfirmPass.AutoSize = true;
            this.lbl_ConfirmPass.Location = new System.Drawing.Point(19, 148);
            this.lbl_ConfirmPass.Name = "lbl_ConfirmPass";
            this.lbl_ConfirmPass.Size = new System.Drawing.Size(151, 20);
            this.lbl_ConfirmPass.TabIndex = 2;
            this.lbl_ConfirmPass.Text = "Xác nhận mật khẩu:";
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Location = new System.Drawing.Point(190, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(430, 26);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox2.Location = new System.Drawing.Point(190, 88);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(430, 26);
            this.textBox2.TabIndex = 4;
            this.textBox2.UseSystemPasswordChar = true;
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox3.Location = new System.Drawing.Point(190, 148);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(430, 26);
            this.textBox3.TabIndex = 5;
            this.textBox3.UseSystemPasswordChar = true;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.Location = new System.Drawing.Point(513, 24);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(110, 29);
            this.lbl_Title.TabIndex = 6;
            this.lbl_Title.Text = "Đăng Ký";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 75);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(181, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(774, 302);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(110, 55);
            this.btn_Done.TabIndex = 8;
            this.btn_Done.Text = "Xong";
            this.btn_Done.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(220)))), ((int)(((byte)(254)))));
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.lbl_Name);
            this.panel1.Controls.Add(this.lbl_CreatePass);
            this.panel1.Controls.Add(this.lbl_ConfirmPass);
            this.panel1.Location = new System.Drawing.Point(226, 75);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(658, 203);
            this.panel1.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(222, 291);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // UserSignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(906, 374);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.panel1);
            this.Name = "UserSignUp";
            this.Text = "UserSignUp";
            this.Load += new System.EventHandler(this.UserSignUp_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_CreatePass;
        private System.Windows.Forms.Label lbl_ConfirmPass;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}