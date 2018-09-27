using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessLogic
{
    public class PlanLogic : BusinessLogic
    {
        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }

        private Data.Database.PlanAdapter _PlanData;
        public Data.Database.PlanAdapter PlanData
        {
            set { _PlanData = value; }
            get { return _PlanData; }
        }

        public BusinessEntities.Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }


        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch (Exception Ex)
            {
                throw;
            }

            //return PersonasData.GetAll();
        }

        public void Save(BusinessEntities.Plan plan)
        {
            PlanData.Save(plan);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);
        }
    }
}
