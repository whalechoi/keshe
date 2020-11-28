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
    public class BookDAL
    {
        private static string _strConnection = "server=localhost; uid=root; pwd=qweasdwsad; database=keshe";
        /// <summary>
        /// 添加图书
        /// </summary>
        #region Add
        public static int Add(Book book)
        {
            int rows = 0;
            string sql = "insert into TB_Book(bkID, bkCode, bkName, bkAuthor, bkPress, bkDatePress, bkISBN, bkCatalog, bkLanguage, bkPages, bkPrice, bkDateIn, bkBrief, bkCover, bkStatus)"
                + " values(?bkID, ?bkCode, ?bkName, ?bkAuthor, ?bkPress, ?bkDatePress, ?bkISBN, ?bkCatalog, ?bkLanguage, ?bkPages, ?bkPrice, ?bkDateIn, ?bkBrief, ?bkCover, ?bkStatus)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?bkID",MySqlDbType.Int32),
                new MySqlParameter("?bkCode",MySqlDbType.VarChar),
                new MySqlParameter("?bkName",MySqlDbType.VarChar),
                new MySqlParameter("?bkAuthor",MySqlDbType.VarChar),
                new MySqlParameter("?bkPress",MySqlDbType.VarChar),
                new MySqlParameter("?bkDatePress",MySqlDbType.DateTime),
                new MySqlParameter("?bkISBN",MySqlDbType.VarChar),
                new MySqlParameter("?bkCatalog",MySqlDbType.VarChar),
                new MySqlParameter("?bkLanguage",MySqlDbType.Int16),
                new MySqlParameter("?bkPages",MySqlDbType.Int32),
                new MySqlParameter("?bkPrice",MySqlDbType.NewDecimal),
                new MySqlParameter("?bkDateIn",MySqlDbType.DateTime),
                new MySqlParameter("?bkBrief",MySqlDbType.Text),
                new MySqlParameter("?bkCover",MySqlDbType.MediumBlob),
                new MySqlParameter("?bkStatus",MySqlDbType.VarChar)
            };
            parameters[0].Value = book.bkID;
            parameters[1].Value = book.bkCode;
            parameters[2].Value = book.bkName;
            parameters[3].Value = book.bkAuthor;
            parameters[4].Value = book.bkPress;
            parameters[5].Value = book.bkDatePress;
            parameters[6].Value = book.bkISBN;
            parameters[7].Value = book.bkCatalog;
            parameters[8].Value = book.bkLanguage;
            parameters[9].Value = book.bkPages;
            parameters[10].Value = book.bkPrice;
            parameters[11].Value = book.bkDateIn;
            parameters[12].Value = book.bkBrief;
            parameters[13].Value = book.bkCover;
            parameters[14].Value = book.bkStatus;
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
        /// 删除图书
        /// </summary>
        #region Delete
        public static int Delete(Book book)
        {
            int rows = 0;
            string sql = "delete from TB_Book where bkID=?bkID";
            MySqlParameter[] parameters = { new MySqlParameter("?bkID", MySqlDbType.Int32) };
            parameters[0].Value = book.bkID;
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
        /// 更新图书信息
        /// </summary>
        #region Update
        public static int Update(Book book)
        {
            int rows = 0;
            string sql = "update TB_Book set "
                + "bkCode=?bkCode, "
                + "bkName=?bkName, "
                + "bkAuthor=?bkAuthor, "
                + "bkPress=?bkPress, "
                + "bkDatePress=?bkDatePress, "
                + "bkISBN=?bkISBN, "
                + "bkCatalog=?bkCatalog, "
                + "bkLanguage=?bkLanguage, "
                + "bkPages=?bkPages, "
                + "bkPrice=?bkPrice, "
                + "bkDateIn=?bkDateIn, "
                + "bkBrief=?bkBrief, "
                + "bkCover=?bkCover, "
                + "bkStatus=?bkStatus "
                + "where bkID=?bkID";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?bkCode",MySqlDbType.VarChar),
                new MySqlParameter("?bkName",MySqlDbType.VarChar),
                new MySqlParameter("?bkAuthor",MySqlDbType.VarChar),
                new MySqlParameter("?bkPress",MySqlDbType.VarChar),
                new MySqlParameter("?bkDatePress",MySqlDbType.DateTime),
                new MySqlParameter("?bkISBN",MySqlDbType.VarChar),
                new MySqlParameter("?bkCatalog",MySqlDbType.VarChar),
                new MySqlParameter("?bkLanguage",MySqlDbType.Int16),
                new MySqlParameter("?bkPages",MySqlDbType.Int32),
                new MySqlParameter("?bkPrice",MySqlDbType.NewDecimal),
                new MySqlParameter("?bkDateIn",MySqlDbType.DateTime),
                new MySqlParameter("?bkBrief",MySqlDbType.Text),
                new MySqlParameter("?bkCover",MySqlDbType.MediumBlob),
                new MySqlParameter("?bkStatus",MySqlDbType.VarChar),
                new MySqlParameter("?bkID",MySqlDbType.Int32)
            };
            parameters[0].Value = book.bkCode;
            parameters[1].Value = book.bkName;
            parameters[2].Value = book.bkAuthor;
            parameters[3].Value = book.bkPress;
            parameters[4].Value = book.bkDatePress;
            parameters[5].Value = book.bkISBN;
            parameters[6].Value = book.bkCatalog;
            parameters[7].Value = book.bkLanguage;
            parameters[8].Value = book.bkPages;
            parameters[9].Value = book.bkPrice;
            parameters[10].Value = book.bkDateIn;
            parameters[11].Value = book.bkBrief;
            parameters[12].Value = book.bkCover;
            parameters[13].Value = book.bkStatus;
            parameters[14].Value = book.bkID;
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
        /// 由图书序号(bkID)得到图书类型，返回DataRow
        /// </summary>
        #region GetDRByID
        public static DataRow GetDRByID(Int32 bkID)
        {
            string sql = "select * from TB_Book where bkID=?bkID";
            MySqlParameter[] parameters = { new MySqlParameter("?bkID", bkID) };
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
        /// 由图书ID(rdID)得到该图书对象
        /// </summary>
        #region GetObjectByID
        public static Book GetObjectByID(int bkID)
        {
            DataRow dr = GetDRByID(bkID);
            return MySqlHelper.DataRowToT<Book>(dr);
        }
        #endregion
    }
}
