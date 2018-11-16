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
                SqlCommand cmd = new SqlCommand("SELECT * FROM planes", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Plan pla = new Plan();
                    pla.ID = (int)dr["id_plan"];
                    pla.Descripcion = (string)dr["desc_plan"];
                    pla.IDEspecialidad = (int)dr["id_especialidad"];
                    planes.Add(pla);
                }

                dr.Close();
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
            Plan pla = new Plan();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM planes WHERE id_plan = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    pla.ID = (int)dr["id_plan"];
                    pla.Descripcion = (string)dr["desc_plan"];
                    pla.IDEspecialidad = (int)dr["id_especialidad"];
                }

                dr.Close();
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

            return pla;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE planes WHERE id_plan = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("UPDATE planes SET desc_plan = @desc, id_especialidad = @id_esp WHERE id_plan = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = plan.ID;
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmd.Parameters.Add("@id_esp", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmd.ExecuteNonQuery();
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
                SqlCommand cmd = new SqlCommand("INSERT INTO planes(desc_plan,id_especialidad) VALUES(@desc_plan,@id_especialidad) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("desc_plan", SqlDbType.VarChar, 50).Value = plan.Descripcion;
                cmd.Parameters.Add("id_especialidad", SqlDbType.Int).Value = plan.IDEspecialidad;
                cmd.ExecuteNonQuery();
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

