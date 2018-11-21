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
    public class MateriaAdapter : Adapter
    {
        public List<Materia> GetAll()
        {
            List<Materia> materias = new List<Materia>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM materias", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Materia mat = new Materia();
                    mat.ID = (int)dr["id_materia"];
                    mat.Descripcion = (string)dr["desc_materia"];
                    mat.HSSemanales = (int)dr["hs_semanales"];
                    mat.HSTotales = (int)dr["hs_totales"];
                    mat.IDPlan = (int)dr["id_plan"];
                    materias.Add(mat);
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return materias;
        }

        public Materia GetOne(int ID)
        {
            Materia mat = new Materia();
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM materias WHERE id_materia = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    mat.ID = (int)dr["id_materia"];
                    mat.Descripcion = (string)dr["desc_materia"];
                    mat.HSSemanales = (int)dr["hs_semanales"];
                    mat.HSTotales = (int)dr["hs_totales"];
                    mat.IDPlan = (int)dr["id_plan"];
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return mat;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE materias WHERE id_materia = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Materia materia)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE materias SET desc_materia = @desc, hs_semanales = @hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan WHERE id_materia = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmd.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmd.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmd.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Materia materia)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO materias(desc_materia,hs_semanales,hs_totales,id_plan) VALUES(@desc_materia,@hs_semanales,@hs_totales,@id_plan) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmd.Parameters.Add("hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmd.Parameters.Add("hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmd.Parameters.Add("id_plan", SqlDbType.Int).Value = materia.IDPlan;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Materia materia)
        {
            switch (materia.State)
            {
                case BusinessEntity.States.New:
                    Insert(materia);
                    break;
                case BusinessEntity.States.Modified:
                    Update(materia);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(materia.ID);
                    break;
            }
        }
    }
}
