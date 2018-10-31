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
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Persona prs = new Persona();
                    prs.ID = (int)drPersonas["id_persona"];
                    prs.Apellido = (string)drPersonas["apellido"];
                    prs.Nombre = (string)drPersonas["nombre"];
                    prs.Email = (string)drPersonas["email"];
                    prs.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    prs.Legajo = (int)drPersonas["legajo"];
                    prs.Telefono = (string)drPersonas["telefono"];
                    personas.Add(prs);
                }

                drPersonas.Close();
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
                SqlCommand cmdPersonas = new SqlCommand("select * from personas where id_persona=@id", sqlConn);
                cmdPersonas.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                if (drPersonas.Read())
                {
                    prs.ID = (int)drPersonas["id_persona"];
                    prs.Apellido = (string)drPersonas["apellido"];
                    prs.Nombre = (string)drPersonas["nombre"];
                    prs.Email = (string)drPersonas["email"];
                    prs.FechaNacimiento = (DateTime)drPersonas["fecha_nac"];
                    prs.Legajo = (int)drPersonas["legajo"];
                    prs.Telefono = (string)drPersonas["telefono"];
                    prs.Direccion = (string)drPersonas["direccion"];                    
                }

                drPersonas.Close();
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
                SqlCommand cmdDelete = new SqlCommand("delete personas where id_persona=@id", sqlConn);
                cmdDelete.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmdDelete.ExecuteNonQuery();
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
                SqlCommand cmdSave = new SqlCommand("UPDATE personas SET nombre = @nombre, " +
                    "direccion = @direccion, telefono = @telefono, fecha_nac = @fecha_nac, legajo = @legajo, apellido = @apellido, " +
                    "email = @email WHERE id_persona = @id", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = personas.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = personas.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = personas.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = personas.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = personas.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = personas.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = personas.Legajo;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = personas.Email;
                cmdSave.ExecuteNonQuery();
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
                SqlCommand cmdSave = new SqlCommand("insert into personas(nombre,apellido,direccion,telefono,email,fecha_nac,legajo) " + 
                    "values(@nombre,@apellido,@direccion,@telefono,@email,@fecha_nac,@legajo) " + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = personas.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = personas.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = personas.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = personas.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = personas.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = personas.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = personas.Legajo;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = personas.Email;   
                personas.ID = decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
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
