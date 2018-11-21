using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using Data.Database;

namespace BusinessLogic
{
    public class PlanLogic
    {
        public PlanLogic()
        {
            PlanData = new Data.Database.PlanAdapter();
        }

        private PlanAdapter _PlanData;
        public PlanAdapter PlanData
        {
            set { _PlanData = value; }
            get { return _PlanData; }
        }

        public Plan GetOne(int ID)
        {
            return PlanData.GetOne(ID);
        }

        public List<Plan> GetAll()
        {
            try
            {
                return PlanData.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Save(Plan plan)
        {
            PlanData.Save(plan);
        }

        public void Delete(int ID)
        {
            PlanData.Delete(ID);            
        }
    }
}
