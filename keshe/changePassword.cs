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
        public changePassword()
        {
            InitializeComponent();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
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
            this.DialogResult = DialogResult.OK;
            this.Dispose();
        }
    }
}
