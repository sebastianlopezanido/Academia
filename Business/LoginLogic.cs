using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public class LoginLogic
    {
        public LoginLogic()
        {
            
        }

        public Usuario ValidarDatos(string nombreUsuario, string clave)
        {
            UsuarioLogic ul = new UsuarioLogic();
            try
            {
                Usuario usr = ul.GetOne(nombreUsuario, clave);
                return usr;                
            }
            catch (Exception Ex)
            {
                throw Ex;
            }            
        }
    }
}
