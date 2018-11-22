using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Plan_Reporte 
    {
        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _Especialidad;
        public string Especialidad
        {
            get { return _Especialidad; }
            set { _Especialidad = value; }
        }

        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

    }
}

