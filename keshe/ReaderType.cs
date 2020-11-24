using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace keshe
{
    class ReaderType
    {
        private Int32 rdType = 0;   /* 读者类别 */
        private string rdTypeName = ""; /* 读者类别名称 */
        private Int32 CanLendQty = 0;   /* 可借书数量 */
        private Int32 CanLendDay = 0;   /* 可借书天数 */
        private Int32 CanContinueTimes = 0; /* 可续借的次数 */
        private double PunishRate = 0;  /* 罚款率（元/天） */
        private Int32 DateValid = 0;    /* 证书有效期（年） */

        public int ks_rdType { get => rdType; set => rdType = value; }
        public string ks_rdTypeName { get => rdTypeName; set => rdTypeName = value; }
        public int ks_CanLendQty { get => CanLendQty; set => CanLendQty = value; }
        public int ks_CanLendDay { get => CanLendDay; set => CanLendDay = value; }
        public int ks_CanContinueTimes { get => CanContinueTimes; set => CanContinueTimes = value; }
        public double ks_PunishRate { get => PunishRate; set => PunishRate = value; }
        public int ks_DateValid { get => DateValid; set => DateValid = value; }
    }
}
