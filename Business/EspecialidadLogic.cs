using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class EspecialidadLogic : BusinessLogic
    {
        
        public EspecialidadLogic()
        {
            EspecialidadData = new Data.Database.EspecialidadAdapter();
        }
        
        private Data.Database.EspecialidadAdapter _EspecialidadData;
        public Data.Database.EspecialidadAdapter EspecialidadData
        {
            set { _EspecialidadData = value; }
            get { return _EspecialidadData; }
        }

        /*public BusinessEntities.Especialidad GetOne(int ID)
        {
            //return EspecialidadData.GetOne(ID);
        }
        */

        public List<Especialidad> GetAll()
        {
            try
            {
                return EspecialidadData.GetAll();
            }
            catch (Exception Ex)
            {
                throw;
            }

            //return PersonasData.GetAll();
        }

        public void Save(BusinessEntities.Especialidad especialidad)
        {
            //EspecialidadData.Save(especialidad);
        }

        public void Delete(int ID)
        {
            //EspecialidadData.Delete(ID);
        }
        
    }
}
