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
    public class DocenteCursoAdapter:Adapter
    {
        public List<DocenteCurso> GetAll(int id)
        {
            List<DocenteCurso> dictado = new List<DocenteCurso>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_docente = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)dr["id_dictado"];
                    dc.IDCurso = (int)dr["id_curso"];
                    dc.IDDocente = (int)dr["id_docente"];
                    dc.Cargo = (DocenteCurso.TiposCargos)dr["cargo"];
                    dictado.Add(dc);
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar Dictado", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                CloseConnection();
            }

            return dictado;
        }

        public DocenteCurso GetOneByCurso(int id)
        {
            DocenteCurso dictado = new DocenteCurso();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM docentes_cursos WHERE id_curso = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    DocenteCurso dc = new DocenteCurso();
                    dc.ID = (int)dr["id_dictado"];
                    dc.IDCurso = (int)dr["id_curso"];
                    dc.IDDocente = (int)dr["id_docente"];
                    dc.Cargo = (DocenteCurso.TiposCargos)dr["cargo"];
                    
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar Dictado", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                CloseConnection();
            }

            return dictado;
        }

        protected void Insert(DocenteCurso doCu)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO docentes_cursos(id_curso,id_docente,cargo) VALUES(@id_curso,@id_docente,@cargo) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("@id_docente", SqlDbType.Int).Value = doCu.IDDocente;
                cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = doCu.IDCurso;
                cmd.Parameters.Add("@id_curso", SqlDbType.Int).Value = doCu.Cargo;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear dictado", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        //public bool EstaInscripto(int idUsr, int idMat)
        //{
        //    try
        //    {
        //        int cant = 0;
        //        OpenConnection();
        //        SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM alumnos_inscripciones WHERE id_alumno=@idUsr AND id_curso=(SELECT id_curso FROM cursos WHERE id_materia=@idMat AND anio_calendario=YEAR(getdate()))", sqlConn);
        //        cmd.Parameters.Add("@idUsr", SqlDbType.Int).Value = idUsr;
        //        cmd.Parameters.Add("@idMat", SqlDbType.Int).Value = idMat;
        //        cant = Convert.ToInt32(cmd.ExecuteScalar());
        //        if (cant == 0) return false; else return true;
        //    }
        //    catch (Exception Ex)
        //    {
        //        Exception ExcepcionManejada = new Exception("Error al comprobar inscripcion", Ex);
        //        throw ExcepcionManejada;

        //    }
        //    finally
        //    {
        //        CloseConnection();
        //    }
        //}

        public void Save(DocenteCurso doCu)
        {
            switch (doCu.State)
            {
                case BusinessEntity.States.New:
                    Insert(doCu);
                    break;
                    //case BusinessEntity.States.Modified:
                    //    Update(alIns);
                    //    break;
            }
        }
    }
}

