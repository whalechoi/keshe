using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keshe
{
    class Book
    {
        private Int32 bkID = 0; /* 图书序号 */
        private string bkCode = ""; /* 图书编号或条码号（前文中的书号） */
        private string bkName = ""; /* 书名 */
        private string bkAuthor = "";   /* 作者 */
        private string bkPress = "";    /* 出版社 */
        private DateTime bkDatePress = default(DateTime);   /* 出版日期 */
        private string bkISBN = ""; /* ISBN书号 */
        private string bkCatalog = "";  /* 分类号（如：TP316-21/123） */
        private Int16 bkLanguage = 0;   /* 语言：0-中文，1-英文，2-日文，3-俄文，4-德文，5-法文 */
        private Int16 bkPages = 0;  /* 页数 */
        private decimal bkPrice = 0m;   /* 价格 */
        private DateTime bkDateIn = default(DateTime);  /* 入馆日期 */
        private string bkBrief = "";    /* 内容简介 */
        private byte[] bkCover = null;  /* 图书封面照片 */
        private string bkStatus = "";   /* 图书状态：在馆、借出、遗失、变卖、销毁 */

        public int ks_bkID { get => bkID; set => bkID = value; }
        public string ks_bkCode { get => bkCode; set => bkCode = value; }
        public string ks_bkName { get => bkName; set => bkName = value; }
        public string ks_bkAuthor { get => bkAuthor; set => bkAuthor = value; }
        public string ks_bkPress { get => bkPress; set => bkPress = value; }
        public DateTime ks_bkDatePress { get => bkDatePress; set => bkDatePress = value; }
        public string ks_bkISBN { get => bkISBN; set => bkISBN = value; }
        public string ks_bkCatalog { get => bkCatalog; set => bkCatalog = value; }
        public short ks_bkLanguage { get => bkLanguage; set => bkLanguage = value; }
        public short BkPages { get => bkPages; set => bkPages = value; }
        public decimal ks_bkPrice { get => bkPrice; set => bkPrice = value; }
        public DateTime ks_bkDateIn { get => bkDateIn; set => bkDateIn = value; }
        public string ks_bkBrief { get => bkBrief; set => bkBrief = value; }
        public byte[] ks_bkCover { get => bkCover; set => bkCover = value; }
        public string ks_bkStatus { get => bkStatus; set => bkStatus = value; }
    }
}
