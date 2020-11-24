using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keshe.Model
{
    /// <summary>
    /// 实体类 Borrow
    /// </summary>
    [Serializable]
    public class Borrow
    {
        #region 私有字段
        private decimal _BorrowID = 0m;  /* 借书顺序号 */
        private Int32 _rdID = 0; /* 读者序号 */
        private Int32 _bkID = 0; /* 图书序号 */
        private Int32 _ldContinueTimes = 0;  /* 续借次数（第一次借时，记为0） */
        private DateTime _ldDateOut = default(DateTime); /* 借书日期 */
        private DateTime _ldDateRetPlan = default(DateTime); /* 应还日期 */
        private DateTime _ldDateRetAct = default(DateTime);  /* 实际还书日期 */
        private Int32 _ldOverDay = 0;    /* 超期天数 */
        private decimal _ldOverMoney = 0m;   /* 超期金额（应罚款金额） */
        private decimal _ldPunishMoney = 0m; /* 罚款金额 */
        private Boolean _lsHasReturn = false;    /* 是否已经还书，缺省为0-未还 */
        private string _OperatorLend = "";   /* 借书操作员 */
        private string _OperatorRet = "";    /* 还书操作员 */
        #endregion

        #region 对私有字段的封装
        public decimal BorrowID { get => _BorrowID; set => _BorrowID = value; }
        public int rdID { get => _rdID; set => _rdID = value; }
        public int bkID { get => _bkID; set => _bkID = value; }
        public int ldContinueTimes { get => _ldContinueTimes; set => _ldContinueTimes = value; }
        public DateTime ldDateOut { get => _ldDateOut; set => _ldDateOut = value; }
        public DateTime ldDateRetPlan { get => _ldDateRetPlan; set => _ldDateRetPlan = value; }
        public DateTime ldDateRetAct { get => _ldDateRetAct; set => _ldDateRetAct = value; }
        public int ldOverDay { get => _ldOverDay; set => _ldOverDay = value; }
        public decimal ldOverMoney { get => _ldOverMoney; set => _ldOverMoney = value; }
        public decimal ldPunishMoney { get => _ldPunishMoney; set => _ldPunishMoney = value; }
        public bool lsHasReturn { get => _lsHasReturn; set => _lsHasReturn = value; }
        public string OperatorLend { get => _OperatorLend; set => _OperatorLend = value; }
        public string OperatorRet { get => _OperatorRet; set => _OperatorRet = value; }
        #endregion

        public Borrow() { }
        public Borrow(Borrow r)
        {
            this.BorrowID = r.BorrowID;
            this.rdID = r.rdID;
            this.bkID = r.bkID;
            this.ldContinueTimes = r.ldContinueTimes;
            this.ldDateOut = r.ldDateOut;
            this.ldDateRetPlan = r.ldDateRetPlan;
            this.ldDateRetAct = r.ldDateRetAct;
            this.ldOverDay = r.ldOverDay;
            this.ldOverMoney = r.ldOverMoney;
            this.ldPunishMoney = r.ldPunishMoney;
            this.lsHasReturn = r.lsHasReturn;
            this.OperatorLend = r.OperatorLend;
            this.OperatorRet = r.OperatorRet;
        }
    }
}
