
namespace keshe
{
    partial class readerSearch
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(readerSearch));
            this.dgv_target = new System.Windows.Forms.DataGridView();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel_type = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBox_type = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton_search = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripTextBox_text = new System.Windows.Forms.ToolStripTextBox();
            this.tableLayoutPanel_main = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel_bottom = new System.Windows.Forms.TableLayoutPanel();
            this.label_info = new System.Windows.Forms.Label();
            this.button_previous = new System.Windows.Forms.Button();
            this.button_next = new System.Windows.Forms.Button();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.修改读者信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.删除此读者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_target)).BeginInit();
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel_main.SuspendLayout();
            this.tableLayoutPanel_bottom.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv_target
            // 
            this.dgv_target.AllowUserToAddRows = false;
            this.dgv_target.AllowUserToDeleteRows = false;
            this.dgv_target.AllowUserToResizeRows = false;
            this.dgv_target.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_target.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_target.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_target.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            this.dgv_target.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_target.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_target.Location = new System.Drawing.Point(2, 2);
            this.dgv_target.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_target.MultiSelect = false;
            this.dgv_target.Name = "dgv_target";
            this.dgv_target.ReadOnly = true;
            this.dgv_target.RowHeadersVisible = false;
            this.dgv_target.RowHeadersWidth = 50;
            this.dgv_target.RowTemplate.Height = 27;
            this.dgv_target.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.dgv_target.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_target.Size = new System.Drawing.Size(878, 455);
            this.dgv_target.TabIndex = 0;
            this.dgv_target.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_target_CellMouseClick);
            this.dgv_target.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_target_CellMouseDoubleClick);
            this.dgv_target.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_target_CellMouseUp);
            // 
            // toolStrip
            // 
            this.toolStrip.AutoSize = false;
            this.toolStrip.Font = new System.Drawing.Font("字由心雨 常规体", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel_type,
            this.toolStripSeparator1,
            this.toolStripComboBox_type,
            this.toolStripButton_search,
            this.toolStripSeparator2,
            this.toolStripTextBox_text});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(882, 32);
            this.toolStrip.TabIndex = 6;
            this.toolStrip.Text = "toolStrip1";
            // 
            // toolStripLabel_type
            // 
            this.toolStripLabel_type.Name = "toolStripLabel_type";
            this.toolStripLabel_type.Size = new System.Drawing.Size(88, 29);
            this.toolStripLabel_type.Text = "查找方式";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripComboBox_type
            // 
            this.toolStripComboBox_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox_type.Font = new System.Drawing.Font("字由心雨 常规体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripComboBox_type.Items.AddRange(new object[] {
            "读者编号",
            "读者姓名",
            "性别",
            "单位",
            "电话",
            "邮箱",
            "证件状态"});
            this.toolStripComboBox_type.Name = "toolStripComboBox_type";
            this.toolStripComboBox_type.Size = new System.Drawing.Size(120, 32);
            // 
            // toolStripButton_search
            // 
            this.toolStripButton_search.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_search.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton_search.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_search.Image")));
            this.toolStripButton_search.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_search.Name = "toolStripButton_search";
            this.toolStripButton_search.Size = new System.Drawing.Size(54, 29);
            this.toolStripButton_search.Text = "查找";
            this.toolStripButton_search.Click += new System.EventHandler(this.toolStripButton_search_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 32);
            // 
            // toolStripTextBox_text
            // 
            this.toolStripTextBox_text.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripTextBox_text.Font = new System.Drawing.Font("字由心雨 常规体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripTextBox_text.Name = "toolStripTextBox_text";
            this.toolStripTextBox_text.Size = new System.Drawing.Size(300, 32);
            // 
            // tableLayoutPanel_main
            // 
            this.tableLayoutPanel_main.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_main.ColumnCount = 1;
            this.tableLayoutPanel_main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_main.Controls.Add(this.dgv_target, 0, 0);
            this.tableLayoutPanel_main.Controls.Add(this.tableLayoutPanel_bottom, 0, 1);
            this.tableLayoutPanel_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_main.Location = new System.Drawing.Point(0, 32);
            this.tableLayoutPanel_main.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel_main.Name = "tableLayoutPanel_main";
            this.tableLayoutPanel_main.RowCount = 2;
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel_main.Size = new System.Drawing.Size(882, 501);
            this.tableLayoutPanel_main.TabIndex = 7;
            // 
            // tableLayoutPanel_bottom
            // 
            this.tableLayoutPanel_bottom.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel_bottom.ColumnCount = 3;
            this.tableLayoutPanel_bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_bottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel_bottom.Controls.Add(this.label_info, 0, 0);
            this.tableLayoutPanel_bottom.Controls.Add(this.button_previous, 1, 0);
            this.tableLayoutPanel_bottom.Controls.Add(this.button_next, 2, 0);
            this.tableLayoutPanel_bottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_bottom.Location = new System.Drawing.Point(2, 461);
            this.tableLayoutPanel_bottom.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel_bottom.Name = "tableLayoutPanel_bottom";
            this.tableLayoutPanel_bottom.RowCount = 1;
            this.tableLayoutPanel_bottom.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_bottom.Size = new System.Drawing.Size(878, 38);
            this.tableLayoutPanel_bottom.TabIndex = 1;
            // 
            // label_info
            // 
            this.label_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(2, 17);
            this.label_info.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(95, 21);
            this.label_info.TabIndex = 0;
            this.label_info.Text = "[Info] 加载中";
            // 
            // button_previous
            // 
            this.button_previous.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_previous.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_previous.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_previous.Location = new System.Drawing.Point(683, 4);
            this.button_previous.Margin = new System.Windows.Forms.Padding(2);
            this.button_previous.Name = "button_previous";
            this.button_previous.Size = new System.Drawing.Size(90, 30);
            this.button_previous.TabIndex = 1;
            this.button_previous.Text = "上一页";
            this.button_previous.UseVisualStyleBackColor = true;
            this.button_previous.Click += new System.EventHandler(this.button_previous_Click);
            // 
            // button_next
            // 
            this.button_next.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button_next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.button_next.Location = new System.Drawing.Point(783, 4);
            this.button_next.Margin = new System.Windows.Forms.Padding(2);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(90, 30);
            this.button_next.TabIndex = 1;
            this.button_next.Text = "下一页";
            this.button_next.UseVisualStyleBackColor = true;
            this.button_next.Click += new System.EventHandler(this.button_next_Click);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.修改读者信息ToolStripMenuItem,
            this.删除此读者ToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(193, 52);
            // 
            // 修改读者信息ToolStripMenuItem
            // 
            this.修改读者信息ToolStripMenuItem.Name = "修改读者信息ToolStripMenuItem";
            this.修改读者信息ToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.修改读者信息ToolStripMenuItem.Text = "读者信息[TODO]";
            this.修改读者信息ToolStripMenuItem.Click += new System.EventHandler(this.查看读者信息ToolStripMenuItem_Click);
            // 
            // 删除此读者ToolStripMenuItem
            // 
            this.删除此读者ToolStripMenuItem.Name = "删除此读者ToolStripMenuItem";
            this.删除此读者ToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.删除此读者ToolStripMenuItem.Text = "删除此读者";
            this.删除此读者ToolStripMenuItem.Click += new System.EventHandler(this.权限管理ToolStripMenuItem_Click);
            // 
            // readerSearch
            // 
            this.AcceptButton = this.button_next;
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.CancelButton = this.button_previous;
            this.ClientSize = new System.Drawing.Size(882, 533);
            this.Controls.Add(this.tableLayoutPanel_main);
            this.Controls.Add(this.toolStrip);
            this.Font = new System.Drawing.Font("字由心雨 常规体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(900, 580);
            this.Name = "readerSearch";
            this.Text = "请查找您要管理的读者";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.readerSearch_available_FormClosing);
            this.Load += new System.EventHandler(this.readerSearch_Load);
            this.Resize += new System.EventHandler(this.readerSearch_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_target)).EndInit();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel_main.ResumeLayout(false);
            this.tableLayoutPanel_bottom.ResumeLayout(false);
            this.tableLayoutPanel_bottom.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_target;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel toolStripLabel_type;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox_type;
        private System.Windows.Forms.ToolStripButton toolStripButton_search;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_text;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_main;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_bottom;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button button_previous;
        private System.Windows.Forms.Button button_next;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem 修改读者信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 删除此读者ToolStripMenuItem;
    }
}