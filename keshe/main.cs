using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using keshe.Model;
using keshe.BLL;

namespace keshe
{
    public partial class main : Form
    {
        private static readonly BindingList<UserAction> ActionList = new BindingList<UserAction>();
        private int index = -1;
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                /// <summary>
                /// 若用户点了关闭按钮，则执行下面代码
                /// 调用Close()或者Dispose()方法不会触发
                /// </summary>
                if (ActionList.Count != 0)
                {
                    DialogResult dr = MessageBox.Show($"您还有 {ActionList.Count} 个操作未提交，是否继续？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Cancel)
                    {
                        return;
                    }
                }
                ActionList.Clear();
                GlobalObject.reader = null;
                System.Environment.Exit(0);
            }
            base.WndProc(ref msg);
        }

        private void dvg_style()
        {
            dgv_Actions.ColumnHeadersDefaultCellStyle.Font = new Font("宋体", 12, FontStyle.Bold);
            dgv_Actions.Columns["actionSource"].HeaderText = "操作源";
            dgv_Actions.Columns["actionModel"].Visible = false;
            dgv_Actions.Columns["actionType"].HeaderText = "操作类型";
            dgv_Actions.Columns["actionDescription"].HeaderText = "操作描述";
            dgv_Actions.Columns["actionSource"].FillWeight = 15;
            dgv_Actions.Columns["actionType"].FillWeight = 15;
            dgv_Actions.Columns["actionDescription"].FillWeight = 70;
        }

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.Text =$"keshe 图书管理系统 v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} 祝您阅读愉快！ 当前登录：{GlobalObject.reader.rdName}";
            dgv_Actions.DataSource = ActionList;
            dvg_style();

            #region 测试数据
            UserAction test1 = new UserAction();
            UserAction test2 = new UserAction();
            UserAction test3 = new UserAction();
            UserAction test4 = new UserAction();
            UserAction test5 = new UserAction();
            ReaderType test_rdtype = new ReaderType();
            test_rdtype.rdType = 99;
            test_rdtype.rdTypeName = "测试";
            test1.actionType = "Update";
            test1.actionDescription = "TEST_ONLY_1";
            ActionList.Add(test1);
            test2.actionSource = "ReaderType";
            test2.actionModel = test_rdtype;
            test2.actionType = "Add";
            test2.actionDescription = "ReaderType TEST_ONLY_2";
            ActionList.Add(test2);
            test3.actionType = "Delete";
            test3.actionDescription = "TEST_ONLY_3";
            ActionList.Add(test3);
            test4.actionType = "Update";
            test4.actionDescription = "TEST_ONLY_4";
            ActionList.Add(test4);
            test5.actionType = "Update";
            test5.actionDescription = "TEST_ONLY_5";
            ActionList.Add(test5);
            #endregion

