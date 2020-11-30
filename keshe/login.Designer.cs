
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
            this.label_rdPwd = new System.Windows.Forms.Label();
            this.textBox_rdPwd = new System.Windows.Forms.TextBox();
            this.button_login = new System.Windows.Forms.Button();
            this.button_exit = new System.Windows.Forms.Button();
            this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
            this.label_welcome = new System.Windows.Forms.Label();
            this.textBox_rdID = new System.Windows.Forms.TextBox();
            this.lable_rdID = new System.Windows.Forms.Label();
            this.tableLayoutPanel_rdpwd = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_rdID = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_main.SuspendLayout();
            this.tableLayoutPanel_rdpwd.SuspendLayout();
            this.tableLayoutPanel_rdID.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_rdPwd
            // 
            this.label_rdPwd.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_rdPwd.AutoSize = true;
            this.label_rdPwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_rdPwd.Location = new System.Drawing.Point(12, 11);
            this.label_rdPwd.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_rdPwd.Name = "label_rdPwd";
            this.label_rdPwd.Size = new System.Drawing.Size(74, 22);
            this.label_rdPwd.TabIndex = 0;
            this.label_rdPwd.Text = "用户密码";
            // 
            // textBox_rdPwd
            // 
            this.textBox_rdPwd.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_rdPwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rdPwd.Location = new System.Drawing.Point(101, 7);
            this.textBox_rdPwd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBox_rdPwd.Name = "textBox_rdPwd";
            this.textBox_rdPwd.Size = new System.Drawing.Size(221, 30);
            this.textBox_rdPwd.TabIndex = 1;
            this.textBox_rdPwd.UseSystemPasswordChar = true;
            // 
            // button_login
            // 
            this.button_login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_login.Location = new System.Drawing.Point(37, 7);
            this.button_login.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_login.Name = "button_login";
            this.button_login.Size = new System.Drawing.Size(92, 30);
            this.button_login.TabIndex = 0;
            this.button_login.Text = "登录";
            this.button_login.UseVisualStyleBackColor = true;
            this.button_login.Click += new System.EventHandler(this.button_login_Click);
            // 
            // button_exit
            // 
            this.button_exit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_exit.Location = new System.Drawing.Point(203, 7);
            this.button_exit.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(92, 30);
            this.button_exit.TabIndex = 1;
            this.button_exit.Text = "退出";
            this.button_exit.UseVisualStyleBackColor = true;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click);
            // 
            // tableLayoutPanel_main
            // 
            this.tableLayoutPanel_main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_main.ColumnCount = 1;
            this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel3, 0, 3);
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_rdID, 0, 1);
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_rdpwd, 0, 2);
            this.tableLayoutPanel_main.Controls.Add(this.label_welcome, 0, 0);
            this.tableLayoutPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_main.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            this.tableLayoutPanel_main.RowCount = 4;
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel_main.Size = new System.Drawing.Size(339, 200);
            this.tableLayoutPanel_main.TabIndex = 0;
            // 
            // label_welcome
            // 
            this.label_welcome.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label_welcome.AutoSize = true;
            this.label_welcome.Font = new System.Drawing.Font("字由心雨 常规体", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_welcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(65)))), ((int)(((byte)(113)))));
            this.label_welcome.Location = new System.Drawing.Point(11, 10);
            this.label_welcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_welcome.Name = "label_welcome";
            this.label_welcome.Size = new System.Drawing.Size(316, 30);
            this.label_welcome.TabIndex = 0;
            this.label_welcome.Text = "欢迎使用 keshe 图书管理系统";
            this.label_welcome.Click += new System.EventHandler(this.label_welcome_Click);
            // 
            // textBox_rdID
            // 
            this.textBox_rdID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.textBox_rdID.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_rdID.Location = new System.Drawing.Point(101, 7);
            this.textBox_rdID.Margin = new System.Windows.Forms.Padding(2);
            this.textBox_rdID.Name = "textBox_rdID";
            this.textBox_rdID.Size = new System.Drawing.Size(221, 30);
            this.textBox_rdID.TabIndex = 1;
            this.textBox_rdID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_rdID_KeyPress);
            // 
            // lable_rdID
            // 
            this.lable_rdID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lable_rdID.AutoSize = true;
            this.lable_rdID.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable_rdID.Location = new System.Drawing.Point(12, 11);
            this.lable_rdID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lable_rdID.Name = "lable_rdID";
            this.lable_rdID.Size = new System.Drawing.Size(74, 22);
            this.lable_rdID.TabIndex = 0;
            this.lable_rdID.Text = "用户编号";
            // 
            // tableLayoutPanel_rdpwd
            // 
            this.tableLayoutPanel_rdpwd.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_rdpwd.ColumnCount = 2;
            this.tableLayoutPanel_rdpwd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel_rdpwd.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel_rdpwd.Controls.Add(this.textBox_rdPwd, 1, 0);
            this.tableLayoutPanel_rdpwd.Controls.Add(this.label_rdPwd, 0, 0);
            this.tableLayoutPanel_rdpwd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_rdpwd.Location = new System.Drawing.Point(3, 103);
            this.tableLayoutPanel_rdpwd.Name = "tableLayoutPanel_rdpwd";
            this.tableLayoutPanel_rdpwd.RowCount = 1;
            this.tableLayoutPanel_rdpwd.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_rdpwd.Size = new System.Drawing.Size(333, 44);
            this.tableLayoutPanel_rdpwd.TabIndex = 2;
            // 
            // tableLayoutPanel_rdID
            // 
            this.tableLayoutPanel_rdID.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_rdID.ColumnCount = 2;
            this.tableLayoutPanel_rdID.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel_rdID.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel_rdID.Controls.Add(this.textBox_rdID, 1, 0);
            this.tableLayoutPanel_rdID.Controls.Add(this.lable_rdID, 0, 0);
            this.tableLayoutPanel_rdID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_rdID.Location = new System.Drawing.Point(3, 53);
            this.tableLayoutPanel_rdID.Name = "tableLayoutPanel_rdID";
            this.tableLayoutPanel_rdID.RowCount = 1;
            this.tableLayoutPanel_rdID.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_rdID.Size = new System.Drawing.Size(333, 44);
            this.tableLayoutPanel_rdID.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.button_exit, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.button_login, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 153);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(333, 44);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(339, 200);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel_main);
            this.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "login";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "用户登录";
            this.TopMost = true;
            this.tableLayoutPanel_main.ResumeLayout(false);
            this.tableLayoutPanel_main.PerformLayout();
            this.tableLayoutPanel_rdpwd.ResumeLayout(false);
            this.tableLayoutPanel_rdpwd.PerformLayout();
            this.tableLayoutPanel_rdID.ResumeLayout(false);
            this.tableLayoutPanel_rdID.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_rdPwd;
        private System.Windows.Forms.TextBox textBox_rdPwd;
        private System.Windows.Forms.Button button_login;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_main;
        private System.Windows.Forms.Label label_welcome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_rdID;
        private System.Windows.Forms.TextBox textBox_rdID;
        private System.Windows.Forms.Label lable_rdID;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_rdpwd;
    }
}

