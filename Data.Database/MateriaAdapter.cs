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
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias", sqlConn);
                SqlDataReader drMateria = cmdMateria.ExecuteReader();

                while (drMateria.Read())
                {
                    Materia materia = new Materia();

                    materia.ID = (int)drMateria["id_materia"];
                    materia.Descripcion = (string)drMateria["desc_materia"];
                    materia.HSSemanales = (int)drMateria["hs_semanales"];
                    materia.HSTotales = (int)drMateria["hs_totales"];
                    materia.IDPlan = (int)drMateria["id_plan"];
                    materias.Add(materia);
                }

                drMateria.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de materias", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                this.CloseConnection();
            }
            return materias;
        }

        public BusinessEntities.Materia GetOne(int ID)
        {
            Materia materia = new Materia();
            try
            {
                this.OpenConnection();
                SqlCommand cmdMateria = new SqlCommand("select * from materias where id_materia=@id", sqlConn);
                cmdMateria.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drMateria = cmdMateria.ExecuteReader();
                if (drMateria.Read())
                {
                    materia.ID = (int)drMateria["id_materia"];
                    materia.Descripcion = (string)drMateria["desc_materia"];
                    materia.HSSemanales = (int)drMateria["hs_semanales"];
                    materia.HSTotales = (int)drMateria["hs_totales"];
                    materia.IDPlan = (int)drMateria["id_plan"];
                }
                drMateria.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de materias", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }
            return materia;
        }

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdDelete = new SqlCommand("delete materias where id_materia=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;

                cmdDelete.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }


        }

        protected void Update(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("UPDATE materias SET desc_materia = @desc, hs_semanales = @hs_semanales, hs_totales = @hs_totales, id_plan = @id_plan" +
                    " WHERE id_materia = @id", sqlConn);

                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = materia.ID;
                cmdSave.Parameters.Add("@desc", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("@hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("@hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("@id_plan", SqlDbType.Int).Value = materia.IDPlan;

                cmdSave.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la materia", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                this.CloseConnection();
            }

        }

        protected void Insert(Materia materia)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into materias(desc_materia,hs_semanales,hs_totales,id_plan) " + "values(@desc_materia,@hs_semanales,@hs_totales,@id_plan)" + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("desc_materia", SqlDbType.VarChar, 50).Value = materia.Descripcion;
                cmdSave.Parameters.Add("hs_semanales", SqlDbType.Int).Value = materia.HSSemanales;
                cmdSave.Parameters.Add("hs_totales", SqlDbType.Int).Value = materia.HSTotales;
                cmdSave.Parameters.Add("id_plan", SqlDbType.Int).Value = materia.IDPlan;
                materia.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear materia", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Materia materia)
        {
            if (materia.State == BusinessEntity.States.Deleted)
            {
                this.Delete(materia.ID);
            }
            else if (materia.State == BusinessEntity.States.New)
            {
                this.Insert(materia);
            }
            else if (materia.State == BusinessEntity.States.Modified)
            {
                this.Update(materia);
            }
            materia.State = BusinessEntity.States.Unmodified;
        }
    }
}
