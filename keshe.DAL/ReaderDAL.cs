using keshe.Model;
using MySql.Data.MySqlClient;
using System;
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
                new MySqlParameter("?rdName",MySqlDbType.VarChar,20),
                new MySqlParameter("?rdSex",MySqlDbType.VarChar,2),
                new MySqlParameter("?rdType",MySqlDbType.Int16),
                new MySqlParameter("?rdDept",MySqlDbType.VarChar,20),
                new MySqlParameter("?rdPhone",MySqlDbType.VarChar,25),
                new MySqlParameter("?rdEmail",MySqlDbType.VarChar,25),
                new MySqlParameter("?rdDateReg",MySqlDbType.DateTime),
                new MySqlParameter("?rdPhoto",MySqlDbType.MediumBlob),
                new MySqlParameter("?rdStatus",MySqlDbType.VarChar,2),
                new MySqlParameter("?rdBorrowQty",MySqlDbType.Int32),
                new MySqlParameter("?rdPwd",MySqlDbType.VarChar,32),
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
                new MySqlParameter("?rdName",MySqlDbType.VarChar,20),
                new MySqlParameter("?rdSex",MySqlDbType.VarChar,2),
                new MySqlParameter("?rdType",MySqlDbType.Int16),
                new MySqlParameter("?rdDept",MySqlDbType.VarChar,20),
                new MySqlParameter("?rdPhone",MySqlDbType.VarChar,25),
                new MySqlParameter("?rdEmail",MySqlDbType.VarChar,25),
                new MySqlParameter("?rdDateReg",MySqlDbType.DateTime),
                new MySqlParameter("?rdPhoto",MySqlDbType.MediumBlob),
                new MySqlParameter("?rdStatus",MySqlDbType.VarChar,2),
                new MySqlParameter("?rdBorrowQty",MySqlDbType.Int32),
                new MySqlParameter("?rdPwd",MySqlDbType.VarChar,32),
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
        /// <summary>
        /// 查找
        /// </summary>
        #region Searchby
        public static DataTable Searchby(string type, string content, int row, int number)
        {
            string sql = $"select rdID as 读者ID, rdName as 读者姓名, rdSex as 性别, rdPhone as 电话号码, rdStatus as 证件状态, rdAdminRoles as 职权 from TB_Reader";
            MySqlParameter parameter = null;
            switch (type)
            {
                case "_ALL":
                    sql = sql + $" limit {row}, {number}";
                    return MySqlHelper.GetData(_strConnection, CommandType.Text, sql);
                case "rdID":
                    sql = sql + $" where rdID=?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.Int32);
                    parameter.Value = Int32.Parse(content);
                    break;
                case "rdName":
                    sql = sql + $" where rdName like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 20);
                    parameter.Value = $"%{content}%";
                    break;
                case "rdSex":
                    sql = sql + $" where rdSex=?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 2);
                    parameter.Value = content;
                    break;
                case "rdDept":
                    sql = sql + $" where rdDept like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 20);
                    parameter.Value = $"%{content}%";
                    break;
                case "rdPhone":
                    sql = sql + $" where rdPhone like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 25);
                    parameter.Value = $"{content}%";
                    break;
                case "rdEmail":
                    sql = sql + $" where rdEmail like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 25);
                    parameter.Value = $"{content}%";
                    break;
                case "rdStatus":
                    sql = sql + $" where rdStatus=?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 2);
                    parameter.Value = content;
                    break;
                default:
                    throw (new Exception("Error search type!"));
            }
            MySqlParameter[] parameters = { parameter };
            return MySqlHelper.GetData(_strConnection, CommandType.Text, sql, parameters);
        }
        #endregion
        /// <summary>
        /// 修改读者密码
        /// </summary>
        #region Password
        public static int Password(Reader reader)
        {
            int rows = 0;
            string sql = "update TB_Reader set "
                + "rdPwd=?rdPwd "
                + "where rdID=?rdID";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdPwd",MySqlDbType.VarChar,32),
                new MySqlParameter("?rdID",MySqlDbType.Int32)
            };
            parameters[0].Value = reader.rdPwd;
            parameters[1].Value = reader.rdID;
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
        /// 修改读者权限
        /// </summary>
        #region Permission
        public static int Permission(Reader reader)
        {
            int rows = 0;
            string sql = "update TB_Reader set "
                + "rdAdminRoles=?rdAdminRoles "
                + "where rdID=?rdID";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?rdAdminRoles",MySqlDbType.Int16),
                new MySqlParameter("?rdID",MySqlDbType.Int32)
            };
            parameters[0].Value = reader.rdAdminRoles;
            parameters[1].Value = reader.rdID;
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
