using BusinessEntities;
using Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class DocenteCursoLogic
    {
        public DocenteCursoLogic()
        {
           DocenteCursoData = new DocenteCursoAdapter();
        }

        private DocenteCursoAdapter _DocenteCursoData;
        public DocenteCursoAdapter DocenteCursoData
        {
            set { _DocenteCursoData = value; }
            get { return _DocenteCursoData; }
        }

        public void Save(DocenteCurso doCu)
        {
            DocenteCursoData.Save(doCu);
        }

      
        public List<DocenteCurso> GetAll(int id)
        {
            try
            {
                return DocenteCursoData.GetAll(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DocenteCurso GetOneByCurso(int id)
        {
            try
            {
                return DocenteCursoData.GetOneByCurso(id);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
