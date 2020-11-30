using keshe.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using keshe.BLL;
using NETCore.Encrypt;

namespace keshe
{
    public partial class login : Form
    {
        private static login _instance = null; // 单例模式
        public static login CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new login();
            }
            return _instance;
        }
        private login()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            _instance = null;
            this.Dispose();
            System.Environment.Exit(0);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            Int32 loginStatus = -1;
            if (textBox_rdID.Text == "")
            {
                MessageBox.Show("用户编号不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox_rdPwd.Text == "")
            {
                MessageBox.Show("用户密码不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            try
            {
                loginStatus = loginControler.Login(Int32.Parse(textBox_rdID.Text), EncryptProvider.Md5(textBox_rdPwd.Text));
            }
            catch (Exception) { } // 捕捉到异常什么也不做
            switch (loginStatus)
            {
                case 1:
                    MessageBox.Show("查无此用户！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
                case 2:
                    MessageBox.Show("密码错误！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 0:
                    this.Visible = false;
                    GlobalObject.login(loginControler.GetReader(Int32.Parse(textBox_rdID.Text)));
                    if (GlobalObject.reader.rdStatus == "挂失")
                    {
                        MessageBox.Show("您当前的借书证已被挂失，欲了解详细情况请与借书证管理员联系！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GlobalObject.logout();
                        this.Visible = true;
                        break;
                    }
                    if (GlobalObject.reader.rdStatus == "注销")
                    {
                        MessageBox.Show("您当前的借书证已被注销，您不能登入此图书管理系统！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        GlobalObject.logout();
                        this.Visible = true;
                        break;
                    }
                    MessageBox.Show($"登录成功，{GlobalObject.reader.rdName}，欢迎使用 keshe 图书管理系统!", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    _instance = null;
                    this.Dispose();
                    break;
                case -1:
                    MessageBox.Show("登录失败，请检查您的网络连接！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    MessageBox.Show("登录失败，未知错误！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    break;
            }
        }

        private void textBox_rdID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 用户编号只能输入数字！ (char)8表示退格键
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            } 
        }

        private void label_welcome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/whalechoi/keshe");
        }
    }
}
