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
                SqlCommand cmdCurso = new SqlCommand("select * from cursos", sqlConn);
                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                while (drCurso.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.Cupo = (int)drCurso["cupo"];
                    cursos.Add(curso);
                }

                drCurso.Close();
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
            Curso curso = new Curso();
            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_curso=@id", sqlConn);
                cmdCurso.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                if (drCurso.Read())
                {
                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.Cupo = (int)drCurso["cupo"];
                }

                drCurso.Close();
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

            return curso;
        }

        public List<Curso> GetByMateria(int idMat)
        {
            List<Curso> cursos = new List<Curso>();

            try
            {
                OpenConnection();
                SqlCommand cmdCurso = new SqlCommand("select * from cursos where id_materia=@idMat and anio_calendario=@anio", sqlConn);
                cmdCurso.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;
                cmdCurso.Parameters.Add("@anio", SqlDbType.Int).Value = DateTime.Now.Year;
                SqlDataReader drCurso = cmdCurso.ExecuteReader();

                while (drCurso.Read())
                {
                    Curso curso = new Curso();
                    curso.ID = (int)drCurso["id_curso"];
                    curso.IDComision = (int)drCurso["id_comision"];
                    curso.IDMateria = (int)drCurso["id_materia"];
                    curso.AnioCalendario = (int)drCurso["anio_calendario"];
                    curso.Cupo = (int)drCurso["cupo"];
                    cursos.Add(curso);
                }

                drCurso.Close();
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
                SqlCommand cmdDelete = new SqlCommand("delete cursos where id_curso=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
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
                SqlCommand cmdSave = new SqlCommand("UPDATE cursos SET id_materia = @id_materia, id_comision = @id_comision, anio_calendario = @anio_calendario, cupo = @cupo" +
                    " WHERE id_curso = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = curso.ID;
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                cmdSave.ExecuteNonQuery();
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
                SqlCommand cmdSave = new SqlCommand("insert into cursos(id_materia,id_comision,anio_calendario,cupo) " + "values(@id_materia,@id_comision,@anio_calendario,@cupo)" + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_comision", SqlDbType.Int).Value = curso.IDComision;
                cmdSave.Parameters.Add("@id_materia", SqlDbType.Int).Value = curso.IDMateria;
                cmdSave.Parameters.Add("@anio_calendario", SqlDbType.Int).Value = curso.AnioCalendario;
                cmdSave.Parameters.Add("@cupo", SqlDbType.Int).Value = curso.Cupo;
                curso.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

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
