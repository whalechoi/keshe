using keshe.BLL;
using keshe.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace keshe
{
    public partial class borrowSearch : Form
    {
        public static bool isReturnMode = false;
        delegate void ContinueOrReturn();
        private void ContinueBook()
        {
            if (dgv_target.Rows[target].DefaultCellStyle.BackColor == Color.Green)
            {
                MessageBox.Show("对当前图书的续借操作已存在于操作队列！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgv_target.Rows[target].DefaultCellStyle.BackColor == Color.Indigo)
            {
                MessageBox.Show("对当前图书的还书操作已存在于操作队列！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgv_target.Rows[target].DefaultCellStyle.BackColor != Color.LightGoldenrodYellow)
            {
                MessageBox.Show("您已还书，无法进行当前操作！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GlobalObject.borrowSource.BorrowID = Int64.Parse(dgv_target.Rows[target].Cells[0].Value.ToString());
            GlobalObject.borrowSource.bkID = Int32.Parse(dgv_target.Rows[target].Cells[1].Value.ToString());
            GlobalObject.actionSource.actionSource = "Borrow";
            GlobalObject.actionSource.actionModel = GlobalObject.borrowSource;
            GlobalObject.actionSource.actionType = "Continue";
            GlobalObject.actionSource.actionDescription = $"续借图书 {GlobalObject.borrowSource.bkID}(BorrowID:{GlobalObject.borrowSource.BorrowID} rdID:{GlobalObject.reader.rdID})。";
            main.addAction(GlobalObject.actionSource);
            dgv_target.Rows[target].DefaultCellStyle.BackColor = Color.Green;
            label_info.Text = $"[Info] 续借图书 bkID:{dgv_target.Rows[target].Cells[1].Value} 已挂起，就绪";
        }
        private void ReturnBook()
        {
            if (dgv_target.Rows[target].DefaultCellStyle.BackColor == Color.Green)
            {
                MessageBox.Show("对当前图书的续借操作已存在于操作队列！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgv_target.Rows[target].DefaultCellStyle.BackColor == Color.Indigo)
            {
                MessageBox.Show("对当前图书的还书操作已存在于操作队列！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (dgv_target.Rows[target].DefaultCellStyle.BackColor != Color.LightGoldenrodYellow)
            {
                MessageBox.Show("您已还书，无法进行当前操作！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            GlobalObject.borrowSource.BorrowID = Int64.Parse(dgv_target.Rows[target].Cells[0].Value.ToString());
            GlobalObject.borrowSource.bkID = Int32.Parse(dgv_target.Rows[target].Cells[1].Value.ToString());
            GlobalObject.actionSource.actionSource = "Borrow";
            GlobalObject.actionSource.actionModel = GlobalObject.borrowSource;
            GlobalObject.actionSource.actionType = "Return";
            GlobalObject.actionSource.actionDescription = $"归还图书 {GlobalObject.borrowSource.bkID}(BorrowID:{GlobalObject.borrowSource.BorrowID} rdID:{GlobalObject.reader.rdID})。";
            main.addAction(GlobalObject.actionSource);
            main.BorrowNotReturn--;
            dgv_target.Rows[target].DefaultCellStyle.BackColor = Color.Indigo;
            label_info.Text = $"[Info] 归还图书 bkID:{dgv_target.Rows[target].Cells[1].Value} 已挂起，就绪";
        }
        private void ReturnMode()
        {
            this.Text = "请选择您要归还的借阅记录";
            借阅此图书ToolStripMenuItem.Text = "归还此图书";
        }
        private static readonly int _maxrow = 10;
        public static Int64 borrowID = -1;
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
                borrowID = -1;
            }
        }
        private static borrowSearch _instance = null; // 单例模式
        public static borrowSearch CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new borrowSearch();
            }
            return _instance;
        }

        private borrowSearch()
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
                    if (dgv_target.Rows[i].Cells[5].Value.ToString() != "1")
                    {
                        dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                    }
                    foreach (UserAction action in main.ActionList)
                    {
                        if (action.actionSource == "Borrow" && action.actionType == "Continue")
                        {
                            Borrow tmp = (Borrow)action.actionModel;
                            if (dgv_target.Rows[i].Cells[0].Value.ToString() == tmp.BorrowID.ToString())
                            {
                                dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            }
                        }
                        if (action.actionSource == "Borrow" && action.actionType == "Return")
                        {
                            Borrow tmp = (Borrow)action.actionModel;
                            if (dgv_target.Rows[i].Cells[0].Value.ToString() == tmp.BorrowID.ToString())
                            {
                                dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.Indigo;
                            }
                        }
                    }
                }
            }
            dgv_target.Columns["借书顺序号"].FillWeight = 14;
            dgv_target.Columns["图书序号"].FillWeight = 12;
            dgv_target.Columns["续借次数"].FillWeight = 12;
            dgv_target.Columns["借书日期"].FillWeight = 15;
            dgv_target.Columns["应还日期"].FillWeight = 15;
            dgv_target.Columns["是否还书"].FillWeight = 12;
            dgv_target.Columns["借书操作员"].FillWeight = 20;
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

        private void borrowSearch_Load(object sender, EventArgs e)
        {
            if (isReturnMode)
            {
                ReturnMode();
            }
            toolStripComboBox_type.SelectedIndex = 0;
            dgv_target.DataSource = borrowSearchControler.GetDTby("_ALL", "", 0, _maxrow, GlobalObject.reader.rdID);
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
                    type = "BorrowID";
                    break;
                case 1:
                    type = "bkID";
                    break;
                case 2:
                    type = "OperatorLend";
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
                dgv_target.DataSource = borrowSearchControler.GetDTby(type, toolStripTextBox_text.Text, 0, _maxrow, GlobalObject.reader.rdID);
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
                    type = "BorrowID";
                    break;
                case 1:
                    type = "bkID";
                    break;
                case 2:
                    type = "OperatorLend";
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
                dgv_target.DataSource = borrowSearchControler.GetDTby(type, toolStripTextBox_text.Text, ((++index) - 1) * _maxrow, _maxrow, GlobalObject.reader.rdID);
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
                    type = "BorrowID";
                    break;
                case 1:
                    type = "bkID";
                    break;
                case 2:
                    type = "OperatorLend";
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
                dgv_target.DataSource = borrowSearchControler.GetDTby(type, toolStripTextBox_text.Text, ((--index) - 1) * _maxrow, _maxrow, GlobalObject.reader.rdID);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确查询内容！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dvg_style();
            button_check();
        }
        private void borrowSearch_Resize(object sender, EventArgs e)
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
                    this.dgv_target.Rows[e.RowIndex].Selected = true;//是否选中当前行
                    target = e.RowIndex;
                    this.dgv_target.CurrentCell = this.dgv_target.Rows[e.RowIndex].Cells[0];
                    //每次选中行都刷新到datagridview中的活动单元格
                    this.contextMenuStrip.Show(this.dgv_target, e.Location);
                    //指定控件（DataGridView），指定位置（鼠标指定位置）
                    this.contextMenuStrip.Show(Cursor.Position);//锁定右键列表出现的位置
                    label_info.Text = $"[Debug] 您当前操作的借书记录是 BorrowID:{dgv_target.Rows[e.RowIndex].Cells[0].Value}(bkID:{dgv_target.Rows[e.RowIndex].Cells[1].Value})";
                }
            }
        }

        private void 续借图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContinueOrReturn x;
            if (isReturnMode)
            {
                x = new ContinueOrReturn(ReturnBook);
            }
            else
            {
                x = new ContinueOrReturn(ContinueBook);
            }
            x();
        }

        private void borrowSearch_available_FormClosing(object sender, FormClosingEventArgs e)
        {
            borrowID = -1;
            _instance = null;
            this.Dispose();
        }

        private void 查看借阅信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dgv_target_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                label_info.Text = "[Info] 等待操作，就绪";
            }
        }

        private void dgv_target_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }
    }
}
