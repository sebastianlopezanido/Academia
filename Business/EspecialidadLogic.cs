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
            EspecialidadData = new EspecialidadAdapter();
        }
        
        private EspecialidadAdapter _EspecialidadData;
        public EspecialidadAdapter EspecialidadData
        {
            set { _EspecialidadData = value; }
            get { return _EspecialidadData; }
        }

        public Especialidad GetOne(int ID)
        {
            try
            {
                return EspecialidadData.GetOne(ID);
            }
            catch (Exception)
            {
                throw;
            }            
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
            try
            {
                EspecialidadData.Save(especialidad);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public void Delete(int ID)
        {            
            try
            {
                EspecialidadData.Delete(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }        
    }
}
