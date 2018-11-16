using BusinessEntities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Database
{
    public class EspecialidadAdapter : Adapter
    {

        public List<Especialidad> GetAll()
        {
            List<Especialidad> especialidades = new List<Especialidad>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM especialidades", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Especialidad esp = new Especialidad();
                    esp.ID = (int)dr["id_especialidad"];
                    esp.Descripcion = (string)dr["desc_especialidad"];
                    especialidades.Add(esp);
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return especialidades;
        }

        public Especialidad GetOne(int ID)
        {
            Especialidad esp = new Especialidad();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM especialidades WHERE id_especialidad = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    esp.ID = (int)dr["id_especialidad"];
                    esp.Descripcion = (string)dr["desc_especialidad"];
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de especialidades", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return esp;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE especialidades WHERE id_especialidad = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Especialidad especialidad)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE especialidades SET desc_especialidad = @desc WHERE id_especialidad = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = especialidad.ID;
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;                
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Especialidad especialidad)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO especialidades(desc_especialidad) VALUES(@desc_especialidad) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("desc_especialidad", SqlDbType.VarChar, 50).Value = especialidad.Descripcion;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear especialidad", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Especialidad especialidad)
        {
            switch (especialidad.State)
            {
                case BusinessEntity.States.New:
                    Insert(especialidad);
                    break;
                case BusinessEntity.States.Modified:
                    Update(especialidad);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(especialidad.ID);
                    break;
            }
        }
    }
}
