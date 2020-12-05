using keshe.Model;
using MySql.Data.MySqlClient;
using System;
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
                new MySqlParameter("?bkCode",MySqlDbType.VarChar,20),
                new MySqlParameter("?bkName",MySqlDbType.VarChar,50),
                new MySqlParameter("?bkAuthor",MySqlDbType.VarChar,30),
                new MySqlParameter("?bkPress",MySqlDbType.VarChar,50),
                new MySqlParameter("?bkDatePress",MySqlDbType.DateTime),
                new MySqlParameter("?bkISBN",MySqlDbType.VarChar,15),
                new MySqlParameter("?bkCatalog",MySqlDbType.VarChar,30),
                new MySqlParameter("?bkLanguage",MySqlDbType.Int16),
                new MySqlParameter("?bkPages",MySqlDbType.Int32),
                new MySqlParameter("?bkPrice",MySqlDbType.NewDecimal),
                new MySqlParameter("?bkDateIn",MySqlDbType.DateTime),
                new MySqlParameter("?bkBrief",MySqlDbType.Text),
                new MySqlParameter("?bkCover",MySqlDbType.MediumBlob),
                new MySqlParameter("?bkStatus",MySqlDbType.VarChar,2)
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
                new MySqlParameter("?bkCode",MySqlDbType.VarChar,20),
                new MySqlParameter("?bkName",MySqlDbType.VarChar,50),
                new MySqlParameter("?bkAuthor",MySqlDbType.VarChar,30),
                new MySqlParameter("?bkPress",MySqlDbType.VarChar,50),
                new MySqlParameter("?bkDatePress",MySqlDbType.DateTime),
                new MySqlParameter("?bkISBN",MySqlDbType.VarChar,15),
                new MySqlParameter("?bkCatalog",MySqlDbType.VarChar,30),
                new MySqlParameter("?bkLanguage",MySqlDbType.Int16),
                new MySqlParameter("?bkPages",MySqlDbType.Int32),
                new MySqlParameter("?bkPrice",MySqlDbType.NewDecimal),
                new MySqlParameter("?bkDateIn",MySqlDbType.DateTime),
                new MySqlParameter("?bkBrief",MySqlDbType.Text),
                new MySqlParameter("?bkCover",MySqlDbType.MediumBlob),
                new MySqlParameter("?bkStatus",MySqlDbType.VarChar,2),
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
        /// <summary>
        /// 获取最后一本图书
        /// </summary>
        #region GetLastObject
        public static Book GetLastObject()
        {
            string sql = "select * from TB_Book order by bkID DESC limit 1";
            DataTable dt = null;
            dt = MySqlHelper.GetData(_strConnection, CommandType.Text, sql);
            DataRow dr = null;
            if (dt == null || dt.Rows.Count == 0)
                return null;
            else
            {
                dr = dt.Rows[0];
                return MySqlHelper.DataRowToT<Book>(dr);
            }
        }
        #endregion
        /// <summary>
        /// 查找
        /// </summary>
        #region Searchby
        public static DataTable Searchby(string type, string content, int row, int number)
        {
            string sql = "select bkID as 图书序号, bkCode as 图书编号, bkName as 图书名称, bkAuthor as 图书作者, bkPress as 出版社名, bkISBN as 标准ISBN, bkDatePress as 出版日期, bkStatus as 图书状态  from TB_Book";
            MySqlParameter parameter = null;
            switch (type)
            {
                case "_ALL":
                    sql = sql + $" limit {row}, {number}";
                    return MySqlHelper.GetData(_strConnection, CommandType.Text, sql);
                case "bkID":
                    sql = sql + $" where bkID=?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.Int32);
                    parameter.Value = Int32.Parse(content);
                    break;
                case "bkCode":
                    sql = sql + $" where bkCode like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 20);
                    parameter.Value = $"{content}%";
                    break;
                case "bkName":
                    sql = sql + $" where bkName like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 50);
                    parameter.Value = $"%{content}%";
                    break;
                case "bkAuthor":
                    sql = sql + $" where bkAuthor like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 30);
                    parameter.Value = $"%{content}%";
                    break;
                case "bkPress":
                    sql = sql + $" where bkPress like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 50);
                    parameter.Value = $"%{content}%";
                    break;
                case "bkISBN":
                    sql = sql + $" where bkISBN like ?content limit {row}, {number}";
                    parameter = new MySqlParameter("?content", MySqlDbType.VarChar, 15);
                    parameter.Value = $"%{content}%";
                    break;
                default:
                    throw (new Exception("Error search type!"));
            }
            MySqlParameter[] parameters = { parameter };
            return MySqlHelper.GetData(_strConnection, CommandType.Text, sql, parameters);
        }
        #endregion
    }
}
