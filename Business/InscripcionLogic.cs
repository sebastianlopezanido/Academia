using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;
using BusinessEntities;

namespace BusinessLogic
{
    public class InscripcionLogic
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

        public bool EstaInscripto(int idUsr, int idMat)
        {
            return InscripcionData.EstaInscripto(idUsr, idMat);
        }

        public List<AlumnoInscripcion> GetAll(int id)
        {
            try
            {
                return InscripcionData.GetAll(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AlumnoInscripcion GetOne(int id)
        {
            try
            {
                return InscripcionData.GetOne(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AlumnoInscripcion> GetAllByCurso(int id)
        {
            try
            {
                return InscripcionData.GetAllByCurso(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
