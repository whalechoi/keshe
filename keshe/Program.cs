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
                if(GlobalObject.reader == null)
                {
                    Form _login = login.CreateInstance();
                    _login.ShowDialog();
                }
                else
                {
                    Form _main = main.CreateInstance();
                    _main.ShowDialog();
                }
            }
        }
    }
}
