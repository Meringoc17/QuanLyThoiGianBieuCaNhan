using System.Drawing.Drawing2D;

namespace QUẢN_LÝ_THỜI_GIAN_BIỂU_CÁ_NHÂN.UI
{
    partial class UserLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLogin));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.UsernameLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SignIn_lbl = new System.Windows.Forms.Label();
            this.btn_Input = new System.Windows.Forms.Button();
            this.usnTxtBox = new System.Windows.Forms.TextBox();
            this.pwdTxtbox = new System.Windows.Forms.TextBox();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.panelLogin = new System.Windows.Forms.Panel();
            this.ckBox_KeepLogIn = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_LoginError = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(21, 88);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(134, 128);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // UsernameLbl
            // 
            this.UsernameLbl.AutoSize = true;
            this.UsernameLbl.BackColor = System.Drawing.Color.Transparent;
            this.UsernameLbl.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UsernameLbl.ForeColor = System.Drawing.Color.MidnightBlue;
            this.UsernameLbl.Location = new System.Drawing.Point(13, 32);
            this.UsernameLbl.Name = "UsernameLbl";
            this.UsernameLbl.Size = new System.Drawing.Size(263, 26);
            this.UsernameLbl.TabIndex = 1;
            this.UsernameLbl.Text = "Username/Phone Number:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label2.Location = new System.Drawing.Point(172, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password: ";
            // 
            // SignIn_lbl
            // 
            this.SignIn_lbl.AutoSize = true;
            this.SignIn_lbl.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignIn_lbl.ForeColor = System.Drawing.Color.Navy;
            this.SignIn_lbl.Location = new System.Drawing.Point(13, 29);
            this.SignIn_lbl.Name = "SignIn_lbl";
            this.SignIn_lbl.Size = new System.Drawing.Size(124, 45);
            this.SignIn_lbl.TabIndex = 3;
            this.SignIn_lbl.Text = "Sign In";
            // 
            // btn_Input
            // 
            this.btn_Input.Location = new System.Drawing.Point(658, 245);
            this.btn_Input.Name = "btn_Input";
            this.btn_Input.Size = new System.Drawing.Size(107, 47);
            this.btn_Input.TabIndex = 4;
            this.btn_Input.Text = "Let\'s go!";
            this.btn_Input.UseVisualStyleBackColor = true;
            this.btn_Input.Click += new System.EventHandler(this.btn_Input_Click);
            // 
            // usnTxtBox
            // 
            this.usnTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.usnTxtBox.Location = new System.Drawing.Point(291, 30);
            this.usnTxtBox.Name = "usnTxtBox";
            this.usnTxtBox.Size = new System.Drawing.Size(277, 28);
            this.usnTxtBox.TabIndex = 5;
            // 
            // pwdTxtbox
            // 
            this.pwdTxtbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwdTxtbox.Location = new System.Drawing.Point(291, 71);
            this.pwdTxtbox.Name = "pwdTxtbox";
            this.pwdTxtbox.Size = new System.Drawing.Size(277, 28);
            this.pwdTxtbox.TabIndex = 6;
            // 
            // btnSignUp
            // 
            this.btnSignUp.Location = new System.Drawing.Point(517, 245);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Size = new System.Drawing.Size(107, 47);
            this.btnSignUp.TabIndex = 8;
            this.btnSignUp.Text = "Sign Up";
            this.btnSignUp.UseVisualStyleBackColor = true;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // panelLogin
            // 
            this.panelLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(234)))), ((int)(((byte)(254)))));
            this.panelLogin.Controls.Add(this.ckBox_KeepLogIn);
            this.panelLogin.Controls.Add(this.UsernameLbl);
            this.panelLogin.Controls.Add(this.label2);
            this.panelLogin.Controls.Add(this.usnTxtBox);
            this.panelLogin.Controls.Add(this.pwdTxtbox);
            this.panelLogin.Location = new System.Drawing.Point(182, 77);
            this.panelLogin.Name = "panelLogin";
            this.panelLogin.Size = new System.Drawing.Size(595, 148);
            this.panelLogin.TabIndex = 9;
            // 
            // ckBox_KeepLogIn
            // 
            this.ckBox_KeepLogIn.AutoSize = true;
            this.ckBox_KeepLogIn.ForeColor = System.Drawing.Color.DarkBlue;
            this.ckBox_KeepLogIn.Location = new System.Drawing.Point(428, 114);
            this.ckBox_KeepLogIn.Name = "ckBox_KeepLogIn";
            this.ckBox_KeepLogIn.Size = new System.Drawing.Size(140, 24);
            this.ckBox_KeepLogIn.TabIndex = 11;
            this.ckBox_KeepLogIn.Text = "Remember Me";
            this.ckBox_KeepLogIn.UseVisualStyleBackColor = true;
            this.ckBox_KeepLogIn.CheckedChanged += new System.EventHandler(this.ckBox_KeepLogIn_CheckedChanged);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(17, 267);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(138, 20);
            this.linkLabel1.TabIndex = 10;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgot Password?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(589, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 21);
            this.label1.TabIndex = 11;
            this.label1.Text = "Welcome~ Please sign in!";
            // 
            // lbl_LoginError
            // 
            this.lbl_LoginError.AutoSize = true;
            this.lbl_LoginError.Font = new System.Drawing.Font("Segoe UI Semibold", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_LoginError.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lbl_LoginError.Location = new System.Drawing.Point(187, 228);
            this.lbl_LoginError.Name = "lbl_LoginError";
            this.lbl_LoginError.Size = new System.Drawing.Size(112, 21);
            this.lbl_LoginError.TabIndex = 12;
            this.lbl_LoginError.Text = "Báo lỗi tại đây";
            this.lbl_LoginError.Visible = false;
            // 
            // UserLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(789, 304);
            this.Controls.Add(this.lbl_LoginError);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.btnSignUp);
            this.Controls.Add(this.SignIn_lbl);
            this.Controls.Add(this.btn_Input);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "UserLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Thời Gian Biểu Cá Nhân";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelLogin.ResumeLayout(false);
            this.panelLogin.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label UsernameLbl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label SignIn_lbl;
        private System.Windows.Forms.Button btn_Input;
        private System.Windows.Forms.TextBox usnTxtBox;
        private System.Windows.Forms.TextBox pwdTxtbox;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Panel panelLogin;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.CheckBox ckBox_KeepLogIn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_LoginError;
    }
}