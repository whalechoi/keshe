using keshe.BLL;
using keshe.Model;
using System;
using System.Windows.Forms;

namespace keshe
{
    public partial class bookDetail : Form
    {
        private void readonlymode()
        {
            this.Text = "图书详细信息";
            textBox_bkID.Enabled = false;
            textBox_bkCode.Enabled = false;
            textBox_bkName.Enabled = false;
            textBox_bkAuthor.Enabled = false;
            textBox_bkPress.Enabled = false;
            dTP_bkDatePress.Enabled = false;
            textBox_bkISBN.Enabled = false;
            comboBox_bkCatalog.Enabled = false;
            comboBox_bkLanguage.Enabled = false;
            textBox_bkPages.Enabled = false;
            textBox_bkPrice.Enabled = false;
            dTP_bkDateIn.Enabled = false;
            textBox_bkBrief.Enabled = false;
            comboBox_Status.Enabled = false;
            button_bkCover.Enabled = false;
            button_bkCover.Visible = false;
            button_Change.Enabled = false;
            button_Change.Visible = false;
            button_Cancel.Text = "关闭";
        }
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
        private static bookDetail _instance = null; // 单例模式
        public static bookDetail CreateInstance()
        {
            if (_instance == null)
            {
                _instance = new bookDetail();
            }
            return _instance;
        }
        private bookDetail()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            _instance = null;
            this.Dispose();
        }

        private void bookDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            _instance = null;
            this.Dispose();
        }

        private void setBookInfo()
        {
            GlobalObject.bookSource.bkID = Int32.Parse(textBox_bkID.Text);
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
            GlobalObject.bookSource.bkCover = bookDetailControler.ImageToByte(pic_bkCover.Image);
            GlobalObject.bookSource.bkStatus = comboBox_Status.SelectedItem.ToString();
            GlobalObject.actionSource.actionDescription = $"修改图书信息 {GlobalObject.bookSource.bkCode}(bkID:{GlobalObject.bookSource.bkID}) ";
            GlobalObject.actionSource.actionSource = "Book";
            GlobalObject.actionSource.actionModel = GlobalObject.bookSource;
            GlobalObject.actionSource.actionType = "Update";
        }

        private void btnChange_Click(object sender, EventArgs e)
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
            if (textBox_bkBrief.Text == "")
            {
                MessageBox.Show("内容简介不能为空！", "提示：", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            setBookInfo();
            // 如果该图书还存在未提交的修改图书操作，报错！
            foreach (UserAction action in main.ActionList)
            {
                if (action.actionSource == "Book" && action.actionType == "Update")
                {
                    Book tmp = (Book)action.actionModel;
                    if (tmp.bkID == GlobalObject.bookSource.bkID)
                    {
                        MessageBox.Show("对当前图书的修改操作已存在于操作队列！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            main.addAction(GlobalObject.actionSource);
            this.Visible = false;
            this.DialogResult = DialogResult.OK;
            _instance = null;
            this.Dispose();
        }

        private void bookDetail_Load(object sender, EventArgs e)
        {
            Book temp = bookDetailControler.GetBookbybkID(bookSearch.bkID);
            if (temp == null)
            {
                temp = bookDetailControler.GetBookbybkID(bookSearch_reader.bkID);
                readonlymode();
            }
            if (temp == null)
            {
                MessageBox.Show("连接数据库失败，请检查您的网络连接！", "错误：", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _instance = null;
                this.Dispose();
                return;
            }

            textBox_bkID.Text = temp.bkID.ToString();
            textBox_bkCode.Text = temp.bkCode;
            textBox_bkName.Text = temp.bkName;
            textBox_bkAuthor.Text = temp.bkAuthor;
            textBox_bkPress.Text = temp.bkPress;
            dTP_bkDatePress.Value = temp.bkDatePress;
            textBox_bkISBN.Text = temp.bkISBN;
            comboBox_bkCatalog.SelectedIndex = Int32.Parse(temp.bkCatalog);
            comboBox_bkLanguage.SelectedIndex = temp.bkLanguage;
            textBox_bkPages.Text = temp.bkPages.ToString();
            textBox_bkPrice.Text = temp.bkPrice.ToString();
            dTP_bkDateIn.Value = temp.bkDateIn;
            textBox_bkBrief.Text = temp.bkBrief;
            pic_bkCover.Image = bookDetailControler.ByteToImage(temp.bkCover);
            comboBox_Status.SelectedItem = temp.bkStatus;

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
