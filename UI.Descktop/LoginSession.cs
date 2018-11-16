using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace UI.Desktop
{
    public static class LoginSession
    {
        private static int _ID;
        public static int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private static Usuario.TiposUsuario _Tipo;
        public static Usuario.TiposUsuario Tipo
        {
            get { return _Tipo; }
            set { _Tipo = value; }
        }
    }
}
