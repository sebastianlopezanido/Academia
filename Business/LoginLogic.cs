using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class LoginLogic
    {
        public LoginLogic()
        {
            
        }
        public BusinessEntities.Usuario ValidarDatos(string nombreUsuario, string clave)
        {
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                BusinessEntities.Usuario usr = ul.GetOne(nombreUsuario, clave);
                if (usr.NombreUsuario != null)
                {
                    return usr;
                }

                Exception ErrorLogin = new Exception("Usuario y/o contraseña incorrectos");
                throw ErrorLogin;
            }
            catch (Exception Ex)
            {
                throw;
            }            
        }
    }
}
