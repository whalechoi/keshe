using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keshe
{
    class Reader
    {
        private Int32 rdID = 0; /* 读者编号/借书证号 */
        private string rdName = ""; /* 读者姓名 */
        private string rdSex = "";  /* 性别：男/女 */
        private Int16 rdType = 0;   /* 读者类别 */
        private string rdDept = ""; /* 单位代码/单位名称 */
        private string rdPhone = "";    /* 电话号码 */
        private string rdEmail = "";    /* 电子邮箱 */
        private DateTime rdDateReg = default(DateTime); /* 读者登记日期/办证日期 */
        private byte[] rdPhoto = null;  /* 读者照片 */
        private string rdStatus = "";   /* 证件状态，3个：有效、挂失、注销 */
        private Int32 rdBorrowQty = 0;  /* 已借书数量（缺省值0） */
        private string rdPwd = "";  /* 读者密码（初值123），32bit MD5加密存储 */
        private Int16 rdAdminRoles = 0; /* 管理角色：0-读者、1-借书证管理、2-图书管理、4-借阅管理、8-系统管理，可组合 */

        public int ks_rdID { get => rdID; set => rdID = value; }
        public string ks_rdName { get => rdName; set => rdName = value; }
        public string ks_rdSex { get => rdSex; set => rdSex = value; }
        public short ks_rdType { get => rdType; set => rdType = value; }
        public string ks_rdDept { get => rdDept; set => rdDept = value; }
        public string ks_rdPhone { get => rdPhone; set => rdPhone = value; }
        public string ks_rdEmail { get => rdEmail; set => rdEmail = value; }
        public DateTime ks_rdDateReg { get => rdDateReg; set => rdDateReg = value; }
        public byte[] ks_rdPhoto { get => rdPhoto; set => rdPhoto = value; }
        public string ks_rdStatus { get => rdStatus; set => rdStatus = value; }
        public int ks_rdBorrowQty { get => rdBorrowQty; set => rdBorrowQty = value; }
        public string ks_rdPwd { get => rdPwd; set => rdPwd = value; }
        public short ks_rdAdminRoles { get => rdAdminRoles; set => rdAdminRoles = value; }
    }
}
