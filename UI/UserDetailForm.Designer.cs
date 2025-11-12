namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    partial class UserDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDetailForm));
            this.txtboxUsrname = new System.Windows.Forms.TextBox();
            this.txtbox_PhoneNum = new System.Windows.Forms.TextBox();
            this.txtbox_pwd = new System.Windows.Forms.TextBox();
            this.picbox_User = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblPhonenum = new System.Windows.Forms.Label();
            this.lblPwd = new System.Windows.Forms.Label();
            this.btnFixDetail = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblDeleteAccount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picbox_User)).BeginInit();
            this.SuspendLayout();
            // 
            // txtboxUsrname
            // 
            this.txtboxUsrname.Location = new System.Drawing.Point(349, 72);
            this.txtboxUsrname.Name = "txtboxUsrname";
            this.txtboxUsrname.Size = new System.Drawing.Size(311, 26);
            this.txtboxUsrname.TabIndex = 0;
            // 
            // txtbox_PhoneNum
            // 
            this.txtbox_PhoneNum.Location = new System.Drawing.Point(349, 121);
            this.txtbox_PhoneNum.Name = "txtbox_PhoneNum";
            this.txtbox_PhoneNum.Size = new System.Drawing.Size(311, 26);
            this.txtbox_PhoneNum.TabIndex = 1;
            // 
            // txtbox_pwd
            // 
            this.txtbox_pwd.Location = new System.Drawing.Point(349, 173);
            this.txtbox_pwd.Name = "txtbox_pwd";
            this.txtbox_pwd.Size = new System.Drawing.Size(311, 26);
            this.txtbox_pwd.TabIndex = 2;
            this.txtbox_pwd.UseSystemPasswordChar = true;
            // 
            // picbox_User
            // 
            this.picbox_User.Image = ((System.Drawing.Image)(resources.GetObject("picbox_User.Image")));
            this.picbox_User.Location = new System.Drawing.Point(40, 63);
            this.picbox_User.Name = "picbox_User";
            this.picbox_User.Size = new System.Drawing.Size(139, 146);
            this.picbox_User.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbox_User.TabIndex = 3;
            this.picbox_User.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.BackColor = System.Drawing.Color.Transparent;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.ForeColor = System.Drawing.Color.Firebrick;
            this.lblUser.Location = new System.Drawing.Point(196, 72);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(148, 25);
            this.lblUser.TabIndex = 4;
            this.lblUser.Text = "Tên người dùng:";
            // 
            // lblPhonenum
            // 
            this.lblPhonenum.AutoSize = true;
            this.lblPhonenum.BackColor = System.Drawing.Color.Transparent;
            this.lblPhonenum.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhonenum.ForeColor = System.Drawing.Color.Firebrick;
            this.lblPhonenum.Location = new System.Drawing.Point(217, 122);
            this.lblPhonenum.Name = "lblPhonenum";
            this.lblPhonenum.Size = new System.Drawing.Size(126, 25);
            this.lblPhonenum.TabIndex = 5;
            this.lblPhonenum.Text = "Số điện thoại:";
            // 
            // lblPwd
            // 
            this.lblPwd.AutoSize = true;
            this.lblPwd.BackColor = System.Drawing.Color.Transparent;
            this.lblPwd.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPwd.ForeColor = System.Drawing.Color.Firebrick;
            this.lblPwd.Location = new System.Drawing.Point(250, 174);
            this.lblPwd.Name = "lblPwd";
            this.lblPwd.Size = new System.Drawing.Size(93, 25);
            this.lblPwd.TabIndex = 6;
            this.lblPwd.Text = "Mật khẩu:";
            // 
            // btnFixDetail
            // 
            this.btnFixDetail.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFixDetail.Location = new System.Drawing.Point(257, 243);
            this.btnFixDetail.Name = "btnFixDetail";
            this.btnFixDetail.Size = new System.Drawing.Size(98, 49);
            this.btnFixDetail.TabIndex = 7;
            this.btnFixDetail.Text = "Sửa";
            this.btnFixDetail.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Variable Display", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(411, 243);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 49);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblDeleteAccount
            // 
            this.lblDeleteAccount.AutoSize = true;
            this.lblDeleteAccount.BackColor = System.Drawing.Color.Transparent;
            this.lblDeleteAccount.Font = new System.Drawing.Font("Segoe UI Variable Text Semibold", 8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeleteAccount.ForeColor = System.Drawing.Color.Red;
            this.lblDeleteAccount.Location = new System.Drawing.Point(551, 206);
            this.lblDeleteAccount.Name = "lblDeleteAccount";
            this.lblDeleteAccount.Size = new System.Drawing.Size(107, 21);
            this.lblDeleteAccount.TabIndex = 9;
            this.lblDeleteAccount.Text = "Xóa tài khoản";
            this.lblDeleteAccount.Click += new System.EventHandler(this.lblDeleteAccount_Click);
            // 
            // UserDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(717, 312);
            this.Controls.Add(this.lblDeleteAccount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFixDetail);
            this.Controls.Add(this.lblPwd);
            this.Controls.Add(this.lblPhonenum);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.picbox_User);
            this.Controls.Add(this.txtbox_pwd);
            this.Controls.Add(this.txtbox_PhoneNum);
            this.Controls.Add(this.txtboxUsrname);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "UserDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin tài khoản - người dùng";
            ((System.ComponentModel.ISupportInitialize)(this.picbox_User)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtboxUsrname;
        private System.Windows.Forms.TextBox txtbox_PhoneNum;
        private System.Windows.Forms.TextBox txtbox_pwd;
        private System.Windows.Forms.PictureBox picbox_User;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblPhonenum;
        private System.Windows.Forms.Label lblPwd;
        private System.Windows.Forms.Button btnFixDetail;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblDeleteAccount;
    }
}