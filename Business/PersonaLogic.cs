using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public class PersonaLogic : BusinessLogic
    {
        public PersonaLogic()
        {
            PersonasData = new Data.Database.PersonaAdapter();
        }

        private Data.Database.PersonaAdapter _PersonasData;
        public Data.Database.PersonaAdapter PersonasData
        {
            set { _PersonasData = value; }
            get { return _PersonasData; }
        }
        
        public Persona GetOne(int ID)
        {
            return PersonasData.GetOne(ID);
        }        

        public List<Persona> GetAll()
        {
            try
            {
                return PersonasData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }

            //return PersonasData.GetAll();
        }
        
        public void Save(Persona persona)
        {
           PersonasData.Save(persona);    
        }

        public void Delete(int ID)
        {
            PersonasData.Delete(ID);
        }
        
    }
}
