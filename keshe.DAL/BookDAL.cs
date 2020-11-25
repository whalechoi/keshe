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
    class BookDAL
    {
        private static string _strConnection = "server=localhost; uid=root; pwd=qweasdwsad; database=keshe";
        /// <summary>
        /// 添加图书
        /// </summary>
        #region Add
        public static int Add(Book book)
        {
            int rows = 0;
            string sql = "insert into TB_Book(bkID, bkCode, bkName, bkAuthor, bkPress, bkDatePress, bkISBN, bkCatalog. bkLanguage. bkPages, bkPrice, bkDateIn, bkBrief, bkCover, bkStatus)"
                + " values(?bkID, ?bkCode, ?bkName, ?bkAuthor, ?bkPress, ?bkDatePress, ?bkISBN, ?bkCatalog. ?bkLanguage. ?bkPages, ?bkPrice, ?bkDateIn, ?bkBrief, ?bkCover, ?bkStatus)";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?bkID",book.bkID),
                new MySqlParameter("?bkCode",book.bkCode),
                new MySqlParameter("?bkName",book.bkName),
                new MySqlParameter("?bkAuthor",book.bkAuthor),
                new MySqlParameter("?bkPress",book.bkPress),
                new MySqlParameter("?bkDatePress",book.bkDatePress),
                new MySqlParameter("?bkISBN",book.bkISBN),
                new MySqlParameter("?bkCatalog",book.bkCatalog),
                new MySqlParameter("?bkLanguage",book.bkLanguage),
                new MySqlParameter("?bkPages",book.bkPages),
                new MySqlParameter("?bkPrice",book.bkPrice),
                new MySqlParameter("?bkDateIn",book.bkDateIn),
                new MySqlParameter("?bkBrief",book.bkBrief),
                new MySqlParameter("?bkCover",book.bkCover),
                new MySqlParameter("?bkStatus",book.bkStatus)
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
        /// 删除图书
        /// </summary>
        #region Delete
        public static int Delete(Book book)
        {
            int rows = 0;
            string sql = "delete from TB_Book where bkID=?bkID";
            MySqlParameter[] parameters = { new MySqlParameter("?bkID", book.bkID) };
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
                + "bkISBN=?bkISBN "
                + "bkCatalog=?bkCatalog "
                + "bkLanguage=?bkLanguage "
                + "bkPages=?bkPages "
                + "bkPrice=?bkPrice "
                + "bkDateIn=?bkDateIn "
                + "bkBrief=?bkBrief "
                + "bkCover=?bkCover "
                + "bkStatus=?bkStatus "
                + "where bkID=?bkID";
            MySqlParameter[] parameters =
            {
                new MySqlParameter("?bkCode",book.bkCode),
                new MySqlParameter("?bkName",book.bkName),
                new MySqlParameter("?bkAuthor",book.bkAuthor),
                new MySqlParameter("?bkPress",book.bkPress),
                new MySqlParameter("?bkDatePress",book.bkDatePress),
                new MySqlParameter("?bkISBN",book.bkISBN),
                new MySqlParameter("?bkCatalog",book.bkCatalog),
                new MySqlParameter("?bkLanguage",book.bkLanguage),
                new MySqlParameter("?bkPages",book.bkPages),
                new MySqlParameter("?bkPrice",book.bkPrice),
                new MySqlParameter("?bkDateIn",book.bkDateIn),
                new MySqlParameter("?bkBrief",book.bkBrief),
                new MySqlParameter("?bkCover",book.bkCover),
                new MySqlParameter("?bkStatus",book.bkStatus),
                new MySqlParameter("?bkID",book.bkID)
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