            toolStripStatusLabel.Text = $"[Info] 加载完毕，就绪";
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActionList.Count != 0)
            {
                DialogResult dr = MessageBox.Show($"您还有 {ActionList.Count} 个操作未提交，是否继续？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr == DialogResult.OK)
                {
                    GlobalObject.reader = null;
                    ActionList.Clear();
                    this.Dispose();
                }
                else
                    return;
            }
            GlobalObject.reader = null;
            ActionList.Clear();
            this.Dispose();
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form changePassword = new changePassword();
            DialogResult result = changePassword.ShowDialog();
            if (result == DialogResult.OK)
            {
                GlobalObject.actionSource.actionSource = "Reader";
                GlobalObject.actionSource.actionModel = GlobalObject.readerSource;
                GlobalObject.actionSource.actionType = "Update";
                GlobalObject.actionSource.actionDescription = $"修改用户 {GlobalObject.readerSource.rdName}(ID:{GlobalObject.readerSource.rdID}) 的密码。";
                ActionList.Add(new UserAction(GlobalObject.actionSource));
            }
        }

        private void 新书入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addBook = new addBook();
            addBook.ShowDialog();
        }
        private void dgv_Actions_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                if (e.RowIndex != -1)
                {
                    this.dgv_Actions.Rows[e.RowIndex].Selected = true;//是否选中当前行
                    index = e.RowIndex;
                    this.dgv_Actions.CurrentCell = this.dgv_Actions.Rows[e.RowIndex].Cells[0];
                    //每次选中行都刷新到datagridview中的活动单元格
                    this.contextMenuStrip.Show(this.dgv_Actions, e.Location);
                    //指定控件（DataGridView），指定位置（鼠标指定位置）
                    this.contextMenuStrip.Show(Cursor.Position);//锁定右键列表出现的位置
                    toolStripStatusLabel.Text = $"[Debug] 您当前操作的是第 {e.RowIndex + 1} 个UserAction，总共 {ActionList.Count} 个，{ActionList[e.RowIndex].actionDescription}";
                }
            }
        }

        private void 放弃全部操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ActionList.Clear();
            toolStripStatusLabel.Text = $"[Info] 已放弃全部操作，就绪";
        }

        private void 放弃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                toolStripStatusLabel.Text = $"[Info] 放弃操作 {ActionList[index].actionDescription} 成功，就绪";
                ActionList.RemoveAt(index);
                index = -1;
            }
        }

        private void 提交操作ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                if (ActionList[index].actionModel != null)
                {
                    if (mainControler.SubmitAction(ActionList[index]) == 0)
                    {
                        MessageBox.Show($"提交操作 {ActionList[index].actionDescription} 失败！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel.Text = $"[Info] 提交操作 {ActionList[index].actionDescription} 失败，就绪";
                    }
                    else
                    {
                        toolStripStatusLabel.Text = $"[Info] 提交操作 {ActionList[index].actionDescription} 成功，就绪";
                        ActionList.RemoveAt(index);
                    }
                }
                else
                {
                    MessageBox.Show($"提交操作 {ActionList[index].actionDescription} 失败！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    toolStripStatusLabel.Text = $"[Info] 提交操作 {ActionList[index].actionDescription} 失败，就绪";
                }
                index = -1;
            }
        }

        private void 提交全部操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i=0;i<ActionList.Count;i++)
            {
                // 遍历删除，不能使用foreach，因为容器的count会发生变化！
                if (ActionList[i].actionModel != null)
                {
                    if (mainControler.SubmitAction(ActionList[i]) == 0)
                    {
                        MessageBox.Show($"提交操作 {ActionList[i].actionDescription} 失败！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        ActionList.Remove(ActionList[i]);
                        i--; // ActionList.Count在上一步中减小了1，所以这里要让i不变！
                    }
                }
                else
                {
                    MessageBox.Show($"提交操作 {ActionList[i].actionDescription} 失败！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            if (ActionList.Count != 0)
            {
                toolStripStatusLabel.Text = $"[Info] 已提交全部操作，但部分操作提交失败，就绪";
            }
            else
            {
                toolStripStatusLabel.Text = $"[Info] 已提交全部操作，就绪";
            }
        }

        private void dgv_Actions_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (e.RowIndex != -1)
                {
                    index = e.RowIndex;
                    if (ActionList[index].actionModel != null)
                    {
                        if (mainControler.SubmitAction(ActionList[index]) == 0)
                        {
                            MessageBox.Show($"提交操作 {ActionList[index].actionDescription} 失败！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            toolStripStatusLabel.Text = $"[Info] 提交操作 {ActionList[index].actionDescription} 失败，就绪";
                        }
                        else
                        {
                            toolStripStatusLabel.Text = $"[Info] 提交操作 {ActionList[index].actionDescription} 成功，就绪";
                            ActionList.RemoveAt(index);
                        }
                    }
                    else
                    {
                        MessageBox.Show($"提交操作 {ActionList[index].actionDescription} 失败！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        toolStripStatusLabel.Text = $"[Info] 提交操作 {ActionList[index].actionDescription} 失败，就绪";
                    }
                    index = -1;
                }
            }
        }

        private void dgv_Actions_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                toolStripStatusLabel.Text = "[Info] 等待操作，就绪";
            }
        }
    }
}
