using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keshe
{
    class Borrow
    {
        private decimal BorrowID = 0m;  /* 借书顺序号 */
        private Int32 rdID = 0; /* 读者序号 */
        private Int32 bkID = 0; /* 图书序号 */
        private Int32 ldContinueTimes = 0;  /* 续借次数（第一次借时，记为0） */
        private DateTime ldDateOut = default(DateTime); /* 借书日期 */
        private DateTime ldDateRetPlan = default(DateTime); /* 应还日期 */
        private DateTime ldDateRetAct = default(DateTime);  /* 实际还书日期 */
        private Int32 ldOverDay = 0;    /* 超期天数 */
        private decimal ldOverMoney = 0m;   /* 超期金额（应罚款金额） */
        private decimal ldPunishMoney = 0m; /* 罚款金额 */
        private Boolean lsHasReturn = false;    /* 是否已经还书，缺省为0-未还 */
        private string OperatorLend = "";   /* 借书操作员 */
        private string OperatorRet = "";    /* 还书操作员 */

        public decimal ks_BorrowID { get => BorrowID; set => BorrowID = value; }
        public int ks_rdID { get => rdID; set => rdID = value; }
        public int ks_bkID { get => bkID; set => bkID = value; }
        public int ks_ldContinueTimes { get => ldContinueTimes; set => ldContinueTimes = value; }
        public DateTime ks_ldDateOut { get => ldDateOut; set => ldDateOut = value; }
        public DateTime ks_ldDateRetPlan { get => ldDateRetPlan; set => ldDateRetPlan = value; }
        public DateTime ks_ldDateRetAct { get => ldDateRetAct; set => ldDateRetAct = value; }
        public int ks_ldOverDay { get => ldOverDay; set => ldOverDay = value; }
        public decimal ks_ldOverMoney { get => ldOverMoney; set => ldOverMoney = value; }
        public decimal ks_ldPunishMoney { get => ldPunishMoney; set => ldPunishMoney = value; }
        public bool ks_lsHasReturn { get => lsHasReturn; set => lsHasReturn = value; }
        public string ks_OperatorLend { get => OperatorLend; set => OperatorLend = value; }
        public string ks_OperatorRet { get => OperatorRet; set => OperatorRet = value; }
    }
}
