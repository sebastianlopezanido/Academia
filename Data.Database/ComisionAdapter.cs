using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using BusinessEntities;

namespace Data.Database
{
    public class ComisionAdapter : Adapter
    {
        public List<Comision> GetAll()
        {
            List<Comision> comisiones = new List<Comision>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM comisiones", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Comision com = new Comision();
                    com.ID = (int)dr["id_comision"];
                    com.Descripcion = (string)dr["desc_comision"];
                    com.AnioEspecialidad = (int)dr["anio_especialidad"];
                    com.IDPlan = (int)dr["id_plan"];
                    comisiones.Add(com);
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return comisiones;
        }

        public Comision GetOne(int ID)
        {
            Comision com = new Comision();
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM comisiones WHERE id_comision = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    com.ID = (int)dr["id_comision"];
                    com.Descripcion = (string)dr["desc_comision"];
                    com.AnioEspecialidad = (int)dr["anio_especialidad"];
                    com.IDPlan = (int)dr["id_plan"];
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de comisiones", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return com;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE comisiones WHERE id_comision = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Comision comision)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE comisiones SET desc_comision = @desc, anio_especialidad = @anio, id_plan = @id_plan WHERE id_comision = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = comision.ID;
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmd.Parameters.Add("@anio", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Comision comision)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO comisiones(desc_comision,anio_especialidad,id_plan) VALUES(@desc,@anio,@id_plan) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = comision.Descripcion;
                cmd.Parameters.Add("@anio", SqlDbType.Int).Value = comision.AnioEspecialidad;
                cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = comision.IDPlan;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear comision", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Comision comision)
        {
            try
            {
                switch (comision.State)
                {
                    case BusinessEntity.States.New:
                        Insert(comision);
                        break;
                    case BusinessEntity.States.Modified:
                        Update(comision);
                        break;
                    case BusinessEntity.States.Deleted:
                        Delete(comision.ID);
                        break;
                }
            }
            catch (Exception Ex)
            {
                throw Ex;
            }
        }
            
    }
}