using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using keshe.Model;

namespace keshe
{
    public sealed class GlobalObject
    {
        /// <summary>
        /// 此控制类用于整个程序，禁止继承或实例化。
        /// </summary>
        private GlobalObject() { }
        public static Reader reader = null; // 用户
        public static bool borrowCardAdmin = false;
        public static bool bookAdmin = false;
        public static bool borrowAdmin = false;
        public static bool systemAdmin = false;
        public static readonly UserAction actionSource = new UserAction(); // 程序所有的用户行为由此复制
        public static readonly ReaderType readerTypeSource = new ReaderType(); // actionSource 的 actionModel 为 ReaderType 时
        public static readonly Reader readerSource = new Reader(); // actionSource 的 actionModel 为 Reader 时
        public static readonly Book bookSource = new Book(); // actionSource 的 actionModel 为 Book 时
        public static readonly Borrow borrowSource = new Borrow(); // actionSource 的 actionModel 为 Borrow 时
        private static void adminCheck()
        {
            if (GlobalObject.reader == null)
            {
                return;
            }
            if ((GlobalObject.reader.rdAdminRoles & 0b1000) == 0b1000)
            {
                GlobalObject.borrowCardAdmin = true;
            }
            if ((GlobalObject.reader.rdAdminRoles & 0b0100) == 0b0100)
            {
                GlobalObject.bookAdmin = true;
            }
            if ((GlobalObject.reader.rdAdminRoles & 0b0010) == 0b0010)
            {
                GlobalObject.borrowAdmin = true;
            }
            if ((GlobalObject.reader.rdAdminRoles & 0b0001) == 0b0001)
            {
                GlobalObject.systemAdmin = true;
            }
        }
        public static void login(Reader x)
        {
            if (x == null)
            {
                return;
            }
            GlobalObject.reader = x;
            GlobalObject.adminCheck();
        }
        public static void logout()
        {
            GlobalObject.reader = null;
            GlobalObject.borrowCardAdmin = false;
            GlobalObject.bookAdmin = false;
            GlobalObject.borrowAdmin = false;
            GlobalObject.systemAdmin = false;
        }
    }
}
