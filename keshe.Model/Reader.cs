using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keshe.Model
{
    /// <summary>
    /// 实体类 Reader
    /// </summary>
    [Serializable]
    public class Reader
    {
        #region 私有字段
        private Int32 _rdID = 0; /* 读者编号/借书证号 */
        private string _rdName = ""; /* 读者姓名 */
        private string _rdSex = "";  /* 性别：男/女 */
        private Int16 _rdType = 0;   /* 读者类别 */
        private string _rdDept = ""; /* 单位代码/单位名称 */
        private string _rdPhone = "";    /* 电话号码 */
        private string _rdEmail = "";    /* 电子邮箱 */
        private DateTime _rdDateReg = default(DateTime); /* 读者登记日期/办证日期 */
        private byte[] _rdPhoto = null;  /* 读者照片 */
        private string _rdStatus = "";   /* 证件状态，3个：有效、挂失、注销 */
        private Int32 _rdBorrowQty = 0;  /* 已借书数量（缺省值0） */
        private string _rdPwd = "";  /* 读者密码（初值123），32bit MD5加密存储 */
        private Int16 _rdAdminRoles = 0; /* 管理角色：0-读者、1-借书证管理、2-图书管理、4-借阅管理、8-系统管理，可组合 */
        #endregion

        #region 对私有字段的封装
        public int rdID { get => _rdID; set => _rdID = value; }
        public string rdName { get => _rdName; set => _rdName = value; }
        public string rdSex { get => _rdSex; set => _rdSex = value; }
        public short rdType { get => _rdType; set => _rdType = value; }
        public string rdDept { get => _rdDept; set => _rdDept = value; }
        public string rdPhone { get => _rdPhone; set => _rdPhone = value; }
        public string rdEmail { get => _rdEmail; set => _rdEmail = value; }
        public DateTime rdDateReg { get => _rdDateReg; set => _rdDateReg = value; }
        public byte[] rdPhoto { get => _rdPhoto; set => _rdPhoto = value; }
        public string rdStatus { get => _rdStatus; set => _rdStatus = value; }
        public int rdBorrowQty { get => _rdBorrowQty; set => _rdBorrowQty = value; }
        public string rdPwd { get => _rdPwd; set => _rdPwd = value; }
        public short rdAdminRoles { get => _rdAdminRoles; set => _rdAdminRoles = value; }
        #endregion

        public Reader() { }
        public Reader(Reader r)
        {
            this.rdID = r.rdID;
            this.rdName = r.rdName;
            this.rdSex = r.rdSex;
            this.rdType = r.rdType;
            this.rdDept = r.rdDept;
            this.rdPhone = r.rdPhone;
            this.rdEmail = r.rdEmail;
            this.rdDateReg = r.rdDateReg;
            this.rdPhoto = r.rdPhoto;
            this.rdStatus = r.rdStatus;
            this.rdBorrowQty = r.rdBorrowQty;
            this.rdPwd = r.rdPwd;
            this.rdAdminRoles = r.rdAdminRoles;
        }
    }
}
