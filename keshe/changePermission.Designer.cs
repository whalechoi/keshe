
namespace keshe
{
    partial class changePermission
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(changePermission));
            this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_top = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_borrowCardAdmin = new System.Windows.Forms.CheckBox();
            this.checkBox_bookAdmin = new System.Windows.Forms.CheckBox();
            this.checkBox_borrowAdmin = new System.Windows.Forms.CheckBox();
            this.checkBox_systemAdmin = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel_bottom = new System.Windows.Forms.TableLayoutPanel();
            this.button_OK = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel_main.SuspendLayout();
            this.tableLayoutPanel_top.SuspendLayout();
            this.tableLayoutPanel_bottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel_main
            // 
            this.tableLayoutPanel_main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_main.ColumnCount = 1;
            this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_top, 0, 0);
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_bottom, 0, 1);
            this.tableLayoutPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_main.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            this.tableLayoutPanel_main.RowCount = 2;
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel_main.Size = new System.Drawing.Size(422, 233);
            this.tableLayoutPanel_main.TabIndex = 0;
            // 
            // tableLayoutPanel_top
            // 
            this.tableLayoutPanel_top.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_top.ColumnCount = 2;
            this.tableLayoutPanel_top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_top.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_top.Controls.Add(this.checkBox_borrowCardAdmin, 0, 0);
            this.tableLayoutPanel_top.Controls.Add(this.checkBox_bookAdmin, 1, 0);
            this.tableLayoutPanel_top.Controls.Add(this.checkBox_borrowAdmin, 0, 1);
            this.tableLayoutPanel_top.Controls.Add(this.checkBox_systemAdmin, 1, 1);
            this.tableLayoutPanel_top.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_top.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_top.Name = "tableLayoutPanel_top";
            this.tableLayoutPanel_top.RowCount = 2;
            this.tableLayoutPanel_top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_top.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel_top.Size = new System.Drawing.Size(416, 177);
            this.tableLayoutPanel_top.TabIndex = 0;
            // 
            // checkBox_borrowCardAdmin
            // 
            this.checkBox_borrowCardAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_borrowCardAdmin.AutoSize = true;
            this.checkBox_borrowCardAdmin.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_borrowCardAdmin.Location = new System.Drawing.Point(27, 28);
            this.checkBox_borrowCardAdmin.Name = "checkBox_borrowCardAdmin";
            this.checkBox_borrowCardAdmin.Size = new System.Drawing.Size(154, 32);
            this.checkBox_borrowCardAdmin.TabIndex = 0;
            this.checkBox_borrowCardAdmin.Text = "借书证管理员";
            this.checkBox_borrowCardAdmin.UseVisualStyleBackColor = true;
            // 
            // checkBox_bookAdmin
            // 
            this.checkBox_bookAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_bookAdmin.AutoSize = true;
            this.checkBox_bookAdmin.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_bookAdmin.Location = new System.Drawing.Point(245, 28);
            this.checkBox_bookAdmin.Name = "checkBox_bookAdmin";
            this.checkBox_bookAdmin.Size = new System.Drawing.Size(134, 32);
            this.checkBox_bookAdmin.TabIndex = 1;
            this.checkBox_bookAdmin.Text = "图书管理员";
            this.checkBox_bookAdmin.UseVisualStyleBackColor = true;
            // 
            // checkBox_borrowAdmin
            // 
            this.checkBox_borrowAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_borrowAdmin.AutoSize = true;
            this.checkBox_borrowAdmin.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_borrowAdmin.Location = new System.Drawing.Point(37, 116);
            this.checkBox_borrowAdmin.Name = "checkBox_borrowAdmin";
            this.checkBox_borrowAdmin.Size = new System.Drawing.Size(134, 32);
            this.checkBox_borrowAdmin.TabIndex = 2;
            this.checkBox_borrowAdmin.Text = "借阅管理员";
            this.checkBox_borrowAdmin.UseVisualStyleBackColor = true;
            // 
            // checkBox_systemAdmin
            // 
            this.checkBox_systemAdmin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox_systemAdmin.AutoSize = true;
            this.checkBox_systemAdmin.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_systemAdmin.Location = new System.Drawing.Point(245, 116);
            this.checkBox_systemAdmin.Name = "checkBox_systemAdmin";
            this.checkBox_systemAdmin.Size = new System.Drawing.Size(134, 32);
            this.checkBox_systemAdmin.TabIndex = 3;
            this.checkBox_systemAdmin.Text = "系统管理员";
            this.checkBox_systemAdmin.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel_bottom
            // 
            this.tableLayoutPanel_bottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_bottom.ColumnCount = 3;
            this.tableLayoutPanel_bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel_bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel_bottom.Controls.Add(this.button_OK, 1, 0);
            this.tableLayoutPanel_bottom.Controls.Add(this.button_Cancel, 2, 0);
            this.tableLayoutPanel_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_bottom.Location = new System.Drawing.Point(3, 186);
            this.tableLayoutPanel_bottom.Name = "tableLayoutPanel_bottom";
            this.tableLayoutPanel_bottom.RowCount = 1;
            this.tableLayoutPanel_bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_bottom.Size = new System.Drawing.Size(416, 44);
            this.tableLayoutPanel_bottom.TabIndex = 1;
            // 
            // button_OK
            // 
            this.button_OK.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_OK.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_OK.Location = new System.Drawing.Point(259, 3);
            this.button_OK.Name = "button_OK";
            this.button_OK.Size = new System.Drawing.Size(74, 38);
            this.button_OK.TabIndex = 0;
            this.button_OK.Text = "修改";
            this.button_OK.UseVisualStyleBackColor = true;
            this.button_OK.Click += new System.EventHandler(this.button_OK_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Cancel.Font = new System.Drawing.Font("字由心雨 常规体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Cancel.Location = new System.Drawing.Point(339, 3);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(74, 38);
            this.button_Cancel.TabIndex = 1;
            this.button_Cancel.Text = "取消";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // changePermission
            // 
            this.AcceptButton = this.button_OK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.button_Cancel;
            this.ClientSize = new System.Drawing.Size(422, 233);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel_main);
            this.Font = new System.Drawing.Font("字由心雨 常规体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "changePermission";
            this.ShowInTaskbar = false;
            this.Text = "权限管理";
            this.TopMost = true;
            this.tableLayoutPanel_main.ResumeLayout(false);
            this.tableLayoutPanel_top.ResumeLayout(false);
            this.tableLayoutPanel_top.PerformLayout();
            this.tableLayoutPanel_bottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_top;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_bottom;
        private System.Windows.Forms.CheckBox checkBox_borrowCardAdmin;
        private System.Windows.Forms.CheckBox checkBox_bookAdmin;
        private System.Windows.Forms.CheckBox checkBox_borrowAdmin;
        private System.Windows.Forms.CheckBox checkBox_systemAdmin;
        private System.Windows.Forms.Button button_OK;
        private System.Windows.Forms.Button button_Cancel;
    }
}