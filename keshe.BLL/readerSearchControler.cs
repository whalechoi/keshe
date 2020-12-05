using keshe.DAL;
using System.Data;

namespace keshe.BLL
{
    public sealed class readerSearchControler
    {
        /// <summary>
        /// 此类为查找读者界面的控制类，仅提供静态方法，禁止继承或实例化。
        /// </summary>
        private readerSearchControler() { }
        public static DataTable GetDTby(string type, string content, int row, int number)
        {
            return ReaderDAL.Searchby(type, content, row, number);
        }
    }
}
