using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public class MateriaLogic : BusinessLogic
    {
        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();
        }

        private Data.Database.MateriaAdapter _MateriaData;
        public Data.Database.MateriaAdapter MateriaData
        {
            set { _MateriaData = value; }
            get { return _MateriaData; }
        }

        public BusinessEntities.Materia GetOne(int ID)
        {
            return MateriaData.GetOne(ID);
        }


        public List<Materia> GetAll()
        {
            try
            {
                return MateriaData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

            //return PersonasData.GetAll();
        }

        public void Save(BusinessEntities.Materia materia)
        {
            MateriaData.Save(materia);
        }

        public void Delete(int ID)
        {
            try
            {
                MateriaData.Delete(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
