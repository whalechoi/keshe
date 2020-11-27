
namespace keshe
{
    partial class login
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(login));
            this.lable_rdID = new System.Windows.Forms.Label();
            this.textBox_rdID = new System.Windows.Forms.TextBox();
            this.label_rdPwd = new System.Windows.Forms.Label();
            this.textBox_rdPwd = new System.Windows.Forms.TextBox();
            this.label_welcome = new System.Windows.Forms.Label();
            this.button_login = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lable_rdID
            // 
            this.lable_rdID.AutoSize = true;
            this.lable_rdID.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable_rdID.Location = new System.Drawing.Point(27, 62);
            this.lable_rdID.Name = "lable_rdID";
            this.lable_rdID.Size = new System.Drawing.Size(92, 28);
            this.lable_rdID.TabIndex = 0;
            this.lable_rdID.Text = "用户编号";
            // 
            // textBox_rdID
            // 
            this.textBox_rdID.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rdID.Location = new System.Drawing.Point(144, 59);
            this.textBox_rdID.Name = "textBox_rdID";
            this.textBox_rdID.Size = new System.Drawing.Size(243, 35);
            this.textBox_rdID.TabIndex = 1;
            // 
            // label_rdPwd
            // 
            this.label_rdPwd.AutoSize = true;
            this.label_rdPwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rdPwd.Location = new System.Drawing.Point(27, 116);
            this.label_rdPwd.Name = "label_rdPwd";
            this.label_rdPwd.Size = new System.Drawing.Size(92, 28);
            this.label_rdPwd.TabIndex = 0;
            this.label_rdPwd.Text = "用户密码";
            // 
            // textBox_rdPwd
            // 
            this.textBox_rdPwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rdPwd.Location = new System.Drawing.Point(144, 113);
            this.textBox_rdPwd.Name = "textBox_rdPwd";
            this.textBox_rdPwd.Size = new System.Drawing.Size(243, 35);
            this.textBox_rdPwd.TabIndex = 2;
            this.textBox_rdPwd.UseSystemPasswordChar = true;
            // 
            // label_welcome
            // 
            this.label_welcome.AutoSize = true;
            this.label_welcome.Font = new System.Drawing.Font("字由心雨 常规体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_welcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(65)))), ((int)(((byte)(113)))));
            this.label_welcome.Location = new System.Drawing.Point(12, 9);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(398, 40);
            this.label_welcome.TabIndex = 2;
            this.label_welcome.Text = "欢迎使用 keshe 图书管理系统";
            this.label_welcome.Click += new System.EventHandler(this.label_welcome_Click);
            // 
            // button_login
            // 
            this.button_login.Location = new System.Drawing.Point(51, 164);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(115, 38);
            this.button_login.TabIndex = 3;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(251, 164);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(115, 38);
            this.button_exit.TabIndex = 4;
            this.button_exit.Text = "退出";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(433, 252);
            this.ControlBox = false;
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_login);
            this.Controls.Add(this.label_welcome);
            this.Controls.Add(this.textBox_rdPwd);
            this.Controls.Add(this.label_rdPwd);
            this.Controls.Add(this.textBox_rdID);
            this.Controls.Add(this.lable_rdID);
            this.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lable_rdID;
        private System.Windows.Forms.TextBox textBox_rdID;
        private System.Windows.Forms.Label label_rdPwd;
        private System.Windows.Forms.TextBox textBox_rdPwd;
        private System.Windows.Forms.Label label_welcome;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_exit;
    }
}

