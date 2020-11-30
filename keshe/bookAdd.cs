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
using keshe.Model;

namespace keshe
{
    public partial class bookAdd : Form
    {
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
        private static bookAdd _instance = null; // 单例模式
        public static bookAdd CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new bookAdd();
            }
            return _instance;
        }
        private bookAdd()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _instance = null;
            this.Dispose();
        }

        private void bookAdd_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
            this.Dispose();
        }

        private void txtBBookID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只能输入数字！ (char)8表示退格键
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void setBookInfo()
        {
            GlobalObject.bookSource.bkCode = textBox_bkCode.Text;
            GlobalObject.bookSource.bkName = textBox_bkName.Text;
            GlobalObject.bookSource.bkAuthor = textBox_bkAuthor.Text;
            GlobalObject.bookSource.bkPress = textBox_bkPress.Text;
            GlobalObject.bookSource.bkDatePress = dTP_bkDatePress.Value;
            GlobalObject.bookSource.bkISBN = textBox_bkISBN.Text;
            GlobalObject.bookSource.bkCatalog = comboBox_bkCatalog.SelectedIndex.ToString(); // 这里进行了简化处理，实际并非如此简单。
            GlobalObject.bookSource.bkLanguage = Int16.Parse(comboBox_bkLanguage.SelectedIndex.ToString());
            GlobalObject.bookSource.bkPages = Int32.Parse(textBox_bkPages.Text);
            GlobalObject.bookSource.bkPrice = decimal.Parse(textBox_bkPrice.Text);
            GlobalObject.bookSource.bkDateIn = dTP_bkDateIn.Value;
            GlobalObject.bookSource.bkBrief = textBox_bkBrief.Text;
            GlobalObject.bookSource.bkCover = bookAddControler.ImageToByte(pic_bkCover.Image);
            GlobalObject.bookSource.bkStatus = "在馆";

            GlobalObject.actionSource.actionSource = "Book";
            GlobalObject.actionSource.actionModel = GlobalObject.bookSource;
            GlobalObject.actionSource.actionType = "Add";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox_bkCode.Text == "")
            {
                MessageBox.Show("图书编号不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox_bkName.Text == "")
            {
                MessageBox.Show("图书名称不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox_bkAuthor.Text == "")
            {
                MessageBox.Show("图书作者不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox_bkPress.Text == "")
            {
                MessageBox.Show("出版社名不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            if (textBox_bkISBN.Text == "")
            {
                MessageBox.Show("ISBN不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            try
            {
                if (Int32.Parse(textBox_bkPages.Text) <= 0)
                {
                    MessageBox.Show("图书页数必须大于0！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的图书页数！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (decimal.Parse(textBox_bkPrice.Text) <= 0)
                {
                    MessageBox.Show("图书价格必须大于0！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的价格！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (Int32.Parse(textBox_quantity.Text) <= 0)
                {
                    MessageBox.Show("图书本书必须大于0！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的图书本书！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (textBox_bkBrief.Text == "")
            {
                MessageBox.Show("内容简介不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            setBookInfo();
            // 如果还存在未提交的添加图书操作，则bkID从未提交操作中获取！
            int index = -1;
            foreach (UserAction action in main.ActionList)
            {
                if (action.actionSource == "Book" && action.actionType == "Add")
                {
                    Book tmp = (Book)action.actionModel;
                    index = tmp.bkID;
                }
            }
            for (int i=0;i< Int32.Parse(textBox_quantity.Text); i++)
            {
                if (index != -1)
                {
                    textBox_bkID.Text = (index + 1).ToString();
                }
                GlobalObject.bookSource.bkID = Int32.Parse(textBox_bkID.Text) + i;
                GlobalObject.actionSource.actionDescription = $"添加图书 {GlobalObject.bookSource.bkCode}(bkID:{GlobalObject.bookSource.bkID}) 。";
                main.addAction(GlobalObject.actionSource);
            }
            this.Visible = false;
            MessageBox.Show("操作已挂起！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            _instance = null;
            this.Dispose();
        }

        private void bookAdd_Load(object sender, EventArgs e)
        {
            int bkID = bookAddControler.GetLastBkID();
            if (bkID == -1)
            {
                MessageBox.Show("连接数据库失败，请检查您的网络连接！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _instance = null;
                this.Dispose();
            }
            textBox_bkID.Text = (bkID + 1).ToString();
            comboBox_bkCatalog.SelectedIndex = 0;
            comboBox_bkLanguage.SelectedIndex = 0;
        }

        private void textBox_quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只能输入数字！ (char)8表示退格键
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox_bkPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只能输入数字！ (char)8表示退格键 (char)46表示小数点
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8 && e.KeyChar != (char)46)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void textBox_bkPages_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只能输入数字！ (char)8表示退格键
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }

        private void button_bkCover_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = ".";
            file.Filter = "支持的图片格式 (*.jpg, *.jpeg, *.png, *.bmp)|*.jpg;*.jpeg;*.png;*.bmp|JPEG 格式|*.jpg;*.jpeg|PNG 格式|*.png|BITMAP 格式|*.bmp";
            file.ShowDialog();
            if (file.FileName != string.Empty)
            {
                try
                {
                    this.pic_bkCover.Load(file.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
