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
    public class PersonasAdapter : Adapter
    {
        public List<Personas> GetAll()
        {
            List<Personas> personas = new List<Personas>();

            try
            {
                this.OpenConnection();
                SqlCommand cmdPersonas = new SqlCommand("select * from personas", sqlConn);
                SqlDataReader drPersonas = cmdPersonas.ExecuteReader();

                while (drPersonas.Read())
                {
                    Personas prs = new Personas();

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
                this.CloseConnection();
            }
            return personas;
        }

        public BusinessEntities.Personas GetOne(int ID)
        {
            Personas prs = new Personas();
            try
            {
                this.OpenConnection();
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
                this.CloseConnection();
            }
            return prs;
        }

        

        public void Delete(int ID)
        {
            try
            {
                this.OpenConnection();
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
                this.CloseConnection();
            }


        }

        protected void Update(Personas personas)
        {
            try
            {
                this.OpenConnection();
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
                this.CloseConnection();
            }

        }

        protected void Insert(Personas personas)
        {
            try
            {
                this.OpenConnection();
                SqlCommand cmdSave = new SqlCommand("insert into personas(nombre,apellido,direccion,telefono,email,fecha_nac,legajo) " + "values(@nombre,@apellido,@direccion,@telefono,@email,@fecha_nac,@legajo) " + "select @@identity", sqlConn);
                cmdSave.Parameters.Add("@id", SqlDbType.Int).Value = personas.ID;
                cmdSave.Parameters.Add("@nombre", SqlDbType.VarChar, 50).Value = personas.Nombre;
                cmdSave.Parameters.Add("@apellido", SqlDbType.VarChar, 50).Value = personas.Apellido;
                cmdSave.Parameters.Add("@direccion", SqlDbType.VarChar, 50).Value = personas.Direccion;
                cmdSave.Parameters.Add("@telefono", SqlDbType.VarChar, 50).Value = personas.Telefono;
                cmdSave.Parameters.Add("@fecha_nac", SqlDbType.DateTime).Value = personas.FechaNacimiento;
                cmdSave.Parameters.Add("@legajo", SqlDbType.Int).Value = personas.Legajo;
                cmdSave.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = personas.Email;
                
               
                personas.ID = Decimal.ToInt32((decimal)cmdSave.ExecuteScalar());
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al crear persona", Ex);
                throw ExcepcionManejada;

            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Save(Personas personas)
        {
            

            
            if (personas.State == BusinessEntity.States.Deleted)
            {
                this.Delete(personas.ID);
            }
            else if (personas.State == BusinessEntity.States.New)
            {
                this.Insert(personas);
            }
            else if (personas.State == BusinessEntity.States.Modified)
            {
                this.Update(personas);
            }
            personas.State = BusinessEntity.States.Unmodified;
            }
           

    }

}
