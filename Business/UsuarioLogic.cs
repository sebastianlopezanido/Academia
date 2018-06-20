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

        public BusinessEntities.Usuario GetOne(int ID)
        {
            return UsuarioData.GetOne(ID);
        }
        public List<Usuario> GetAll()
        {
            return UsuarioData.GetAll();
        }

        public void Save(BusinessEntities.Usuario usuario)
        {
            UsuarioData.Save(usuario);
        }

        public void Delete(int ID)
        {
            UsuarioData.Delete(ID);
        }
    }
}
