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
                    if(dr.IsDBNull(3)) ai.Condicion = null; else ai.Condicion = (string)dr["condicion"];
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

        protected void Insert(AlumnoInscripcion alIns)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO alumnos_inscripciones(id_alumno,id_curso) VALUES(@id_alumno,@id_curso) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alIns.IDAlumno;
                cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = alIns.IDCurso;
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

        public bool EstaInscripto(int idUsr, int idMat)
        {
            try
            {
                int cant = 0;
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM alumnos_inscripciones WHERE id_alumno=@idUsr AND id_curso=(SELECT id_curso FROM cursos WHERE id_materia=@idMat AND anio_calendario=YEAR(getdate()))", sqlConn);
                cmd.Parameters.Add("@idUsr", SqlDbType.Int).Value = idUsr;
                cmd.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;
                cant = Convert.ToInt32(cmd.ExecuteScalar());
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
                //case BusinessEntity.States.Modified:
                //    Update(alIns);
                //    break;
            }
        }
    }
}
