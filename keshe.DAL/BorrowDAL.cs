using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using keshe.Model;
using System.Data;

namespace keshe.DAL
{
    public class BorrowDAL
    {
        private static string _strConnection = "server=localhost; uid=root; pwd=qweasdwsad; database=keshe";
        /// <summary>
        /// 添加借书记录
        /// </summary>
        #region Add
        public static int Add(Borrow borrow)
        {
            int rows = 0;
            string sql = "insert into TB_Borrow(BorrowID, rdID, bkID, ldContinueTimes, ldDateOut, ldDateRetPlan, ldDateRetAct, ldOverDay. ldOverMoney. ldPunishMoney, lsHasReturn, OperatorLend, OperatorRet)"
                + " values(?BorrowID, ?rdID, ?bkID, ?ldContinueTimes, ?ldDateOut, ?ldDateRetPlan, ?ldDateRetAct, ?ldOverDay. ?ldOverMoney. ?ldPunishMoney, ?lsHasReturn, ?OperatorLend, ?OperatorRet)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?BorrowID",borrow.BorrowID),
                new MySqlParameter("?rdID",borrow.rdID),
                new MySqlParameter("?bkID",borrow.bkID),
                new MySqlParameter("?ldContinueTimes",borrow.ldContinueTimes),
                new MySqlParameter("?ldDateOut",borrow.ldDateOut),
                new MySqlParameter("?ldDateRetPlan",borrow.ldDateRetPlan),
                new MySqlParameter("?ldDateRetAct",borrow.ldDateRetAct),
                new MySqlParameter("?ldOverDay",borrow.ldOverDay),
                new MySqlParameter("?ldOverMoney",borrow.ldOverMoney),
                new MySqlParameter("?ldPunishMoney",borrow.ldPunishMoney),
                new MySqlParameter("?lsHasReturn",borrow.lsHasReturn),
                new MySqlParameter("?OperatorLend",borrow.OperatorLend),
                new MySqlParameter("?OperatorRet",borrow.OperatorRet)
            };
            try
            {
                rows = MySqlHelper.ExecuteNonQuery(_strConnection, CommandType.Text, sql, parameters);
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return rows;
        }
        #endregion
        /// <summary>
        /// 删除借书记录
        /// </summary>
        #region Delete
        public static int Delete(Borrow borrow)
        {
            int rows = 0;
            string sql = "delete from TB_Borrow where BorrowID=?BorrowID";
            MySqlParameter[] parameters = { new MySqlParameter("?BorrowID", borrow.BorrowID) };
            try
            {
                rows = MySqlHelper.ExecuteNonQuery(_strConnection, CommandType.Text, sql, parameters);
            }
            catch (MySqlException ex)
            {

                throw new Exception(ex.Message);
            }
            return rows;
        }
        #endregion
        /// <summary>
        /// 更新借书记录信息
        /// </summary>
        #region Update
        public static int Update(Borrow borrow)
        {
            int rows = 0;
            string sql = "update TB_Borrow set "
                + "rdID=?rdID, "
                + "bkID=?bkID, "
                + "ldContinueTimes=?ldContinueTimes, "
                + "ldDateOut=?ldDateOut, "
                + "ldDateRetPlan=?ldDateRetPlan, "
                + "ldDateRetAct=?ldDateRetAct "
                + "ldOverDay=?ldOverDay "
                + "ldOverMoney=?ldOverMoney "
                + "ldPunishMoney=?ldPunishMoney "
                + "lsHasReturn=?lsHasReturn "
                + "OperatorLend=?OperatorLend "
                + "OperatorRet=?OperatorRet "
                + "where BorrowID=?BorrowID";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdID",borrow.rdID),
                new MySqlParameter("?bkID",borrow.bkID),
                new MySqlParameter("?ldContinueTimes",borrow.ldContinueTimes),
                new MySqlParameter("?ldDateOut",borrow.ldDateOut),
                new MySqlParameter("?ldDateRetPlan",borrow.ldDateRetPlan),
                new MySqlParameter("?ldDateRetAct",borrow.ldDateRetAct),
                new MySqlParameter("?ldOverDay",borrow.ldOverDay),
                new MySqlParameter("?ldOverMoney",borrow.ldOverMoney),
                new MySqlParameter("?ldPunishMoney",borrow.ldPunishMoney),
                new MySqlParameter("?lsHasReturn",borrow.lsHasReturn),
                new MySqlParameter("?OperatorLend",borrow.OperatorLend),
                new MySqlParameter("?OperatorRet",borrow.OperatorRet),
                new MySqlParameter("?BorrowID",borrow.BorrowID)
            };
            try
            {
                rows = MySqlHelper.ExecuteNonQuery(_strConnection, CommandType.Text, sql, parameters);
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message);
            }
            return rows;
        }
        #endregion
    }
}
