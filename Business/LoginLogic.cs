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
                Exception ExcepcionManejada = new Exception("Usuario y/o contraseña incorrecto/s", Ex);
                throw ExcepcionManejada;                
            }

            
        }
    }
}
