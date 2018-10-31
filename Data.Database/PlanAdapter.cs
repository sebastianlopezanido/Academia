using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using BusinessEntities;
using System.Data;

namespace Data.Database
{
    public class PlanAdapter : Adapter
    {
        public List<Plan> GetAll()
        {
            List<Plan> planes = new List<Plan>();

            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("select * from planes", sqlConn);
                SqlDataReader drPlan = cmdPlan.ExecuteReader();

                while (drPlan.Read())
                {
                    Plan plan = new Plan();

                    plan.ID = (int)drPlan["id_plan"];
                    plan.Descripcion = (string)drPlan["desc_plan"];
                    plan.IDEspecialidad = (int)drPlan["id_especialidad"];
                    planes.Add(plan);
                }

                drPlan.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return planes;
        }

        public Plan GetOne(int ID)
        {
            Plan plan = new Plan();
            try
            {
                OpenConnection();
                SqlCommand cmdPlan = new SqlCommand("select * from planes where id_plan=@id", sqlConn);
                cmdPlan.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPlan = cmdPlan.ExecuteReader();

                if (drPlan.Read())
                {
                    plan.ID = (int)drPlan["id_plan"];
                    plan.Descripcion = (string)drPlan["desc_plan"];
                    plan.IDEspecialidad = (int)drPlan["id_especialidad"];
                }

                drPlan.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de planes", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return plan;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete planes where id_plan=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE planes SET desc_plan = @desc, id_especialidad = @id_esp" +
                    " WHERE id_plan = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Plan plan)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into planes(desc_plan,id_especialidad) " + "values(@desc_plan,@id_especialidad)" + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmdSave.Parameters.Add("id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                plan.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear plan", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Plan plan)
        {
            switch (plan.State)
            {
                case BusinessEntity.States.New:
                    Insert(plan);
                    break;
                case BusinessEntity.States.Modified:
                    Update(plan);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(plan.ID);
                    break;
            }

        }
    }
}

