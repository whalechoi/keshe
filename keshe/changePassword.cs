using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NETCore.Encrypt;

namespace keshe
{
    public partial class changePassword : Form
    {
        private static changePassword _instance = null; // 单例模式
        public static changePassword CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new changePassword();
            }
            return _instance;
        }
        private changePassword()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            _instance = null;
            this.Dispose();
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (textBox_old_pwd.Text == "")
            {
                MessageBox.Show("原密码不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox_new_pwd.Text == "")
            {
                MessageBox.Show("新密码不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox_new_pwd.Text != textBox_new_pwd2.Text)
            {
                MessageBox.Show("两次输入的密码不一致！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (GlobalObject.reader.rdPwd != EncryptProvider.Md5(textBox_old_pwd.Text))
            {
                MessageBox.Show("原密码错误！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox_new_pwd.Text == textBox_old_pwd.Text)
            {
                MessageBox.Show("新密码不能与旧密码一样！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            GlobalObject.readerSource.rdID = GlobalObject.reader.rdID;
            GlobalObject.readerSource.rdName = GlobalObject.reader.rdName;
            GlobalObject.readerSource.rdSex = GlobalObject.reader.rdSex;
            GlobalObject.readerSource.rdType = GlobalObject.reader.rdType;
            GlobalObject.readerSource.rdDept = GlobalObject.reader.rdDept;
            GlobalObject.readerSource.rdPhone = GlobalObject.reader.rdPhone;
            GlobalObject.readerSource.rdEmail = GlobalObject.reader.rdEmail;
            GlobalObject.readerSource.rdDateReg = GlobalObject.reader.rdDateReg;
            GlobalObject.readerSource.rdPhoto = GlobalObject.reader.rdPhoto;
            GlobalObject.readerSource.rdStatus = GlobalObject.reader.rdStatus;
            GlobalObject.readerSource.rdBorrowQty = GlobalObject.reader.rdBorrowQty;
            GlobalObject.readerSource.rdPwd = EncryptProvider.Md5(textBox_new_pwd.Text);
            GlobalObject.readerSource.rdAdminRoles = GlobalObject.reader.rdAdminRoles;

            GlobalObject.actionSource.actionSource = "Reader";
            GlobalObject.actionSource.actionModel = GlobalObject.readerSource;
            GlobalObject.actionSource.actionType = "Update";
            GlobalObject.actionSource.actionDescription = $"修改用户 {GlobalObject.readerSource.rdName}(rdID:{GlobalObject.readerSource.rdID}) 的密码。";

            main.addAction(GlobalObject.actionSource);
            MessageBox.Show("操作已挂起！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _instance = null;
            this.Dispose();
        }
    }
}
