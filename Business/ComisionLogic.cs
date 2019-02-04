using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Data.Database;

namespace BusinessLogic
{
    public class ComisionLogic
    {
        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();
        }

        private ComisionAdapter _ComisionData;
        public ComisionAdapter ComisionData
        {
            set { _ComisionData = value; }
            get { return _ComisionData; }
        }

        public Comision GetOne(int ID)
        {
            try
            {
                return ComisionData.GetOne(ID);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public List<Comision> GetAll()
        {
            try
            {
                return ComisionData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public void Save(Comision comision)
        {
            try
            {
                ComisionData.Save(comision);
            }
            catch (Exception)
            {
                throw;
            }
        }    

        public void Delete(int ID)
        {
            try
            {
                ComisionData.Delete(ID);
            }
            catch (Exception)
            {
                throw;
            }            
        }
    }
}
