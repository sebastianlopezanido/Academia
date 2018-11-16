using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class PersonaAdapter : Adapter
    {
        public List<Persona> GetAll()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM personas", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Persona prs = new Persona();
                    prs.ID = (int)dr["id_persona"];
                    prs.Apellido = (string)dr["apellido"];
                    prs.Nombre = (string)dr["nombre"];
                    prs.Email = (string)dr["email"];
                    prs.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    prs.Legajo = (int)dr["legajo"];
                    prs.Telefono = (string)dr["telefono"];
                    personas.Add(prs);
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return personas;
        }

        public Persona GetOne(int ID)
        {
            Persona prs = new Persona();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM personas WHERE id_persona = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    prs.ID = (int)dr["id_persona"];
                    prs.Apellido = (string)dr["apellido"];
                    prs.Nombre = (string)dr["nombre"];
                    prs.Email = (string)dr["email"];
                    prs.FechaNacimiento = (DateTime)dr["fecha_nac"];
                    prs.Legajo = (int)dr["legajo"];
                    prs.Telefono = (string)dr["telefono"];
                    prs.Direccion = (string)dr["direccion"];                    
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return prs;
        }        

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE personas WHERE id_persona = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Update(Persona personas)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE personas SET nombre = @nombre, direccion = @direccion, telefono = @telefono," +
                    " fecha_nac = @fecha_nac, legajo = @legajo, apellido = @apellido,email = @email WHERE id_persona = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = personas.ID;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = personas.Nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = personas.Apellido;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = personas.Direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = personas.Telefono;
                cmd.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = personas.FechaNacimiento;
                cmd.Parameters.Add("@legajo", SqlDbType.Int).Value = personas.Legajo;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = personas.Email;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del personas", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Persona personas)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("INSERT INTO personas(nombre,apellido,direccion,telefono,email,fecha_nac,legajo) " + 
                    "VALUES(@nombre,@apellido,@direccion,@telefono,@email,@fecha_nac,@legajo) SELECT @@identity", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = personas.ID;
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = personas.Nombre;
                cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = personas.Apellido;
                cmd.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = personas.Direccion;
                cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = personas.Telefono;
                cmd.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = personas.FechaNacimiento;
                cmd.Parameters.Add("@legajo", SqlDbType.Int).Value = personas.Legajo;
                cmd.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = personas.Email;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Persona personas)
        {
            switch (personas.State)
            {
                case BusinessEntity.States.New:
                    Insert(personas);
                    break;
                case BusinessEntity.States.Modified:
                    Update(personas);
                    break;
                case BusinessEntity.States.Deleted:
                    Delete(personas.ID);
                    break;
            }
        }
    }
}
