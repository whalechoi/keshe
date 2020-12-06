using keshe.BLL;
using keshe.Model;
using System;
using System.Windows.Forms;

namespace keshe
{
    public partial class changePermission : Form
    {
        private Int16 permission = 0;
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
            }
        }
        private static changePermission _instance = null; // 单例模式
        public static changePermission CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new changePermission();
            }
            return _instance;
        }
        private changePermission()
        {
            InitializeComponent();
        }
        private Int16 GetPermission()
        {
            string permission = "0";
            if (checkBox_borrowCardAdmin.Checked)
            {
                permission = permission + "1";
            }
            else
            {
                permission = permission + "0";
            }
            if (checkBox_bookAdmin.Checked)
            {
                permission = permission + "1";
            }
            else
            {
                permission = permission + "0";
            }
            if (checkBox_borrowAdmin.Checked)
            {
                permission = permission + "1";
            }
            else
            {
                permission = permission + "0";
            }
            if (checkBox_systemAdmin.Checked)
            {
                permission = permission + "1";
            }
            else
            {
                permission = permission + "0";
            }
            return Convert.ToInt16(permission, 2);
        }

        private void button_OK_Click(object sender, EventArgs e)
        {
            if (permission == GetPermission())
            {
                MessageBox.Show("该用户的权限没有发生变化！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            GlobalObject.readerSource.rdID = readerSearch.rdID;
            GlobalObject.readerSource.rdAdminRoles = GetPermission();

            GlobalObject.actionSource.actionSource = "Reader";
            GlobalObject.actionSource.actionModel = GlobalObject.readerSource;
            GlobalObject.actionSource.actionType = "Permission";
            GlobalObject.actionSource.actionDescription = $"修改读者 {GlobalObject.readerSource.rdID} 的权限。";
            main.addAction(GlobalObject.actionSource);
            this.Visible = false;
            this.DialogResult = DialogResult.OK;
            _instance = null;
            this.Dispose();
        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.DialogResult = DialogResult.Cancel;
            _instance = null;
            this.Dispose();
        }

        private void changePermission_Load(object sender, EventArgs e)
        {
            Reader target = loginControler.GetReader(readerSearch.rdID);
            if (target == null)
            {
                return;
            }
            permission = target.rdAdminRoles;
            if ((permission & 0b1000) == 0b1000)
            {
                checkBox_borrowCardAdmin.Checked = true;
            }
            if ((permission & 0b0100) == 0b0100)
            {
                checkBox_bookAdmin.Checked = true;
            }
            if ((permission & 0b0010) == 0b0010)
            {
                checkBox_borrowAdmin.Checked = true;
            }
            if ((permission & 0b0001) == 0b0001)
            {
                checkBox_systemAdmin.Checked = true;
            }
        }
    }
}
