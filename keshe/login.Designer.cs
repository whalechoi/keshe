
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
            this.button_login = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel_bkPwd = new System.Windows.Forms.Panel();
            this.label_welcome = new System.Windows.Forms.Label();
            this.panel_bkID = new System.Windows.Forms.Panel();
            this.panel_button = new System.Windows.Forms.Panel();
            this.tableLayoutPanel.SuspendLayout();
            this.panel_bkPwd.SuspendLayout();
            this.panel_bkID.SuspendLayout();
            this.panel_button.SuspendLayout();
            this.SuspendLayout();
            // 
            // lable_rdID
            // 
            this.lable_rdID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lable_rdID.AutoSize = true;
            this.lable_rdID.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable_rdID.Location = new System.Drawing.Point(26, 17);
            this.lable_rdID.Name = "lable_rdID";
            this.lable_rdID.Size = new System.Drawing.Size(92, 28);
            this.lable_rdID.TabIndex = 0;
            this.lable_rdID.Text = "用户编号";
            // 
            // textBox_rdID
            // 
            this.textBox_rdID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox_rdID.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rdID.Location = new System.Drawing.Point(124, 14);
            this.textBox_rdID.Name = "textBox_rdID";
            this.textBox_rdID.Size = new System.Drawing.Size(275, 35);
            this.textBox_rdID.TabIndex = 1;
            this.textBox_rdID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_rdID_KeyPress);
            // 
            // label_rdPwd
            // 
            this.label_rdPwd.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label_rdPwd.AutoSize = true;
            this.label_rdPwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rdPwd.Location = new System.Drawing.Point(26, 17);
            this.label_rdPwd.Name = "label_rdPwd";
            this.label_rdPwd.Size = new System.Drawing.Size(92, 28);
            this.label_rdPwd.TabIndex = 0;
            this.label_rdPwd.Text = "用户密码";
            // 
            // textBox_rdPwd
            // 
            this.textBox_rdPwd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_rdPwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rdPwd.Location = new System.Drawing.Point(124, 14);
            this.textBox_rdPwd.Name = "textBox_rdPwd";
            this.textBox_rdPwd.Size = new System.Drawing.Size(275, 35);
            this.textBox_rdPwd.TabIndex = 1;
            this.textBox_rdPwd.UseSystemPasswordChar = true;
            // 
            // button_login
            // 
            this.button_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_login.Location = new System.Drawing.Point(74, 6);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(115, 38);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_exit
            // 
            this.button_exit.Location = new System.Drawing.Point(255, 6);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(115, 38);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "退出";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.panel_bkPwd, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.label_welcome, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel_bkID, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.panel_button, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(442, 253);
            this.tableLayoutPanel.TabIndex = 5;
            // 
            // panel_bkPwd
            // 
            this.panel_bkPwd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_bkPwd.Controls.Add(this.textBox_rdPwd);
            this.panel_bkPwd.Controls.Add(this.label_rdPwd);
            this.panel_bkPwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bkPwd.Location = new System.Drawing.Point(3, 129);
            this.panel_bkPwd.Name = "panel_bkPwd";
            this.panel_bkPwd.Size = new System.Drawing.Size(436, 57);
            this.panel_bkPwd.TabIndex = 2;
            // 
            // label_welcome
            // 
            this.label_welcome.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label_welcome.AutoSize = true;
            this.label_welcome.Font = new System.Drawing.Font("字由心雨 常规体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_welcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(65)))), ((int)(((byte)(113)))));
            this.label_welcome.Location = new System.Drawing.Point(22, 23);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(398, 40);
            this.label_welcome.TabIndex = 0;
            this.label_welcome.Text = "欢迎使用 keshe 图书管理系统";
            this.label_welcome.Click += new System.EventHandler(this.label_welcome_Click);
            // 
            // panel_bkID
            // 
            this.panel_bkID.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_bkID.Controls.Add(this.textBox_rdID);
            this.panel_bkID.Controls.Add(this.lable_rdID);
            this.panel_bkID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bkID.Location = new System.Drawing.Point(3, 66);
            this.panel_bkID.Name = "panel_bkID";
            this.panel_bkID.Size = new System.Drawing.Size(436, 57);
            this.panel_bkID.TabIndex = 1;
            // 
            // panel_button
            // 
            this.panel_button.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel_button.Controls.Add(this.button_exit);
            this.panel_button.Controls.Add(this.button_login);
            this.panel_button.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_button.Location = new System.Drawing.Point(3, 192);
            this.panel_button.Name = "panel_button";
            this.panel_button.Size = new System.Drawing.Size(436, 58);
            this.panel_button.TabIndex = 3;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(442, 253);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel);
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
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.panel_bkPwd.ResumeLayout(false);
            this.panel_bkPwd.PerformLayout();
            this.panel_bkID.ResumeLayout(false);
            this.panel_bkID.PerformLayout();
            this.panel_button.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lable_rdID;
        private System.Windows.Forms.TextBox textBox_rdID;
        private System.Windows.Forms.Label label_rdPwd;
        private System.Windows.Forms.TextBox textBox_rdPwd;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label label_welcome;
        private System.Windows.Forms.Panel panel_button;
        private System.Windows.Forms.Panel panel_bkPwd;
        private System.Windows.Forms.Panel panel_bkID;
    }
}

