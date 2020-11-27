using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace keshe
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            while (true)
            {
                if(UserInfo.reader == null)
                {
                    Form login = new login();
                    login.ShowDialog();
                }
                else
                {
                    Form main = new main();
                    main.ShowDialog();
                }
            }
        }
    }
}
