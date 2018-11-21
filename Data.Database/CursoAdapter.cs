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
    public class CursoAdapter : Adapter
    {
        public List<Curso> GetAll()
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Curso cur = new Curso();
                    cur.ID = (int)dr["id_curso"];
                    cur.IDComision = (int)dr["id_comision"];
                    cur.IDMateria = (int)dr["id_materia"];
                    cur.AnioCalendario = (int)dr["anio_calendario"];
                    cur.Cupo = (int)dr["cupo"];
                    cursos.Add(cur);
                }

                dr.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                CloseConnection();
            }

            return cursos;
        }

        public Curso GetOne(int ID)
        {
            Curso cur = new Curso();
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos WHERE id_curso = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    cur.ID = (int)dr["id_curso"];
                    cur.IDComision = (int)dr["id_comision"];
                    cur.IDMateria = (int)dr["id_materia"];
                    cur.AnioCalendario = (int)dr["anio_calendario"];
                    cur.Cupo = (int)dr["cupo"];
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return cur;
        }

        public bool EstaAgregado(int id_mat, int id_com, int anio)
        {
           
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos WHERE id_materia = @id_mat AND id_comision = @id_com AND anio_calendario = @anio", sqlConn);
                cmd.Parameters.Add("@id_mat", SqlDbType.Int).Value = id_mat;
                cmd.Parameters.Add("@id_com", SqlDbType.Int).Value = id_com;
                cmd.Parameters.Add("@anio", SqlDbType.Int).Value = anio;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    return true;
                }
                else
                {
                    dr.Close();
                    return false;
                }                 
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de cursos", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }            
        }

        public List<Curso> GetByMateria(int idMat)
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM cursos WHERE id_materia = @idMat AND anio_calendario = YEAR(getdate())", sqlConn);
                cmd.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;                
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)dr["id_curso"];
                    curso.IDComision = (int)dr["id_comision"];
                    curso.IDMateria = (int)dr["id_materia"];
                    curso.AnioCalendario = (int)dr["anio_calendario"];
                    curso.Cupo = (int)dr["cupo"];
                    cursos.Add(curso);
                }

                dr.Close();
            }

            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de cursos", Ex);
                throw ExcepcionManejada;
            }

            finally
            {
                CloseConnection();
            }

            return cursos;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                sqlTran = sqlConn.BeginTransaction();
                SqlCommand cmd = new SqlCommand("DELETE cursos WHERE id_curso = @id", sqlConn, sqlTran);
                SqlCommand cmddc = new SqlCommand("DELETE docentes_cursos WHERE id_dictado = @id", sqlConn, sqlTran);
                DocenteCursoAdapter dca = new DocenteCursoAdapter();
                DocenteCurso dc = dca.GetOneByCurso(ID);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmddc.Parameters.Add("@id", SqlDbType.Int).Value = dc.ID;
                cmddc.ExecuteNonQuery();
                cmd.ExecuteNonQuery();
                sqlTran.Commit();
            }
            catch (Exception Ex)
            {
                sqlTran.Rollback();
                Exception ExcepcionManejada = new Exception("Error al eliminar curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo WHERE id_curso = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmd.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmd.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmd.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmd.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la curso", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int Insert(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO cursos(id_materia,id_comision,anio_calendario,cupo) VALUES(@id_materia,@id_comision,@anio_calendario,@cupo) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmd.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmd.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmd.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = decimal.ToInt32((decimal)cmd.ExecuteScalar());

                return curso.ID;
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear curso", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Curso curso)
        {
            switch (curso.State)
            {
                case BusinessEntity.States.New:
                    Insert(curso);
                    break;
                case BusinessEntity.States.Modified:
                    Update(curso);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(curso.ID);
                    break;
            }
        }
    }
}
