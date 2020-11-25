using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using keshe.Model;
using System.Data;

namespace keshe.DAL
{
    class ReaderDAL
    {
        private static string _strConnection = "server=localhost; uid=root; pwd=qweasdwsad; database=keshe";
        /// <summary>
        /// 添加读者
        /// </summary>
        #region Add
        public static int Add(Reader reader)
        {
            int rows = 0;
            string sql = "insert into TB_Reader(rdID, rdName, rdSex, rdType, rdDept, rdPhone, rdEmail, rdDateReg. rdPhoto. rdStatus, rdBorrowQty, rdPwd, rdAdminRoles)"
                + " values(?rdID, ?rdName, ?rdSex, ?rdType, ?rdDept, ?rdPhone, ?rdEmail, ?rdDateReg. ?rdPhoto. ?rdStatus, ?rdBorrowQty, ?rdPwd, ?rdAdminRoles)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdID",reader.rdID),
                new MySqlParameter("?rdName",reader.rdName),
                new MySqlParameter("?rdSex",reader.rdSex),
                new MySqlParameter("?rdType",reader.rdType),
                new MySqlParameter("?rdDept",reader.rdDept),
                new MySqlParameter("?rdPhone",reader.rdPhone),
                new MySqlParameter("?rdEmail",reader.rdEmail),
                new MySqlParameter("?rdDateReg",reader.rdDateReg),
                new MySqlParameter("?rdPhoto",reader.rdPhoto),
                new MySqlParameter("?rdStatus",reader.rdStatus),
                new MySqlParameter("?rdBorrowQty",reader.rdBorrowQty),
                new MySqlParameter("?rdPwd",reader.rdPwd),
                new MySqlParameter("?rdAdminRoles",reader.rdAdminRoles)
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
        /// 删除读者
        /// </summary>
        #region Delete
        public static int Delete(Reader reader)
        {
            int rows = 0;
            string sql = "delete from TB_Reader where rdID=?rdID";
            MySqlParameter[] parameters = { new MySqlParameter("?rdID", reader.rdID) };
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
        /// 更新读者信息
        /// </summary>
        #region Update
        public static int Update(Reader reader)
        {
            int rows = 0;
            string sql = "update TB_Reader set "
                + "rdName=?rdName, "
                + "rdSex=?rdSex, "
                + "rdType=?rdType, "
                + "rdDept=?rdDept, "
                + "rdPhone=?rdPhone, "
                + "rdEmail=?rdEmail "
                + "rdDateReg=?rdDateReg "
                + "rdPhoto=?rdPhoto "
                + "rdStatus=?rdStatus "
                + "rdBorrowQty=?rdBorrowQty "
                + "rdPwd=?rdPwd "
                + "rdAdminRoles=?rdAdminRoles "
                + "where rdID=?rdID";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdName",reader.rdName),
                new MySqlParameter("?rdSex",reader.rdSex),
                new MySqlParameter("?rdType",reader.rdType),
                new MySqlParameter("?rdDept",reader.rdDept),
                new MySqlParameter("?rdPhone",reader.rdPhone),
                new MySqlParameter("?rdEmail",reader.rdEmail),
                new MySqlParameter("?rdDateReg",reader.rdDateReg),
                new MySqlParameter("?rdPhoto",reader.rdPhoto),
                new MySqlParameter("?rdStatus",reader.rdStatus),
                new MySqlParameter("?rdBorrowQty",reader.rdBorrowQty),
                new MySqlParameter("?rdPwd",reader.rdPwd),
                new MySqlParameter("?rdAdminRoles",reader.rdAdminRoles),
                new MySqlParameter("?rdID",reader.rdID)
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
        /// 由读者ID(rdID)得到读者类型，返回DataRow
        /// </summary>
        #region GetDRByID
        public static DataRow GetDRByID(Int32 rdID)
        {
            string sql = "select * from TB_Reader where rdID=?rdID";
            MySqlParameter[] parameters = { new MySqlParameter("?rdID", rdID) };
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
        /// 由读者ID(rdID)得到该读者对象
        /// </summary>
        #region GetObjectByID
        public static Reader GetObjectByID(int rdID)
        {
            DataRow dr = GetDRByID(rdID);
            return MySqlHelper.DataRowToT<Reader>(dr);
        }
        #endregion
    }
}
