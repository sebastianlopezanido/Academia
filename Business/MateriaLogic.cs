using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Data.Database;

namespace BusinessLogic
{
    public class MateriaLogic
    {
        public MateriaLogic()
        {
            MateriaData = new Data.Database.MateriaAdapter();
        }

        private MateriaAdapter _MateriaData;
        public MateriaAdapter MateriaData
        {
            set { _MateriaData = value; }
            get { return _MateriaData; }
        }

        public Materia GetOne(int ID)
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
        }

        public void Save(Materia materia)
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
