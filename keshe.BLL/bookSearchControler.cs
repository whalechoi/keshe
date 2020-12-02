using keshe.DAL;
using System.Data;

namespace keshe.BLL
{
    public sealed class bookSearchControler
    {
        /// <summary>
        /// 此类为查找图书界面的控制类，仅提供静态方法，禁止继承或实例化。
        /// </summary>
        private bookSearchControler() { }
        public static DataTable GetDTby(string type, string content, int row, int number)
        {
            return BookDAL.Searchby(type, content, row, number);
        }
    }
}
