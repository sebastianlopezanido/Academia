using System;
using System.Collections.Generic;
using System.Text;
using BusinessEntities;
using System.Data;
using System.Data.SqlClient;

namespace Data.Database
{
    public class UsuarioAdapter:Adapter
    {
        public List<Usuario> GetAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Clave = (string)dr["clave"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.IDPersona = (int)dr["id_persona"];
                    usr.Tipo = (Usuario.TiposUsuario)dr["tipo_usuario"];

                    if (Convert.IsDBNull(dr["id_plan"]))
                    {
                        usr.IDPlan = null;
                    }
                    else
                    {
                        usr.IDPlan = (int)dr["id_plan"];
                    }

                    usuarios.Add(usr);
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
            
            return usuarios;
        }

        public List<Usuario> GetAllDocentes()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE tipo_usuario = 1", sqlConn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Usuario usr = new Usuario();
                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Clave = (string)dr["clave"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.IDPersona = (int)dr["id_persona"];
                    usr.IDPlan = (int)dr["id_plan"];
                    usr.Tipo = (Usuario.TiposUsuario)dr["tipo_usuario"];
                    usuarios.Add(usr);
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar lista de usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return usuarios;
        }

        public Usuario GetOne(int ID)
        {
            Usuario usr = new Usuario();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE id_usuario = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Clave = (string)dr["clave"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.IDPersona = (int)dr["id_persona"];
                    usr.Tipo = (Usuario.TiposUsuario)dr["tipo_usuario"];

                    if (Convert.IsDBNull(dr["id_plan"]))
                    {
                        usr.IDPlan = null;
                    }
                    else
                    {
                        usr.IDPlan = (int)dr["id_plan"];
                    }
                    
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return usr;            
        }
        
        public Usuario GetOne(string nombreUsuario, string clave)
        {
            Usuario usr = new Usuario();

            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario = @usuario AND clave = @clave", sqlConn);
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = nombreUsuario;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = clave;
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    usr.ID = (int)dr["id_usuario"];
                    usr.NombreUsuario = (string)dr["nombre_usuario"];
                    usr.Clave = (string)dr["clave"];
                    usr.Habilitado = (bool)dr["habilitado"];
                    usr.IDPersona = (int)dr["id_persona"];
                    usr.Tipo = (Usuario.TiposUsuario)dr["tipo_usuario"];

                    if (Convert.IsDBNull(dr["id_plan"]))
                    {
                        usr.IDPlan = null;
                    }
                    else
                    {
                        usr.IDPlan = (int)dr["id_plan"];
                    }                    
                    
                }
                else
                {
                    Exception ExcepcionManejada = new Exception("Usuario/clave no validos");
                    throw ExcepcionManejada;
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return usr;
        }

        public Boolean GetOne(string nombreUsuario)
        {
            Usuario usr = new Usuario();
            Boolean resultado;
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("SELECT * FROM usuarios WHERE nombre_usuario = @usuario ", sqlConn);
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 50).Value = nombreUsuario;
                
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    resultado = true;

                }
                else
                {
                    resultado = false;
                }

                dr.Close();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al recuperar datos de Usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }

            return resultado;
        }

        public void Delete(int ID)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("DELETE usuarios WHERE id_usuario = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = ID;
                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al eliminar usuario", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }         
        }

        protected void Update (Usuario usuario)
        {
            try
            {
                OpenConnection();
                SqlCommand cmd = new SqlCommand("UPDATE usuarios SET nombre_usuario = @nombre_usuario, clave = @clave, habilitado = @habilitado, id_plan = @id_plan WHERE id_usuario = @id", sqlConn);
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = usuario.ID;
                cmd.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                cmd.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                
                if (usuario.IDPlan == null)
                {
                    cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = usuario.IDPlan;
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception Ex)
            {
                Exception ExcepcionManejada = new Exception("Error al modificar datos del usuarios", Ex);
                throw ExcepcionManejada;
            }
            finally
            {
                CloseConnection();
            }
        }

        protected void Insert(Usuario usuario)
        {
            try
            {
                if (! this.GetOne(usuario.NombreUsuario))
                {
                    OpenConnection();
                    SqlCommand cmd = new SqlCommand("INSERT INTO usuarios(nombre_usuario,clave,habilitado,id_persona,id_plan,tipo_usuario) " +
                        "VALUES(@nombre_usuario,@clave,@habilitado,@id_persona,@id_plan,@tipo_usuario) SELECT @@identity", sqlConn);
                    cmd.Parameters.Add("@nombre_usuario", SqlDbType.VarChar, 50).Value = usuario.NombreUsuario;
                    cmd.Parameters.Add("@clave", SqlDbType.VarChar, 50).Value = usuario.Clave;
                    cmd.Parameters.Add("@habilitado", SqlDbType.Bit).Value = usuario.Habilitado;
                    cmd.Parameters.Add("@id_persona", SqlDbType.Int).Value = usuario.IDPersona;
                    cmd.Parameters.Add("@tipo_usuario", SqlDbType.Int).Value = usuario.Tipo;
                    if (usuario.IDPlan == null)
                    {
                        cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = DBNull.Value;
                    }
                    else
                    {
                        cmd.Parameters.Add("@id_plan", SqlDbType.Int).Value = usuario.IDPlan;
                    }

                    cmd.ExecuteNonQuery();
                }

                else
                {
                    Exception ExcepcionManejada = new Exception("Ya existe un usuario con ese nombre de usuario");
                    throw ExcepcionManejada;

                }
            }
                

               
            catch (Exception Ex)
            {
                throw Ex;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void Save(Usuario usuario)
        {
            
                switch (usuario.State)
                {
                    case BusinessEntity.States.New:
                        Insert(usuario);
                        break;
                    case BusinessEntity.States.Modified:
                        Update(usuario);
                        break;
                    case BusinessEntity.States.Deleted:
                        Delete(usuario.ID);
                        break;
                }
            
            
        }        
    }
}
