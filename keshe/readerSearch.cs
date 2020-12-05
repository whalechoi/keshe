using keshe.BLL;
using keshe.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace keshe
{
    public partial class readerSearch : Form
    {
        public static bool isRBACMode = false;
        delegate void RBACorReaderManagement();
        private void RBAC()
        {
            if (dgv_target.Rows[target].DefaultCellStyle.BackColor == Color.Green)
            {
                MessageBox.Show("对当前读者的权限修改操作已存在于操作队列！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Form _changePermission = changePermission.CreateInstance();
            if (_changePermission.ShowDialog() == DialogResult.OK)
            {
                dgv_target.Rows[target].DefaultCellStyle.BackColor = Color.Green;
                label_info.Text = $"[Info] 修改权限 rdID:{GlobalObject.readerSource.rdID} 已挂起，就绪";
            }
        }
        private void ReaderManagement()
        {

        }
        private void RBACMode()
        {
            this.Text = "请选择您要进行权限管理的读者";
            删除此读者ToolStripMenuItem.Text = "权限管理";
        }
        private static readonly int _maxrow = 15;
        public static Int32 rdID = -1;
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
                rdID = -1;
            }
        }
        private static readerSearch _instance = null; // 单例模式
        public static readerSearch CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new readerSearch();
            }
            return _instance;
        }

        private readerSearch()
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
                    if (dgv_target.Rows[i].Cells[5].Value.ToString() != "0")
                    {
                        dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                    if (dgv_target.Rows[i].Cells[4].Value.ToString() != "有效")
                    {
                        dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.LightSkyBlue;
                    }
                    if (dgv_target.Rows[i].Cells[0].Value.ToString() == "0")
                    {
                        dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.Blue;
                    }
                    foreach (UserAction action in main.ActionList)
                    {
                        if (action.actionSource == "Reader" && action.actionType == "Permission")
                        {
                            Reader tmp = (Reader)action.actionModel;
                            if (dgv_target.Rows[i].Cells[0].Value.ToString() == tmp.rdID.ToString())
                            {
                                dgv_target.Rows[i].DefaultCellStyle.BackColor = Color.Green;
                            }
                        }
                    }
                }
            }
            dgv_target.Columns["读者ID"].FillWeight = 20;
            dgv_target.Columns["读者姓名"].FillWeight = 15;
            dgv_target.Columns["性别"].FillWeight = 15;
            dgv_target.Columns["电话号码"].FillWeight = 20;
            dgv_target.Columns["证件状态"].FillWeight = 15;
            dgv_target.Columns["职权"].FillWeight = 15;
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

        private void readerSearch_Load(object sender, EventArgs e)
        {
            if (isRBACMode)
            {
                RBACMode();
            }
            toolStripComboBox_type.SelectedIndex = 0;
            dgv_target.DataSource = readerSearchControler.GetDTby("_ALL", "", 0, _maxrow);
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
                    type = "rdID";
                    break;
                case 1:
                    type = "rdName";
                    break;
                case 2:
                    type = "rdSex";
                    break;
                case 3:
                    type = "rdDept";
                    break;
                case 4:
                    type = "rdPhone";
                    break;
                case 5:
                    type = "rdEmail";
                    break;
                case 6:
                    type = "rdStatus";
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
                dgv_target.DataSource = readerSearchControler.GetDTby(type, toolStripTextBox_text.Text, 0, _maxrow);
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
                    type = "rdID";
                    break;
                case 1:
                    type = "rdName";
                    break;
                case 2:
                    type = "rdSex";
                    break;
                case 3:
                    type = "rdDept";
                    break;
                case 4:
                    type = "rdPhone";
                    break;
                case 5:
                    type = "rdEmail";
                    break;
                case 6:
                    type = "rdStatus";
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
                dgv_target.DataSource = readerSearchControler.GetDTby(type, toolStripTextBox_text.Text, ((++index) - 1) * _maxrow, _maxrow);
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
                    type = "rdID";
                    break;
                case 1:
                    type = "rdName";
                    break;
                case 2:
                    type = "rdSex";
                    break;
                case 3:
                    type = "rdDept";
                    break;
                case 4:
                    type = "rdPhone";
                    break;
                case 5:
                    type = "rdEmail";
                    break;
                case 6:
                    type = "rdStatus";
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
                dgv_target.DataSource = readerSearchControler.GetDTby(type, toolStripTextBox_text.Text, ((--index) - 1) * _maxrow, _maxrow);
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确查询内容！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            dvg_style();
            button_check();
        }
        private void readerSearch_Resize(object sender, EventArgs e)
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
                        MessageBox.Show("该用户属于系统，禁止对其进行任何操作！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    this.dgv_target.Rows[e.RowIndex].Selected = true;//是否选中当前行
                    target = e.RowIndex;
                    this.dgv_target.CurrentCell = this.dgv_target.Rows[e.RowIndex].Cells[0];
                    //每次选中行都刷新到datagridview中的活动单元格
                    this.contextMenuStrip.Show(this.dgv_target, e.Location);
                    //指定控件（DataGridView），指定位置（鼠标指定位置）
                    this.contextMenuStrip.Show(Cursor.Position);//锁定右键列表出现的位置
                    label_info.Text = $"[Debug] 您当前操作的读者是 rdID:{dgv_target.Rows[e.RowIndex].Cells[0].Value}(rdName:{dgv_target.Rows[e.RowIndex].Cells[1].Value})";
                }
            }
        }

        private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rdID = Int32.Parse(dgv_target.Rows[target].Cells[0].Value.ToString());
            RBACorReaderManagement x;
            if (isRBACMode)
            {
                x = new RBACorReaderManagement(RBAC);
            }
            else
            {
                x = new RBACorReaderManagement(ReaderManagement);
            }
            x();
        }

        private void readerSearch_available_FormClosing(object sender, FormClosingEventArgs e)
        {
            rdID = -1;
            _instance = null;
            this.Dispose();
        }

        private void 查看读者信息ToolStripMenuItem_Click(object sender, EventArgs e)
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
