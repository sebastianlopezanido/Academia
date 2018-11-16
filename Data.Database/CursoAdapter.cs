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
                SqlCommand cmd = new SqlCommand("DELETE cursos WHERE id_curso = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
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

        protected void Insert(Curso curso)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO cursos(id_materia,id_comision,anio_calendario,cupo) VALUES(@id_materia,@id_comision,@anio_calendario,@cupo) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmd.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmd.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmd.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmd.ExecuteNonQuery();
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
