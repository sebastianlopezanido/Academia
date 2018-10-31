using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public class ComisionLogic : BusinessLogic
    {
        public ComisionLogic()
        {
            ComisionData = new Data.Database.ComisionAdapter();
        }

        private Data.Database.ComisionAdapter _ComisionData;
        public Data.Database.ComisionAdapter ComisionData
        {
            set { _ComisionData = value; }
            get { return _ComisionData; }
        }

        public Comision GetOne(int ID)
        {
            return ComisionData.GetOne(ID);
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
            ComisionData.Save(comision);
        }

        public void Delete(int ID)
        {
            ComisionData.Delete(ID);
        }
    }
}
