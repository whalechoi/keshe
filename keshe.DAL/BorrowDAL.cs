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
            string sql = "insert into TB_Borrow(BorrowID, rdID, bkID, ldContinueTimes, ldDateOut, ldDateRetPlan, ldDateRetAct, ldOverDay, ldOverMoney, ldPunishMoney, lsHasReturn, OperatorLend, OperatorRet)"
                + " values(?BorrowID, ?rdID, ?bkID, ?ldContinueTimes, ?ldDateOut, ?ldDateRetPlan, ?ldDateRetAct, ?ldOverDay, ?ldOverMoney, ?ldPunishMoney, ?lsHasReturn, ?OperatorLend, ?OperatorRet)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?BorrowID",MySqlDbType.NewDecimal),
                new MySqlParameter("?rdID",MySqlDbType.Int32),
                new MySqlParameter("?bkID",MySqlDbType.Int32),
                new MySqlParameter("?ldContinueTimes",MySqlDbType.Int32),
                new MySqlParameter("?ldDateOut",MySqlDbType.DateTime),
                new MySqlParameter("?ldDateRetPlan",MySqlDbType.DateTime),
                new MySqlParameter("?ldDateRetAct",MySqlDbType.DateTime),
                new MySqlParameter("?ldOverDay",MySqlDbType.Int32),
                new MySqlParameter("?ldOverMoney",MySqlDbType.NewDecimal),
                new MySqlParameter("?ldPunishMoney",MySqlDbType.NewDecimal),
                new MySqlParameter("?lsHasReturn",MySqlDbType.Bit),
                new MySqlParameter("?OperatorLend",MySqlDbType.VarChar),
                new MySqlParameter("?OperatorRet",MySqlDbType.VarChar)
            };
            parameters[0].Value = borrow.BorrowID;
            parameters[1].Value = borrow.rdID;
            parameters[2].Value = borrow.bkID;
            parameters[3].Value = borrow.ldContinueTimes;
            parameters[4].Value = borrow.ldDateOut;
            parameters[5].Value = borrow.ldDateRetPlan;
            parameters[6].Value = borrow.ldDateRetAct;
            parameters[7].Value = borrow.ldOverDay;
            parameters[8].Value = borrow.ldOverMoney;
            parameters[9].Value = borrow.ldPunishMoney;
            parameters[10].Value = borrow.lsHasReturn;
            parameters[11].Value = borrow.OperatorLend;
            parameters[12].Value = borrow.OperatorRet;
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
            MySqlParameter[] parameters = { new MySqlParameter("?BorrowID", MySqlDbType.NewDecimal) };
            parameters[0].Value = borrow.BorrowID;
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
                + "ldDateRetAct=?ldDateRetAct, "
                + "ldOverDay=?ldOverDay, "
                + "ldOverMoney=?ldOverMoney, "
                + "ldPunishMoney=?ldPunishMoney, "
                + "lsHasReturn=?lsHasReturn, "
                + "OperatorLend=?OperatorLend, "
                + "OperatorRet=?OperatorRet "
                + "where BorrowID=?BorrowID";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdID",MySqlDbType.Int32),
                new MySqlParameter("?bkID",MySqlDbType.Int32),
                new MySqlParameter("?ldContinueTimes",MySqlDbType.Int32),
                new MySqlParameter("?ldDateOut",MySqlDbType.DateTime),
                new MySqlParameter("?ldDateRetPlan",MySqlDbType.DateTime),
                new MySqlParameter("?ldDateRetAct",MySqlDbType.DateTime),
                new MySqlParameter("?ldOverDay",MySqlDbType.Int32),
                new MySqlParameter("?ldOverMoney",MySqlDbType.NewDecimal),
                new MySqlParameter("?ldPunishMoney",MySqlDbType.NewDecimal),
                new MySqlParameter("?lsHasReturn",MySqlDbType.Bit),
                new MySqlParameter("?OperatorLend",MySqlDbType.VarChar),
                new MySqlParameter("?OperatorRet",MySqlDbType.VarChar),
                new MySqlParameter("?BorrowID",MySqlDbType.NewDecimal)
            };
            parameters[0].Value = borrow.rdID;
            parameters[1].Value = borrow.bkID;
            parameters[2].Value = borrow.ldContinueTimes;
            parameters[3].Value = borrow.ldDateOut;
            parameters[4].Value = borrow.ldDateRetPlan;
            parameters[5].Value = borrow.ldDateRetAct;
            parameters[6].Value = borrow.ldOverDay;
            parameters[7].Value = borrow.ldOverMoney;
            parameters[8].Value = borrow.ldPunishMoney;
            parameters[9].Value = borrow.lsHasReturn;
            parameters[10].Value = borrow.OperatorLend;
            parameters[11].Value = borrow.OperatorRet;
            parameters[12].Value = borrow.BorrowID;
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
