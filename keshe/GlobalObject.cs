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
        /// 此信息类用于整个程序，禁止继承或实例化。
        /// </summary>
        private GlobalObject() { }
        public static Reader reader = null; // 用户
        public static readonly UserAction actionSource = new UserAction(); // 程序所有的用户行为由此复制
        public static readonly ReaderType readerTypeSource = new ReaderType(); // actionSource 的 actionModel 为 ReaderType 时
        public static readonly Reader readerSource = new Reader(); // actionSource 的 actionModel 为 Reader 时
        public static readonly Book bookSource = new Book(); // actionSource 的 actionModel 为 Book 时
        public static readonly Borrow borrowSource = new Borrow(); // actionSource 的 actionModel 为 Borrow 时
    }
}
