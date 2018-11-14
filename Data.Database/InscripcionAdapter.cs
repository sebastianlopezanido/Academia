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
        protected void Insert(AlumnoInscripcion alIns)
        {
            try
            {
                OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into alumnos_inscripciones(id_alumno,id_curso) " + "values(@id_alumno,@id_curso)" + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id_alumno", SqlDbType.Int).Value = alIns.IDAlumno;
                cmdSave.Parameters.Add("@id_curso", SqlDbType.Int).Value = alIns.IDCurso;                
                alIns.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());

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
