using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;


namespace BusinessLogic
{
    public class UsuarioLogic : BusinessLogic
    {
        public UsuarioLogic()
        {
            UsuarioData = new Data.Database.UsuarioAdapter();
        }

        private Data.Database.UsuarioAdapter _UsuarioData;
        public Data.Database.UsuarioAdapter UsuarioData
        {
            set { _UsuarioData = value; }
            get { return _UsuarioData; }
        }

        public Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }

        public Usuario GetOne(string nombreUsuario, string clave)
        {
            try
            {
                return UsuarioData.GetOne(nombreUsuario, clave);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public List<Usuario> GetAll()
        {
            try
            {
                return UsuarioData.GetAll();               
            }
            catch (Exception)
            {               
                throw;
            }
        }

        public void Save(Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }
    }
}
