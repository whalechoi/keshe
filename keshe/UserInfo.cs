using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using keshe.Model;

namespace keshe
{
    public sealed class UserInfo
    {
        /// <summary>
        /// 此信息类用于整个程序，禁止继承或实例化。
        /// </summary>
        private UserInfo() { }
        public static Reader reader = null;
    }
}
