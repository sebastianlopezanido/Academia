using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Data.Database;

namespace BusinessLogic
{
    public class CursoLogic
    {
        public CursoLogic()
        {
            CursoData = new Data.Database.CursoAdapter();
        }

        private CursoAdapter _CursoData;
        public CursoAdapter CursoData
        {
            set { _CursoData = value; }
            get { return _CursoData; }
        }

        public Curso GetOne(int ID)
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

        public List<Curso> GetByMateria(int idMat)
        {
            try
            {
                return CursoData.GetByMateria(idMat);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save(Curso curso)
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
