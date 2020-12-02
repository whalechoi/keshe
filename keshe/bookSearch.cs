using keshe.BLL;
using keshe.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace keshe
{
    public partial class bookSearch : Form
    {
        private static readonly int _maxrow = 20;
        public static int bkID = -1;
        private int index = -1;
        private int target = -1;
        public static bool isExist()
        {
            if (_instance != null)
            {
                return true;
            }
            return false;
        }
        public static void disposeAll()
        {
            if (_instance != null)
            {
                _instance.Dispose();
                _instance = null;
                bkID = -1;
            }
        }
        private static bookSearch _instance = null; // 单例模式
        public static bookSearch CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new bookSearch();
            }
            return _instance;
        }

        private bookSearch()
        {
            InitializeComponent();
        }

        private void dvg_style()
        {
            if (dgv_target.RowCount != 0)
            {
                int h = (dgv_target.Size.Height - dgv_target.ColumnHeadersHeight) / _maxrow;
                for (int i = 0; i < dgv_target.RowCount; i++)
                {
                    dgv_target.Rows[i].Height = h;
                    if (dgv_target.Rows[i].Cells[0].Value.ToString() == "0")
                    {
                        dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                    }
                    foreach (UserAction action in main.ActionList)
                    {
                        if (action.actionSource == "Book" && action.actionType == "Delete")
                        {
                            Book tmp = (Book)action.actionModel;
                            if (dgv_target.Rows[i].Cells[0].Value.ToString() == tmp.bkID.ToString())
                            {
                                dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.Red;
                            }
                        }
                        if (action.actionSource == "Book" && action.actionType == "Update")
                        {
                            Book tmp = (Book)action.actionModel;
                            if (dgv_target.Rows[i].Cells[0].Value.ToString() == tmp.bkID.ToString())
                            {
                                dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.Orange;
                            }
                        }

                    }
                }
            }
            dgv_target.Columns["图书序号"].FillWeight = 8;
            dgv_target.Columns["图书编号"].FillWeight = 8;
            dgv_target.Columns["图书名称"].FillWeight = 20;
            dgv_target.Columns["图书作者"].FillWeight = 10;
            dgv_target.Columns["出版社名"].FillWeight = 15;
            dgv_target.Columns["标准ISBN"].FillWeight = 15;
            dgv_target.Columns["出版日期"].FillWeight = 15;
            dgv_target.Columns["图书状态"].FillWeight = 9;
        }
        private void button_check()
        {
            if (index == 1)
            {
                button_previous.Enabled = false;
            }
            else
            {
                button_previous.Enabled = true;
            }
            if (dgv_target.RowCount < _maxrow)
            {
                button_next.Enabled = false;
            }
            else
            {
                button_next.Enabled = true;
            }
        }

        private void bookSearch_Load(object sender, EventArgs e)
        {
            toolStripComboBox_type.SelectedIndex = 0;
            dgv_target.DataSource = bookSearchControler.GetDTby("_ALL", "", 0, _maxrow);
            index = 1;
            dvg_style();
            button_check();
            label_info.Text = "[Info] 等待选择，就绪";
        }

        private void toolStripButton_search_Click(object sender, EventArgs e)
        {
            string type;
            switch (toolStripComboBox_type.SelectedIndex)
            {
                case 0:
                    type = "bkID";
                    break;
                case 1:
                    type = "bkCode";
                    break;
                case 2:
                    type = "bkName";
                    break;
                case 3:
                    type = "bkAuthor";
                    break;
                case 4:
                    type = "bkPress";
                    break;
                case 5:
                    type = "bkISBN";
                    break;
                default:
                    type = "_ALL";
                    break;
            }
            if (toolStripTextBox_text.Text == "")
            {
                type = "_ALL";
            }
            try
            {
                dgv_target.DataSource = bookSearchControler.GetDTby(type, toolStripTextBox_text.Text, 0, _maxrow);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确查询内容！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            index = 1;
            dvg_style();
            button_check();
            label_info.Text = "[Info] 查找完成，就绪";

        }
        private void button_next_Click(object sender, EventArgs e)
        {
            string type;
            switch (toolStripComboBox_type.SelectedIndex)
            {
                case 0:
                    type = "bkID";
                    break;
                case 1:
                    type = "bkCode";
                    break;
                case 2:
                    type = "bkName";
                    break;
                case 3:
                    type = "bkAuthor";
                    break;
                case 4:
                    type = "bkPress";
                    break;
                case 5:
                    type = "bkISBN";
                    break;
                default:
                    type = "_ALL";
                    break;
            }
            if (toolStripTextBox_text.Text == "")
            {
                type = "_ALL";
            }
            try
            {
                dgv_target.DataSource = bookSearchControler.GetDTby(type, toolStripTextBox_text.Text, ((++index) - 1) * _maxrow, _maxrow);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确查询内容！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dvg_style();
            button_check();
        }

        private void button_previous_Click(object sender, EventArgs e)
        {
            string type;
            switch (toolStripComboBox_type.SelectedIndex)
            {
                case 0:
                    type = "bkID";
                    break;
                case 1:
                    type = "bkCode";
                    break;
                case 2:
                    type = "bkName";
                    break;
                case 3:
                    type = "bkAuthor";
                    break;
                case 4:
                    type = "bkPress";
                    break;
                case 5:
                    type = "bkISBN";
                    break;
                default:
                    type = "_ALL";
                    break;
            }
            if (toolStripTextBox_text.Text == "")
            {
                type = "_ALL";
            }
            try
            {
                dgv_target.DataSource = bookSearchControler.GetDTby(type, toolStripTextBox_text.Text, ((--index) - 1) * _maxrow, _maxrow);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确查询内容！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dvg_style();
            button_check();
        }
        private void bookSearch_Resize(object sender, EventArgs e)
        {
            if (dgv_target.RowCount != 0)
            {
                int h = (dgv_target.Size.Height - dgv_target.ColumnHeadersHeight) / _maxrow;
                for (int i = 0; i < dgv_target.RowCount; i++)
                {
                    dgv_target.Rows[i].Height = h;
                }
            }
        }

        private void dgv_target_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    if (dgv_target.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Blue)
                    {
                        MessageBox.Show("该图书属于系统，禁止对其进行任何操作！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dgv_target.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Red)
                    {
                        MessageBox.Show("对当前图书的删除操作已存在于操作队列！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (dgv_target.Rows[e.RowIndex].DefaultCellStyle.BackColor == Color.Orange)
                    {
                        MessageBox.Show("对当前图书的修改操作已存在于操作队列！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    this.dgv_target.Rows[e.RowIndex].Selected = true;//是否选中当前行
                    target = e.RowIndex;
                    this.dgv_target.CurrentCell = this.dgv_target.Rows[e.RowIndex].Cells[0];
                    //每次选中行都刷新到datagridview中的活动单元格
                    this.contextMenuStrip.Show(this.dgv_target, e.Location);
                    //指定控件（DataGridView），指定位置（鼠标指定位置）
                    this.contextMenuStrip.Show(Cursor.Position);//锁定右键列表出现的位置
                    label_info.Text = $"[Debug] 您当前操作的图书是 bkCode:{dgv_target.Rows[e.RowIndex].Cells[1].Value}(bkID:{dgv_target.Rows[e.RowIndex].Cells[0].Value})";
                }
            }
        }

        private void 删除图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GlobalObject.bookSource.bkID = Int32.Parse(dgv_target.Rows[target].Cells[0].Value.ToString());
            GlobalObject.bookSource.bkCode = dgv_target.Rows[target].Cells[1].Value.ToString();
            GlobalObject.actionSource.actionSource = "Book";
            GlobalObject.actionSource.actionModel = GlobalObject.bookSource;
            GlobalObject.actionSource.actionType = "Delete";
            GlobalObject.actionSource.actionDescription = $"删除图书 {GlobalObject.bookSource.bkCode}(bkID:{GlobalObject.bookSource.bkID}) 。";
            main.addAction(GlobalObject.actionSource);
            dgv_target.Rows[target].DefaultCellStyle.BackColor = Color.Red;
            label_info.Text = $"[Info] 删除图书 bkCode:{dgv_target.Rows[target].Cells[1].Value}(bkID:{dgv_target.Rows[target].Cells[0].Value}) 已挂起，就绪";
        }

        private void bookSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            bkID = -1;
            _instance = null;
            this.Dispose();
        }

        private void 编辑图书信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bkID = Int32.Parse(dgv_target.Rows[target].Cells[0].Value.ToString());
            Form _bookDetail = bookDetail.CreateInstance();
            if(_bookDetail.ShowDialog() == DialogResult.OK)
            {
                dgv_target.Rows[target].DefaultCellStyle.BackColor = Color.Orange;
                label_info.Text = $"[Info] 修改图书信息 bkCode:{dgv_target.Rows[target].Cells[1].Value}(bkID:{dgv_target.Rows[target].Cells[0].Value}) 已挂起，就绪";
            }
        }
    }
}
