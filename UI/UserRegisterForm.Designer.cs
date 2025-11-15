namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    partial class UserRegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserRegisterForm));
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_CreatePass = new System.Windows.Forms.Label();
            this.lbl_ConfirmPass = new System.Windows.Forms.Label();
            this.txtBoxName = new System.Windows.Forms.TextBox();
            this.txtBoxPass = new System.Windows.Forms.TextBox();
            this.txtBoxConfirmPass = new System.Windows.Forms.TextBox();
            this.lbl_Title = new System.Windows.Forms.Label();
            this.btn_Done = new System.Windows.Forms.Button();
            this.pnSignUp = new System.Windows.Forms.Panel();
            this.txtBoxPhoneNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnSignUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Name.ForeColor = System.Drawing.Color.Navy;
            this.lbl_Name.Location = new System.Drawing.Point(18, 30);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(149, 27);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Tên/Username:";
            // 
            // lbl_CreatePass
            // 
            this.lbl_CreatePass.AutoSize = true;
            this.lbl_CreatePass.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CreatePass.ForeColor = System.Drawing.Color.Navy;
            this.lbl_CreatePass.Location = new System.Drawing.Point(18, 137);
            this.lbl_CreatePass.Name = "lbl_CreatePass";
            this.lbl_CreatePass.Size = new System.Drawing.Size(139, 27);
            this.lbl_CreatePass.TabIndex = 1;
            this.lbl_CreatePass.Text = "Tạo mật khẩu:";
            // 
            // lbl_ConfirmPass
            // 
            this.lbl_ConfirmPass.AutoSize = true;
            this.lbl_ConfirmPass.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_ConfirmPass.ForeColor = System.Drawing.Color.Navy;
            this.lbl_ConfirmPass.Location = new System.Drawing.Point(18, 188);
            this.lbl_ConfirmPass.Name = "lbl_ConfirmPass";
            this.lbl_ConfirmPass.Size = new System.Drawing.Size(187, 27);
            this.lbl_ConfirmPass.TabIndex = 2;
            this.lbl_ConfirmPass.Text = "Xác nhận mật khẩu:";
            // 
            // txtBoxName
            // 
            this.txtBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxName.Location = new System.Drawing.Point(239, 32);
            this.txtBoxName.Name = "txtBoxName";
            this.txtBoxName.Size = new System.Drawing.Size(381, 28);
            this.txtBoxName.TabIndex = 3;
            // 
            // txtBoxPass
            // 
            this.txtBoxPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPass.Location = new System.Drawing.Point(239, 138);
            this.txtBoxPass.Name = "txtBoxPass";
            this.txtBoxPass.Size = new System.Drawing.Size(381, 28);
            this.txtBoxPass.TabIndex = 4;
            this.txtBoxPass.UseSystemPasswordChar = true;
            // 
            // txtBoxConfirmPass
            // 
            this.txtBoxConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxConfirmPass.Location = new System.Drawing.Point(239, 188);
            this.txtBoxConfirmPass.Name = "txtBoxConfirmPass";
            this.txtBoxConfirmPass.Size = new System.Drawing.Size(381, 28);
            this.txtBoxConfirmPass.TabIndex = 5;
            this.txtBoxConfirmPass.UseSystemPasswordChar = true;
            // 
            // lbl_Title
            // 
            this.lbl_Title.AutoSize = true;
            this.lbl_Title.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_Title.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbl_Title.Location = new System.Drawing.Point(13, 19);
            this.lbl_Title.Name = "lbl_Title";
            this.lbl_Title.Size = new System.Drawing.Size(146, 45);
            this.lbl_Title.TabIndex = 6;
            this.lbl_Title.Text = "Đăng Ký";
            // 
            // btn_Done
            // 
            this.btn_Done.Location = new System.Drawing.Point(770, 330);
            this.btn_Done.Name = "btn_Done";
            this.btn_Done.Size = new System.Drawing.Size(110, 55);
            this.btn_Done.TabIndex = 8;
            this.btn_Done.Text = "Xong";
            this.btn_Done.UseVisualStyleBackColor = true;
            this.btn_Done.Click += new System.EventHandler(this.btn_Done_Click);
            // 
            // pnSignUp
            // 
            this.pnSignUp.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnSignUp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(218)))), ((int)(((byte)(220)))), ((int)(((byte)(254)))));
            this.pnSignUp.Controls.Add(this.txtBoxPhoneNum);
            this.pnSignUp.Controls.Add(this.label2);
            this.pnSignUp.Controls.Add(this.txtBoxConfirmPass);
            this.pnSignUp.Controls.Add(this.txtBoxPass);
            this.pnSignUp.Controls.Add(this.txtBoxName);
            this.pnSignUp.Controls.Add(this.lbl_Name);
            this.pnSignUp.Controls.Add(this.lbl_CreatePass);
            this.pnSignUp.Controls.Add(this.lbl_ConfirmPass);
            this.pnSignUp.Location = new System.Drawing.Point(222, 67);
            this.pnSignUp.Name = "pnSignUp";
            this.pnSignUp.Size = new System.Drawing.Size(658, 247);
            this.pnSignUp.TabIndex = 9;
            // 
            // txtBoxPhoneNum
            // 
            this.txtBoxPhoneNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBoxPhoneNum.Location = new System.Drawing.Point(239, 85);
            this.txtBoxPhoneNum.Name = "txtBoxPhoneNum";
            this.txtBoxPhoneNum.Size = new System.Drawing.Size(381, 28);
            this.txtBoxPhoneNum.TabIndex = 8;
            this.txtBoxPhoneNum.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumber_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(18, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Số điện thoại:";
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.lblError.Location = new System.Drawing.Point(217, 317);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(118, 21);
            this.lblError.TabIndex = 0;
            this.lblError.Text = "Báo lỗi ở đây !";
            this.lblError.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(655, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Điền thông tin đầy đủ tại đây ~";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 97);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(165, 186);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // UserRegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(898, 400);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblError);
            this.Controls.Add(this.btn_Done);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbl_Title);
            this.Controls.Add(this.pnSignUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "UserRegisterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản Lý Thời Gian Biểu Cá Nhân";
            this.pnSignUp.ResumeLayout(false);
            this.pnSignUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_CreatePass;
        private System.Windows.Forms.Label lbl_ConfirmPass;
        private System.Windows.Forms.TextBox txtBoxName;
        private System.Windows.Forms.TextBox txtBoxPass;
        private System.Windows.Forms.TextBox txtBoxConfirmPass;
        private System.Windows.Forms.Label lbl_Title;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_Done;
        private System.Windows.Forms.Panel pnSignUp;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.TextBox txtBoxPhoneNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}