
namespace keshe
{
    partial class changePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changePassword));
            this.button_OK = new System.Windows.Forms.Button();
            this.textBox_old_pwd = new System.Windows.Forms.TextBox();
            this.label_old_pwd = new System.Windows.Forms.Label();
            this.textBox_new_pwd = new System.Windows.Forms.TextBox();
            this.label_new_pwd = new System.Windows.Forms.Label();
            this.textBox_new_pwd2 = new System.Windows.Forms.TextBox();
            this.label_new_pwd2 = new System.Windows.Forms.Label();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_OK
            // 
            this.button_OK.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(82, 151);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(95, 35);
            this.button_OK.TabIndex = 4;
            this.button_OK.Text = "确认";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // textBox_old_pwd
            // 
            this.textBox_old_pwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_old_pwd.Location = new System.Drawing.Point(178, 16);
            this.textBox_old_pwd.Name = "textBox_old_pwd";
            this.textBox_old_pwd.Size = new System.Drawing.Size(230, 35);
            this.textBox_old_pwd.TabIndex = 1;
            this.textBox_old_pwd.UseSystemPasswordChar = true;
            // 
            // label_old_pwd
            // 
            this.label_old_pwd.AutoSize = true;
            this.label_old_pwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_old_pwd.Location = new System.Drawing.Point(48, 19);
            this.label_old_pwd.Name = "label_old_pwd";
            this.label_old_pwd.Size = new System.Drawing.Size(72, 28);
            this.label_old_pwd.TabIndex = 6;
            this.label_old_pwd.Text = "原密码";
            // 
            // textBox_new_pwd
            // 
            this.textBox_new_pwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_new_pwd.Location = new System.Drawing.Point(178, 57);
            this.textBox_new_pwd.Name = "textBox_new_pwd";
            this.textBox_new_pwd.Size = new System.Drawing.Size(230, 35);
            this.textBox_new_pwd.TabIndex = 2;
            this.textBox_new_pwd.UseSystemPasswordChar = true;
            // 
            // label_new_pwd
            // 
            this.label_new_pwd.AutoSize = true;
            this.label_new_pwd.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_new_pwd.Location = new System.Drawing.Point(48, 60);
            this.label_new_pwd.Name = "label_new_pwd";
            this.label_new_pwd.Size = new System.Drawing.Size(72, 28);
            this.label_new_pwd.TabIndex = 6;
            this.label_new_pwd.Text = "新密码";
            // 
            // textBox_new_pwd2
            // 
            this.textBox_new_pwd2.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_new_pwd2.Location = new System.Drawing.Point(178, 98);
            this.textBox_new_pwd2.Name = "textBox_new_pwd2";
            this.textBox_new_pwd2.Size = new System.Drawing.Size(230, 35);
            this.textBox_new_pwd2.TabIndex = 3;
            this.textBox_new_pwd2.UseSystemPasswordChar = true;
            // 
            // label_new_pwd2
            // 
            this.label_new_pwd2.AutoSize = true;
            this.label_new_pwd2.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_new_pwd2.Location = new System.Drawing.Point(25, 101);
            this.label_new_pwd2.Name = "label_new_pwd2";
            this.label_new_pwd2.Size = new System.Drawing.Size(112, 28);
            this.label_new_pwd2.TabIndex = 6;
            this.label_new_pwd2.Text = "确认新密码";
            // 
            // button_Cancel
            // 
            this.button_Cancel.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Location = new System.Drawing.Point(266, 151);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(95, 35);
            this.button_Cancel.TabIndex = 5;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // changePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 232);
            this.ControlBox = false;
            this.Controls.Add(this.label_new_pwd2);
            this.Controls.Add(this.textBox_new_pwd2);
            this.Controls.Add(this.label_new_pwd);
            this.Controls.Add(this.textBox_new_pwd);
            this.Controls.Add(this.label_old_pwd);
            this.Controls.Add(this.textBox_old_pwd);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "changePassword";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "修改密码";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.TextBox textBox_old_pwd;
        private System.Windows.Forms.Label label_old_pwd;
        private System.Windows.Forms.TextBox textBox_new_pwd;
        private System.Windows.Forms.Label label_new_pwd;
        private System.Windows.Forms.TextBox textBox_new_pwd2;
        private System.Windows.Forms.Label label_new_pwd2;
        private System.Windows.Forms.Button button_Cancel;
    }
}