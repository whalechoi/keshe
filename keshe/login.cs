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

namespace keshe
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            Int32 loginStatus = -1;
            if (textBox_rdID.Text == "")
            {
                MessageBox.Show("用户编号不能为空！", "警告：");
                return;
            }
            if (textBox_rdPwd.Text == "")
            {
                MessageBox.Show("用户密码不能为空！", "警告：");
                return;
            }
            loginStatus = loginControler.Login(Int32.Parse(textBox_rdID.Text), textBox_rdPwd.Text);
            switch (loginStatus)
            {
                case 1:
                    MessageBox.Show("查无此用户！", "提示：");
                    break;
                case 2:
                    MessageBox.Show("密码错误！", "提示：");
                    break;
                case 0:
                    UserInfo.reader = loginControler.GetReader(Int32.Parse(textBox_rdID.Text));
                    MessageBox.Show($"登录成功，{UserInfo.reader.rdName}，欢迎使用keshe图书管理系统!", "提示：");
                    this.Close();
                    break;
                default:
                    MessageBox.Show("未知错误！", "提示：");
                    break;
            }
        }

        private void label_welcome_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/whalechoi/keshe");
        }
    }
}
