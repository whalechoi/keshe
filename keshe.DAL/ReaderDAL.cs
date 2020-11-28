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
    public class ReaderDAL
    {
        private static string _strConnection = "server=localhost; uid=root; pwd=qweasdwsad; database=keshe";
        /// <summary>
        /// 添加读者
        /// </summary>
        #region Add
        public static int Add(Reader reader)
        {
            int rows = 0;
            string sql = "insert into TB_Reader(rdID, rdName, rdSex, rdType, rdDept, rdPhone, rdEmail, rdDateReg, rdPhoto, rdStatus, rdBorrowQty, rdPwd, rdAdminRoles)"
                + " values(?rdID, ?rdName, ?rdSex, ?rdType, ?rdDept, ?rdPhone, ?rdEmail, ?rdDateReg, ?rdPhoto, ?rdStatus, ?rdBorrowQty, ?rdPwd, ?rdAdminRoles)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdID",MySqlDbType.Int32),
                new MySqlParameter("?rdName",MySqlDbType.VarChar),
                new MySqlParameter("?rdSex",MySqlDbType.VarChar),
                new MySqlParameter("?rdType",MySqlDbType.Int16),
                new MySqlParameter("?rdDept",MySqlDbType.VarChar),
                new MySqlParameter("?rdPhone",MySqlDbType.VarChar),
                new MySqlParameter("?rdEmail",MySqlDbType.VarChar),
                new MySqlParameter("?rdDateReg",MySqlDbType.DateTime),
                new MySqlParameter("?rdPhoto",MySqlDbType.MediumBlob),
                new MySqlParameter("?rdStatus",MySqlDbType.VarChar),
                new MySqlParameter("?rdBorrowQty",MySqlDbType.Int32),
                new MySqlParameter("?rdPwd",MySqlDbType.VarChar),
                new MySqlParameter("?rdAdminRoles",MySqlDbType.Int16)
            };
            parameters[0].Value = reader.rdID;
            parameters[1].Value = reader.rdName;
            parameters[2].Value = reader.rdSex;
            parameters[3].Value = reader.rdType;
            parameters[4].Value = reader.rdDept;
            parameters[5].Value = reader.rdPhone;
            parameters[6].Value = reader.rdEmail;
            parameters[7].Value = reader.rdDateReg;
            parameters[8].Value = reader.rdPhoto;
            parameters[9].Value = reader.rdStatus;
            parameters[10].Value = reader.rdBorrowQty;
            parameters[11].Value = reader.rdPwd;
            parameters[12].Value = reader.rdAdminRoles;
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
            MySqlParameter[] parameters = { new MySqlParameter("?rdID", MySqlDbType.Int32) };
            parameters[0].Value = reader.rdID;
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
                + "rdEmail=?rdEmail, "
                + "rdDateReg=?rdDateReg, "
                + "rdPhoto=?rdPhoto, "
                + "rdStatus=?rdStatus, "
                + "rdBorrowQty=?rdBorrowQty, "
                + "rdPwd=?rdPwd, "
                + "rdAdminRoles=?rdAdminRoles "
                + "where rdID=?rdID";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdName",MySqlDbType.VarChar),
                new MySqlParameter("?rdSex",MySqlDbType.VarChar),
                new MySqlParameter("?rdType",MySqlDbType.Int16),
                new MySqlParameter("?rdDept",MySqlDbType.VarChar),
                new MySqlParameter("?rdPhone",MySqlDbType.VarChar),
                new MySqlParameter("?rdEmail",MySqlDbType.VarChar),
                new MySqlParameter("?rdDateReg",MySqlDbType.DateTime),
                new MySqlParameter("?rdPhoto",MySqlDbType.MediumBlob),
                new MySqlParameter("?rdStatus",MySqlDbType.VarChar),
                new MySqlParameter("?rdBorrowQty",MySqlDbType.Int32),
                new MySqlParameter("?rdPwd",MySqlDbType.VarChar),
                new MySqlParameter("?rdAdminRoles",MySqlDbType.Int16),
                new MySqlParameter("?rdID",MySqlDbType.Int32)
            };
            parameters[0].Value = reader.rdName;
            parameters[1].Value = reader.rdSex;
            parameters[2].Value = reader.rdType;
            parameters[3].Value = reader.rdDept;
            parameters[4].Value = reader.rdPhone;
            parameters[5].Value = reader.rdEmail;
            parameters[6].Value = reader.rdDateReg;
            parameters[7].Value = reader.rdPhoto;
            parameters[8].Value = reader.rdStatus;
            parameters[9].Value = reader.rdBorrowQty;
            parameters[10].Value = reader.rdPwd;
            parameters[11].Value = reader.rdAdminRoles;
            parameters[12].Value = reader.rdID;
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
        public static Reader GetObjectByID(Int32 rdID)
        {
            DataRow dr = GetDRByID(rdID);
            return MySqlHelper.DataRowToT<Reader>(dr);
        }
        #endregion
    }
}
