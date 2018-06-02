using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Usuario : BusinessEntity //heredit from BusinessEntity
    {
        private string _NombreUsuario;
        public string NombreUsuario
        {
            get { return _NombreUsuario; }
            set { _NombreUsuario = value; }
        }

        private string _Clave;
        public string Clave
        {
            get { return _Clave; }
            set { _Clave = value; }
        }

        private string _Nombre;
        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _Apellido;
        public string Apellido
        {
            get { return _Apellido; }
            set { _Apellido = value; }
        }

        private string _Email;
        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        private bool _Habilitado;
        public  bool Habilitado
        {
            get { return _Habilitado; }
            set { _Habilitado = value; }
        }
    }
}
