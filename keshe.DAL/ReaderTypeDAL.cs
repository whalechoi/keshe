using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using keshe.Model;

namespace keshe.DAL
{
    class ReaderTypeDAL
    {
        private static string _strConnection = "server=localhost; uid=root; pwd=qweasdwsad; database=keshe";
        /// <summary>
        /// 添加读者类别
        /// </summary>
        #region Add
        public static int Add(ReaderType readertype)
        {
            int rows = 0;
            string sql = "insert into TB_ReaderType(rdType, rdTypeName, CanLendQty, CanLendDay, CanContinueTimes, PunishRate, DateValid)"
                + " values(?rdType, ?rdTypeName, ?CanLendQty, ?CanLendDay, ?CanContinueTimes, ?PunishRate, ?DateValid)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdType",readertype.rdType),
                new MySqlParameter("?rdTypeName",readertype.rdTypeName),
                new MySqlParameter("?CanLendQty",readertype.CanLendQty),
                new MySqlParameter("?CanLendDay",readertype.CanLendDay),
                new MySqlParameter("?CanContinueTimes",readertype.CanContinueTimes),
                new MySqlParameter("?PunishRate",readertype.PunishRate),
                new MySqlParameter("?DateValid",readertype.DateValid)
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
        /// 删除读者类别
        /// </summary>
        #region Delete
        public static int Delete(ReaderType readertype)
        {
            int rows = 0;
            string sql = "delete from TB_ReaderType where rdType=?rdType";
            MySqlParameter[] parameters = { new MySqlParameter("?rdType", readertype.rdType) };
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
        /// 更新读者类别信息
        /// </summary>
        #region Update
        public static int Update(ReaderType readertype)
        {
            int rows = 0;
            string sql = "update TB_ReaderType set "
                + "rdTypeName=?rdTypeName, "
                + "CanLendQty=?CanLendQty, "
                + "CanLendDay=?CanLendDay, "
                + "CanContinueTimes=?CanContinueTimes, "
                + "PunishRate=?PunishRate, "
                + "DateValid=?DateValid "
                + "where rdType=?rdType";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdTypeName",readertype.rdTypeName),
                new MySqlParameter("?CanLendQty",readertype.CanLendQty),
                new MySqlParameter("?CanLendDay",readertype.CanLendDay),
                new MySqlParameter("?CanContinueTimes",readertype.CanContinueTimes),
                new MySqlParameter("?PunishRate",readertype.PunishRate),
                new MySqlParameter("?DateValid",readertype.DateValid),
                new MySqlParameter("?rdType",readertype.rdType)
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
        /// 由读者类型ID(rdType)得到读者信息类型，返回DataRow
        /// </summary>
        #region GetDRByID
        public static DataRow GetDRByID(Int16 rdType)
        {
            string sql = "select * from TB_ReaderType where rdType=?rdType";
            MySqlParameter[] parameters = { new MySqlParameter("?rdType", rdType) };
            DataTable dt = null;
            dt = MySqlHelper.GetData(_strConnection, CommandType.Text, sql, parameters);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count == 0)
                return dr;
            else
            {
                dr = dt.Rows[0];
                return dr;
            }
        }
        #endregion
        /// <summary>
        /// 由读者类型ID(rdType)得到该读者信息对象
        /// </summary>
        #region GetObjectByID
        public static ReaderType GetObjectByID(Int16 rdType)
        {
            DataRow dr = GetDRByID(rdType);
            return MySqlHelper.DataRowToT<ReaderType>(dr);
        }
        #endregion
    }
}
