using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    class Curso
    {
        private int _AnioCalendario;
        public int AnioCalendario
        {
            get { return _AnioCalendario; }
            set { _AnioCalendario = value; }
        }

        private int _Cupo;
        public int Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private int _IDComision;
        public int IDComision
        {
            get { return _IDComision; }
            set { _IDComision = value; }
        }

        private int _IDMateria;
        public int IDMateria
        {
            get { return _IDMateria; }
            set { _IDMateria = value; }
        }

    }
}
