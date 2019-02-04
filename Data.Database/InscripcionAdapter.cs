using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data.SqlClient;
using System.Data;

namespace Data.Database
{
    public class InscripcionAdapter : Adapter
    {
        public List<AlumnoInscripcion> GetAll(int id)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

            try
            {   
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_alumno = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    ai.ID = (int)dr["id_inscripcion"];
                    ai.IDAlumno = (int)dr["id_alumno"];
                    ai.IDCurso = (int)dr["id_curso"];
                    ai.Condicion = (AlumnoInscripcion.TiposCondiciones)dr["condicion"];
                    if(dr.IsDBNull(4)) ai.Nota = null; else ai.Nota = (int)dr["nota"];                    
                    inscripciones.Add(ai);
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

            return inscripciones;
        }

        public List<AlumnoInscripcion> GetAllByCurso(int id)
        {
            List<AlumnoInscripcion> inscripciones = new List<AlumnoInscripcion>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_curso = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    AlumnoInscripcion ai = new AlumnoInscripcion();
                    ai.ID = (int)dr["id_inscripcion"];
                    ai.IDAlumno = (int)dr["id_alumno"];
                    ai.IDCurso = (int)dr["id_curso"];
                    ai.Condicion = (AlumnoInscripcion.TiposCondiciones)dr["condicion"];
                    if (dr.IsDBNull(4)) ai.Nota = null; else ai.Nota = (int)dr["nota"];
                    inscripciones.Add(ai);
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

            return inscripciones;
        }


        public AlumnoInscripcion GetOne(int id)
        {
            AlumnoInscripcion inscripcion = new AlumnoInscripcion();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM alumnos_inscripciones WHERE id_inscripcion = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                   
                    inscripcion.ID = (int)dr["id_inscripcion"];
                    inscripcion.IDAlumno = (int)dr["id_alumno"];
                    inscripcion.IDCurso = (int)dr["id_curso"];
                    inscripcion.Condicion = (AlumnoInscripcion.TiposCondiciones)dr["condicion"];
                    if (dr.IsDBNull(4)) inscripcion.Nota = null; else inscripcion.Nota = (int)dr["nota"];
                   
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar curso", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                CloseConnection();
            }

            return inscripcion;
        }


        protected void Insert(AlumnoInscripcion alIns)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno,id_curso,condicion) VALUES(@id_alumno,@id_curso,@condicion) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alIns.IDAlumno;
                cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = alIns.IDCurso;
                cmd.Parameters.Add("@condicion", SqlDbType.Int).Value = AlumnoInscripcion.TiposCondiciones.Indefinida;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(AlumnoInscripcion inscripcion)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE alumnos_inscripciones SET nota = @nota, condicion=@cond WHERE id_inscripcion = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = inscripcion.ID;
                cmd.Parameters.Add("@nota", SqlDbType.Int).Value = inscripcion.Nota;
                cmd.Parameters.Add("@cond", SqlDbType.Int).Value = inscripcion.Condicion;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos de la inscripcion", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public bool EstaInscripto(int idUsr, int idMat)
        {
            try
            {
                int cant = 0;
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM alumnos_inscripciones WHERE id_alumno=@idUsr AND id_curso=(SELECT id_curso FROM cursos WHERE id_materia=@idMat AND anio_calendario=YEAR(getdate()))", sqlConn);
                cmd.Parameters.Add("@idUsr", SqlDbType.Int).Value = idUsr;
                cmd.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;
                cant = (int)cmd.ExecuteScalar();
                if (cant == 0) return false; else return true;                
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al comprobar inscripcion", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(AlumnoInscripcion alIns)
        {
            switch (alIns.State)
            {
                case BusinessEntity.States.New:
                    Insert(alIns);
                    break;
                case BusinessEntity.States.Modified:
                    Update(alIns);
                    break;
            }
        }
    }
}
