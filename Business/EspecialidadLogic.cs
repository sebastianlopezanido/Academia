using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Database;

namespace BusinessLogic
{
    public class EspecialidadLogic
    {        
        public EspecialidadLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadAdapter();
        }
        
        private EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData
        {
            set { _EspecialidadData = value; }
            get { return _EspecialidadData; }
        }

        public Especialidad GetOne(int ID)
        {
            return EspecialidadData.GetOne(ID);
        }       

        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save(Especialidad especialidad)
        {
            try { EspecialidadData.Save(especialidad); }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Delete(int ID)
        {
            EspecialidadData.Delete(ID);
           
            
        }        
    }
}
