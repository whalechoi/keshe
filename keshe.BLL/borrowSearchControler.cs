using keshe.DAL;
using System.Data;

namespace keshe.BLL
{
    public sealed class borrowSearchControler
    {
        /// <summary>
        /// 此类为查找借阅界面的控制类，仅提供静态方法，禁止继承或实例化。
        /// </summary>
        private borrowSearchControler() { }
        public static DataTable GetDTby(string type, string content, int row, int number, int rdID)
        {
            return BorrowDAL.Searchby(type, content, row, number, rdID);
        }
    }
}
