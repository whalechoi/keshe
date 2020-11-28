using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keshe.Model
{
    /// <summary>
    /// 实体类 Book
    /// </summary>
    [Serializable]
    public class Book
    {
        #region 私有字段
        private Int32 _bkID = 0; /* 图书序号 */
        private string _bkCode = ""; /* 图书编号或条码号（前文中的书号） */
        private string _bkName = ""; /* 书名 */
        private string _bkAuthor = "";   /* 作者 */
        private string _bkPress = "";    /* 出版社 */
        private DateTime _bkDatePress = default(DateTime);   /* 出版日期 */
        private string _bkISBN = ""; /* ISBN书号 */
        private string _bkCatalog = "";  /* 分类号（如：TP316-21/123） */
        private Int16 _bkLanguage = 0;   /* 语言：0-中文，1-英文，2-日文，3-俄文，4-德文，5-法文 */
        private Int32 _bkPages = 0;  /* 页数 */
        private decimal _bkPrice = 0m;   /* 价格 */
        private DateTime _bkDateIn = default(DateTime);  /* 入馆日期 */
        private string _bkBrief = "";    /* 内容简介 */
        private byte[] _bkCover = null;  /* 图书封面照片 */
        private string _bkStatus = "";   /* 图书状态：在馆、借出、遗失、变卖、销毁 */
        #endregion

        #region 对私有字段的封装
        public int bkID { get => _bkID; set => _bkID = value; }
        public string bkCode { get => _bkCode; set => _bkCode = value; }
        public string bkName { get => _bkName; set => _bkName = value; }
        public string bkAuthor { get => _bkAuthor; set => _bkAuthor = value; }
        public string bkPress { get => _bkPress; set => _bkPress = value; }
        public DateTime bkDatePress { get => _bkDatePress; set => _bkDatePress = value; }
        public string bkISBN { get => _bkISBN; set => _bkISBN = value; }
        public string bkCatalog { get => _bkCatalog; set => _bkCatalog = value; }
        public short bkLanguage { get => _bkLanguage; set => _bkLanguage = value; }
        public int bkPages { get => _bkPages; set => _bkPages = value; }
        public decimal bkPrice { get => _bkPrice; set => _bkPrice = value; }
        public DateTime bkDateIn { get => _bkDateIn; set => _bkDateIn = value; }
        public string bkBrief { get => _bkBrief; set => _bkBrief = value; }
        public byte[] bkCover { get => _bkCover; set => _bkCover = value; }
        public string bkStatus { get => _bkStatus; set => _bkStatus = value; }
        #endregion

        public Book() { }
    }
}
