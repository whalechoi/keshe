using keshe.DAL;
using keshe.Model;
using System;

namespace keshe.BLL
{
    public sealed class loginControler
    {
        /// <summary>
        /// 此类为登录界面的控制类，仅提供静态方法，禁止继承或实例化。
        /// </summary>
        private loginControler() { }
        public static Int32 Login(Int32 rdID, string rdPwd)
        {
            Reader reader = ReaderDAL.GetObjectByID(rdID);
            if (reader == null || rdID == 0)
                return 1; // 1 -> 用户不存在；
            if (reader.rdPwd != rdPwd)
                return 2; // 2 -> 用户密码错误；
            return 0; // 0 -> 登录成功；
        }
        public static Reader GetReader(Int32 rdID)
        {
            return ReaderDAL.GetObjectByID(rdID);
        }
    }
}
