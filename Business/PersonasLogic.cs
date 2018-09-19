using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public class PersonasLogic : BusinessLogic
    {
        public PersonasLogic()
        {
            PersonasData = new Data.Database.PersonasAdapter();
        }

        private Data.Database.PersonasAdapter _PersonasData;
        public Data.Database.PersonasAdapter PersonasData
        {
            set { _PersonasData = value; }
            get { return _PersonasData; }
        }
        
        public BusinessEntities.Personas GetOne(int ID)
        {
            return PersonasData.GetOne(ID);
        }
        

        public List<Personas> GetAll()
        {
            try
            {
                return PersonasData.GetAll();
            }
            catch (Exception Ex)
            {
                throw;
            }

            //return PersonasData.GetAll();
        }
        /*
        public void Save(BusinessEntities.Personas persona)
        {
            PersonasData.Save(persona);
        }

        public void Delete(int ID)
        {
            PersonasData.Delete(ID);
        }
        */
    }
}
