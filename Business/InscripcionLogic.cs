using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using BusinessEntities;

namespace BusinessLogic
{
    public class InscripcionLogic : BusinessLogic
    {
        public InscripcionLogic()
        {
            InscripcionData = new InscripcionAdapter();
        }

        private InscripcionAdapter _InscripcionData;
        public InscripcionAdapter InscripcionData
        {
            set { _InscripcionData = value; }
            get { return _InscripcionData; }
        }

        public void Save(AlumnoInscripcion alIns)
        {
            InscripcionData.Save(alIns);
        }
    }
}
