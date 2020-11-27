using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keshe
{
    public partial class main : Form
    {
        private static readonly List<Action> actions = new List<Action>();
        private static readonly BindingList<Action> BList = new BindingList<Action>(actions);
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                /// <summary>
                /// 若用户点了关闭按钮，则执行下面代码
                /// 调用Close()方法不会触发
                /// </summary>
                UserInfo.reader = null;
                System.Environment.Exit(0);
            }
            base.WndProc(ref msg);
        }

        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            this.Text =$"keshe 图书管理系统 v{Assembly.GetExecutingAssembly().GetName().Version.ToString()} 当前身份：{UserInfo.reader.rdName} 祝您生活愉快！";
            actions.Add(new Action());
            dgv_Actions.DataSource = BList;
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox about = new AboutBox();
            about.ShowDialog();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInfo.reader = null;
            this.Close();
        }

        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
