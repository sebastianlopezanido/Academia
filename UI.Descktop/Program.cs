using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessEntities;
using BusinessLogic;

namespace UI.Desktop
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            Login log = login;
            Application.Run(log);
            //Application.Run(new Usuarios());
        
            
        

    }
        public static Login login
        {
            get
            {
                if (_login == null)
                {
                    _login = new Login();
                }
                return _login;
            }
        }
        private static Login _login;
    }
}
