using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public class CursoLogic : BusinessLogic
    {
        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }

        private Data.Database.CursoAdapter _CursoData;
        public Data.Database.CursoAdapter CursoData
        {
            set { _CursoData = value; }
            get { return _CursoData; }
        }

        public BusinessEntities.Curso GetOne(int ID)
        {
            return CursoData.GetOne(ID);
        }


        public List<Curso> GetAll()
        {
            try
            {
                return CursoData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
                       
        }

        public void Save(BusinessEntities.Curso curso)
        {
            CursoData.Save(curso);
        }

        public void Delete(int ID)
        {
            try
            {
                CursoData.Delete(ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
