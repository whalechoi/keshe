
namespace keshe
{
    partial class bookManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(bookManager));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSBtnGlance = new System.Windows.Forms.ToolStripButton();
            this.tSBtnAdvancedSelect = new System.Windows.Forms.ToolStripButton();
            this.tSBtnDetail = new System.Windows.Forms.ToolStripButton();
            this.tSBtnAdd = new System.Windows.Forms.ToolStripButton();
            this.tSBtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.tSBtnDelete = new System.Windows.Forms.ToolStripButton();
            this.tSBtnBack = new System.Windows.Forms.ToolStripButton();
            this.tSBtnExpertExcel = new System.Windows.Forms.ToolStripButton();
            this.tSBtnPreview = new System.Windows.Forms.ToolStripButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labBookNumber = new System.Windows.Forms.Label();
            this.txtBBookNumber = new System.Windows.Forms.TextBox();
            this.labPressNumber = new System.Windows.Forms.Label();
            this.txtBPressNumber = new System.Windows.Forms.TextBox();
            this.labBookID = new System.Windows.Forms.Label();
            this.txtBBookID = new System.Windows.Forms.TextBox();
            this.labPressDate = new System.Windows.Forms.Label();
            this.txtBPressDate = new System.Windows.Forms.TextBox();
            this.labBookName = new System.Windows.Forms.Label();
            this.txtBBookName = new System.Windows.Forms.TextBox();
            this.labEnterDate = new System.Windows.Forms.Label();
            this.txtBEnterDate = new System.Windows.Forms.TextBox();
            this.labBookAuthor = new System.Windows.Forms.Label();
            this.txtBBookAuthor = new System.Windows.Forms.TextBox();
            this.labStockDate = new System.Windows.Forms.Label();
            this.txtBStockDate = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSBtnGlance,
            this.tSBtnAdd,
            this.tSBtnAdvancedSelect,
            this.tSBtnDetail,
            this.tSBtnUpdate,
            this.tSBtnDelete,
            this.tSBtnExpertExcel,
            this.tSBtnPreview,
            this.tSBtnBack});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(940, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSBtnGlance
            // 
            this.tSBtnGlance.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnGlance.Image")));
            this.tSBtnGlance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnGlance.Name = "tSBtnGlance";
            this.tSBtnGlance.Size = new System.Drawing.Size(63, 24);
            this.tSBtnGlance.Text = "浏览";
            // 
            // tSBtnAdvancedSelect
            // 
            this.tSBtnAdvancedSelect.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnAdvancedSelect.Image")));
            this.tSBtnAdvancedSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnAdvancedSelect.Name = "tSBtnAdvancedSelect";
            this.tSBtnAdvancedSelect.Size = new System.Drawing.Size(93, 24);
            this.tSBtnAdvancedSelect.Text = "高级查询";
            // 
            // tSBtnDetail
            // 
            this.tSBtnDetail.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnDetail.Image")));
            this.tSBtnDetail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnDetail.Name = "tSBtnDetail";
            this.tSBtnDetail.Size = new System.Drawing.Size(63, 24);
            this.tSBtnDetail.Text = "明细";
            // 
            // tSBtnAdd
            // 
            this.tSBtnAdd.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnAdd.Image")));
            this.tSBtnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnAdd.Name = "tSBtnAdd";
            this.tSBtnAdd.Size = new System.Drawing.Size(63, 24);
            this.tSBtnAdd.Text = "添加";
            // 
            // tSBtnUpdate
            // 
            this.tSBtnUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnUpdate.Image")));
            this.tSBtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnUpdate.Name = "tSBtnUpdate";
            this.tSBtnUpdate.Size = new System.Drawing.Size(63, 24);
            this.tSBtnUpdate.Text = "修改";
            // 
            // tSBtnDelete
            // 
            this.tSBtnDelete.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnDelete.Image")));
            this.tSBtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnDelete.Name = "tSBtnDelete";
            this.tSBtnDelete.Size = new System.Drawing.Size(63, 24);
            this.tSBtnDelete.Text = "删除";
            // 
            // tSBtnBack
            // 
            this.tSBtnBack.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnBack.Image")));
            this.tSBtnBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnBack.Name = "tSBtnBack";
            this.tSBtnBack.Size = new System.Drawing.Size(63, 24);
            this.tSBtnBack.Text = "返回";
            // 
            // tSBtnExpertExcel
            // 
            this.tSBtnExpertExcel.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnExpertExcel.Image")));
            this.tSBtnExpertExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnExpertExcel.Name = "tSBtnExpertExcel";
            this.tSBtnExpertExcel.Size = new System.Drawing.Size(100, 24);
            this.tSBtnExpertExcel.Text = "导出Excel";
            // 
            // tSBtnPreview
            // 
            this.tSBtnPreview.Image = ((System.Drawing.Image)(resources.GetObject("tSBtnPreview.Image")));
            this.tSBtnPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSBtnPreview.Name = "tSBtnPreview";
            this.tSBtnPreview.Size = new System.Drawing.Size(63, 24);
            this.tSBtnPreview.Text = "预览";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(20, 148);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(908, 299);
            this.dataGridView1.TabIndex = 3;
            // 
            // labBookNumber
            // 
            this.labBookNumber.AutoSize = true;
            this.labBookNumber.Location = new System.Drawing.Point(34, 46);
            this.labBookNumber.Name = "labBookNumber";
            this.labBookNumber.Size = new System.Drawing.Size(67, 15);
            this.labBookNumber.TabIndex = 4;
            this.labBookNumber.Text = "图书序号";
            // 
            // txtBBookNumber
            // 
            this.txtBBookNumber.Location = new System.Drawing.Point(107, 43);
            this.txtBBookNumber.Name = "txtBBookNumber";
            this.txtBBookNumber.Size = new System.Drawing.Size(100, 25);
            this.txtBBookNumber.TabIndex = 5;
            // 
            // labPressNumber
            // 
            this.labPressNumber.AutoSize = true;
            this.labPressNumber.Location = new System.Drawing.Point(34, 100);
            this.labPressNumber.Name = "labPressNumber";
            this.labPressNumber.Size = new System.Drawing.Size(67, 15);
            this.labPressNumber.TabIndex = 4;
            this.labPressNumber.Text = "出版社号";
            // 
            // txtBPressNumber
            // 
            this.txtBPressNumber.Location = new System.Drawing.Point(107, 97);
            this.txtBPressNumber.Name = "txtBPressNumber";
            this.txtBPressNumber.Size = new System.Drawing.Size(100, 25);
            this.txtBPressNumber.TabIndex = 5;
            // 
            // labBookID
            // 
            this.labBookID.AutoSize = true;
            this.labBookID.Location = new System.Drawing.Point(231, 46);
            this.labBookID.Name = "labBookID";
            this.labBookID.Size = new System.Drawing.Size(67, 15);
            this.labBookID.TabIndex = 4;
            this.labBookID.Text = "图书编号";
            // 
            // txtBBookID
            // 
            this.txtBBookID.Location = new System.Drawing.Point(304, 43);
            this.txtBBookID.Name = "txtBBookID";
            this.txtBBookID.Size = new System.Drawing.Size(100, 25);
            this.txtBBookID.TabIndex = 5;
            // 
            // labPressDate
            // 
            this.labPressDate.AutoSize = true;
            this.labPressDate.Location = new System.Drawing.Point(231, 100);
            this.labPressDate.Name = "labPressDate";
            this.labPressDate.Size = new System.Drawing.Size(67, 15);
            this.labPressDate.TabIndex = 4;
            this.labPressDate.Text = "出版日期";
            // 
            // txtBPressDate
            // 
            this.txtBPressDate.Location = new System.Drawing.Point(304, 97);
            this.txtBPressDate.Name = "txtBPressDate";
            this.txtBPressDate.Size = new System.Drawing.Size(100, 25);
            this.txtBPressDate.TabIndex = 5;
            // 
            // labBookName
            // 
            this.labBookName.AutoSize = true;
            this.labBookName.Location = new System.Drawing.Point(431, 46);
            this.labBookName.Name = "labBookName";
            this.labBookName.Size = new System.Drawing.Size(67, 15);
            this.labBookName.TabIndex = 4;
            this.labBookName.Text = "图书名称";
            // 
            // txtBBookName
            // 
            this.txtBBookName.Location = new System.Drawing.Point(504, 43);
            this.txtBBookName.Name = "txtBBookName";
            this.txtBBookName.Size = new System.Drawing.Size(100, 25);
            this.txtBBookName.TabIndex = 5;
            // 
            // labEnterDate
            // 
            this.labEnterDate.AutoSize = true;
            this.labEnterDate.Location = new System.Drawing.Point(431, 100);
            this.labEnterDate.Name = "labEnterDate";
            this.labEnterDate.Size = new System.Drawing.Size(67, 15);
            this.labEnterDate.TabIndex = 4;
            this.labEnterDate.Text = "入馆日期";
            // 
            // txtBEnterDate
            // 
            this.txtBEnterDate.Location = new System.Drawing.Point(504, 97);
            this.txtBEnterDate.Name = "txtBEnterDate";
            this.txtBEnterDate.Size = new System.Drawing.Size(100, 25);
            this.txtBEnterDate.TabIndex = 5;
            // 
            // labBookAuthor
            // 
            this.labBookAuthor.AutoSize = true;
            this.labBookAuthor.Location = new System.Drawing.Point(635, 46);
            this.labBookAuthor.Name = "labBookAuthor";
            this.labBookAuthor.Size = new System.Drawing.Size(67, 15);
            this.labBookAuthor.TabIndex = 4;
            this.labBookAuthor.Text = "图书作者";
            // 
            // txtBBookAuthor
            // 
            this.txtBBookAuthor.Location = new System.Drawing.Point(708, 43);
            this.txtBBookAuthor.Name = "txtBBookAuthor";
            this.txtBBookAuthor.Size = new System.Drawing.Size(100, 25);
            this.txtBBookAuthor.TabIndex = 5;
            // 
            // labStockDate
            // 
            this.labStockDate.AutoSize = true;
            this.labStockDate.Location = new System.Drawing.Point(635, 100);
            this.labStockDate.Name = "labStockDate";
            this.labStockDate.Size = new System.Drawing.Size(67, 15);
            this.labStockDate.TabIndex = 4;
            this.labStockDate.Text = "库存数量";
            // 
            // txtBStockDate
            // 
            this.txtBStockDate.Location = new System.Drawing.Point(708, 97);
            this.txtBStockDate.Name = "txtBStockDate";
            this.txtBStockDate.Size = new System.Drawing.Size(100, 25);
            this.txtBStockDate.TabIndex = 5;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(839, 99);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 6;
            this.btnSelect.Text = "查询";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // SelectBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 450);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtBPressNumber);
            this.Controls.Add(this.txtBPressDate);
            this.Controls.Add(this.txtBEnterDate);
            this.Controls.Add(this.txtBStockDate);
            this.Controls.Add(this.txtBBookAuthor);
            this.Controls.Add(this.txtBBookName);
            this.Controls.Add(this.txtBBookID);
            this.Controls.Add(this.txtBBookNumber);
            this.Controls.Add(this.labPressNumber);
            this.Controls.Add(this.labEnterDate);
            this.Controls.Add(this.labPressDate);
            this.Controls.Add(this.labStockDate);
            this.Controls.Add(this.labBookAuthor);
            this.Controls.Add(this.labBookName);
            this.Controls.Add(this.labBookID);
            this.Controls.Add(this.labBookNumber);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SelectBook";
            this.Text = "SelectBook";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSBtnGlance;
        private System.Windows.Forms.ToolStripButton tSBtnAdvancedSelect;
        private System.Windows.Forms.ToolStripButton tSBtnDetail;
        private System.Windows.Forms.ToolStripButton tSBtnAdd;
        private System.Windows.Forms.ToolStripButton tSBtnUpdate;
        private System.Windows.Forms.ToolStripButton tSBtnDelete;
        private System.Windows.Forms.ToolStripButton tSBtnBack;
        private System.Windows.Forms.ToolStripButton tSBtnExpertExcel;
        private System.Windows.Forms.ToolStripButton tSBtnPreview;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label labBookNumber;
        private System.Windows.Forms.TextBox txtBBookNumber;
        private System.Windows.Forms.Label labPressNumber;
        private System.Windows.Forms.TextBox txtBPressNumber;
        private System.Windows.Forms.Label labBookID;
        private System.Windows.Forms.TextBox txtBBookID;
        private System.Windows.Forms.Label labPressDate;
        private System.Windows.Forms.TextBox txtBPressDate;
        private System.Windows.Forms.Label labBookName;
        private System.Windows.Forms.TextBox txtBBookName;
        private System.Windows.Forms.Label labEnterDate;
        private System.Windows.Forms.TextBox txtBEnterDate;
        private System.Windows.Forms.Label labBookAuthor;
        private System.Windows.Forms.TextBox txtBBookAuthor;
        private System.Windows.Forms.Label labStockDate;
        private System.Windows.Forms.TextBox txtBStockDate;
        private System.Windows.Forms.Button btnSelect;
    }
}