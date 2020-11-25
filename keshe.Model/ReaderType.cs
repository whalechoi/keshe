using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keshe.Model
{
    /// <summary>
    /// 实体类 ReaderType
    /// </summary>
    [Serializable]
    public class ReaderType
    {
        #region 私有字段
        private Int16 _rdType = 0;   /* 读者类别 */
        private string _rdTypeName = ""; /* 读者类别名称 */
        private Int32 _CanLendQty = 0;   /* 可借书数量 */
        private Int32 _CanLendDay = 0;   /* 可借书天数 */
        private Int32 _CanContinueTimes = 0; /* 可续借的次数 */
        private Single _PunishRate = 0;  /* 罚款率（元/天） */
        private Int16 _DateValid = 0;    /* 证书有效期（年） */
        #endregion

        #region 对私有字段的封装
        public short rdType { get => _rdType; set => _rdType = value; }
        public string rdTypeName { get => _rdTypeName; set => _rdTypeName = value; }
        public int CanLendQty { get => _CanLendQty; set => _CanLendQty = value; }
        public int CanLendDay { get => _CanLendDay; set => _CanLendDay = value; }
        public int CanContinueTimes { get => _CanContinueTimes; set => _CanContinueTimes = value; }
        public float PunishRate { get => _PunishRate; set => _PunishRate = value; }
        public short DateValid { get => _DateValid; set => _DateValid = value; }
        #endregion

        public ReaderType() { }
        public ReaderType(ReaderType r)
        {
            this.rdType = r.rdType;
            this.rdTypeName = r.rdTypeName;
            this.CanLendQty = r.CanLendQty;
            this.CanLendDay = r.CanLendDay;
            this.CanContinueTimes = r.CanContinueTimes;
            this.PunishRate = r.PunishRate;
            this.DateValid = r.DateValid;
        }
    }
}
