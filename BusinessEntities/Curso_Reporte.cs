using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class Curso_Reporte
    {
        private string _ID;
        public string ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Materia;
        public string Materia
        {
            get { return _Materia; }
            set { _Materia = value; }
        }

        private string _Comision;
        public string Comision
        {
            get { return _Comision; }
            set { _Comision = value; }
        }

        private string _Año;
        public string Año
        {
            get { return _Año; }
            set { _Año = value; }
        }

        private string _Cupo;
        public string Cupo
        {
            get { return _Cupo; }
            set { _Cupo = value; }
        }

        private string _Profesor;
        public string Profesor
        {
            get { return _Profesor; }
            set { _Profesor = value; }
        }


    }
}
