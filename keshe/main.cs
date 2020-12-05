using keshe.BLL;
using keshe.Model;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace keshe
{
    public partial class main : Form
    {
        public static Int32 BorrowMax = -1;
        public static Int32 BorrowNotReturn = -1;
        public static readonly BindingList<UserAction> ActionList = new BindingList<UserAction>();
        private int index = -1;
        public static void addAction(UserAction action)
        {
            ActionList.Add(new UserAction(action)); // 添加拷贝后的用户操作，而不是操作本身的引用
        }
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
                if (canClose())
                {
                    bookAdd.disposeAll();
                    bookSearch.disposeAll();
                    bookSearch_reader.disposeAll();
                    readerSearch.disposeAll();

                    ActionList.Clear();
                    GlobalObject.logout();
                    BorrowMax = -1;
                    BorrowNotReturn = -1;
                    _instance = null;
                    this.Dispose();
                    System.Environment.Exit(0);
                }
                return;
            }
            base.WndProc(ref msg);
        }

        private void dvg_style()
        {
            dgv_Actions.Columns["actionSource"].HeaderText = "操作源";
            dgv_Actions.Columns["actionModel"].Visible = false;
            dgv_Actions.Columns["actionType"].HeaderText = "操作类型";
            dgv_Actions.Columns["actionDescription"].HeaderText = "操作描述";
            dgv_Actions.Columns["actionSource"].FillWeight = 15;
            dgv_Actions.Columns["actionType"].FillWeight = 15;
            dgv_Actions.Columns["actionDescription"].FillWeight = 70;
        }

        private bool canClose()
        {

            if (bookAdd.isExist())
            {
                DialogResult dr = MessageBox.Show($"检测到您正在添加图书，是否继续？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return false;
                }
            }
            if (bookSearch.isExist())
            {
                DialogResult dr = MessageBox.Show($"检测到您正在维护图书，是否继续？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return false;
                }
            }
            if (bookSearch_reader.isExist())
            {
                DialogResult dr = MessageBox.Show($"检测到您正在借阅图书，是否继续？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return false;
                }
            }
            if (borrowSearch.isExist())
            {
                DialogResult dr = MessageBox.Show($"检测到您正在续借或归还图书，是否继续？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return false;
                }
            }
            if (readerSearch.isExist())
            {
                DialogResult dr = MessageBox.Show($"检测到您正在进行权限管理，是否继续？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return false;
                }
            }
            if (ActionList.Count != 0)
            {
                DialogResult dr = MessageBox.Show($"您还有 {ActionList.Count} 个操作未提交，是否继续？", "提示：", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (dr != DialogResult.OK)
                {
                    return false;
                }
            }
            return true;
        }

        private static main _instance = null; // 单例模式
        public static main CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new main();
            }
            return _instance;
        }

        private main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            BorrowMax = mainControler.GetBorrowMax(GlobalObject.reader);
            BorrowNotReturn = mainControler.GetBorrowNotReturn(GlobalObject.reader);
            if (BorrowNotReturn == -1)
            {
                MessageBox.Show("程序发生内部错误，即将强制退出！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Environment.Exit(0);
            }
            this.Text = $"keshe 图书管理系统 v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} 祝您阅读愉快！ 当前登录：{GlobalObject.reader.rdName}";
            dgv_Actions.DataSource = ActionList;
            dvg_style();
            if (GlobalObject.borrowCardAdmin)
            {
                借书证管理ToolStripMenuItem.Visible = true;
            }
            if (GlobalObject.bookAdmin)
            {
                图书管理ToolStripMenuItem.Visible = true;
            }
            if (GlobalObject.borrowAdmin)
            {
                借阅管理ToolStripMenuItem.Visible = true;
            }
            if (GlobalObject.systemAdmin)
            {
                系统管理ToolStripMenuItem.Visible = true;
            }

            #region 测试数据
            //UserAction test1 = new UserAction();
            //UserAction test2 = new UserAction();
            //UserAction test3 = new UserAction();
            //UserAction test4 = new UserAction();
            //UserAction test5 = new UserAction();
            //ReaderType test_rdtype = new ReaderType();
            //test_rdtype.rdType = 99;
            //test_rdtype.rdTypeName = "测试";
            //test1.actionType = "Update";
            //test1.actionDescription = "TEST_ONLY_1";
            //ActionList.Add(test1);
            //test2.actionSource = "ReaderType";
            //test2.actionModel = test_rdtype;
            //test2.actionType = "Add";
            //test2.actionDescription = "ReaderType TEST_ONLY_2";
            //ActionList.Add(test2);
            //test3.actionType = "Delete";
            //test3.actionDescription = "TEST_ONLY_3";
            //ActionList.Add(test3);
            //test4.actionType = "Update";
            //test4.actionDescription = "TEST_ONLY_4";
            //ActionList.Add(test4);
            //test5.actionType = "Update";
            //test5.actionDescription = "TEST_ONLY_5";
            //ActionList.Add(test5);
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
            if (canClose())
            {
                bookAdd.disposeAll();
                bookSearch.disposeAll();
                bookSearch_reader.disposeAll();
                readerSearch.disposeAll();

                ActionList.Clear();
                GlobalObject.logout();
                BorrowMax = -1;
                BorrowNotReturn = -1;
                _instance = null;
                this.Dispose();
            }
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!changePassword.isExist())
            {
                Form _changePassword = changePassword.CreateInstance();
                _changePassword.ShowDialog();
            }
        }

        private void 新书入库ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bookAdd.isExist())
            {
                Form _bookAdd = bookAdd.CreateInstance();
                _bookAdd.Show();
            }
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
            for (int i = 0; i < ActionList.Count; i++)
            {
                if (ActionList[i].actionSource == "Borrow" && ActionList[i].actionType == "Borrow")
                {
                    BorrowNotReturn--;
                }
                if (ActionList[i].actionSource == "Borrow" && ActionList[i].actionType == "Return")
                {
                    BorrowNotReturn++;
                }
                ActionList.Remove(ActionList[i]);
                i--; // ActionList.Count在上一步中减小了1，所以这里要让i不变！
            }
            toolStripStatusLabel.Text = $"[Info] 已放弃全部操作，就绪";
        }

        private void 放弃ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (index != -1)
            {
                if (ActionList[index].actionSource == "Borrow" && ActionList[index].actionType == "Borrow")
                {
                    BorrowNotReturn--;
                }
                if (ActionList[index].actionSource == "Borrow" && ActionList[index].actionType == "Return")
                {
                    BorrowNotReturn++;
                }
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
                        if (ActionList[index].actionSource == "Reader" && ActionList[index].actionType == "Password")
                        {
                            Reader tmp = (Reader)ActionList[index].actionModel;
                            GlobalObject.reader.rdPwd = tmp.rdPwd;
                        }
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
            for (int i = 0; i < ActionList.Count; i++)
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
                        if (ActionList[i].actionSource == "Reader" && ActionList[i].actionType == "Password")
                        {
                            Reader tmp = (Reader)ActionList[i].actionModel;
                            GlobalObject.reader.rdPwd = tmp.rdPwd;
                        }
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
                            if (ActionList[index].actionSource == "Reader" && ActionList[index].actionType == "Password")
                            {
                                Reader tmp = (Reader)ActionList[index].actionModel;
                                GlobalObject.reader.rdPwd = tmp.rdPwd;
                            }
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

        private void 图书维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bookSearch.isExist())
            {
                Form _bookSearch = bookSearch.CreateInstance();
                _bookSearch.Show();
            }
        }

        private void 借书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!bookSearch_reader.isExist())
            {
                Form _bookSearch_available = bookSearch_reader.CreateInstance();
                _bookSearch_available.Show();
            }
        }

        private void 续借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!borrowSearch.isExist())
            {
                borrowSearch.isReturnMode = false;
                Form _borrowSearch = borrowSearch.CreateInstance();
                _borrowSearch.Show();
            }
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!borrowSearch.isExist())
            {
                borrowSearch.isReturnMode = true;
                Form _borrowSearch = borrowSearch.CreateInstance();
                _borrowSearch.Show();
            }
        }

        private void 权限管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!readerSearch.isExist())
            {
                readerSearch.isRBACMode = true;
                Form _readerSearch = readerSearch.CreateInstance();
                _readerSearch.Show();
            }
        }
    }
}
