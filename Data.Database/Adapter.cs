using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Sql;

namespace Data.Database
{
    public class Adapter
    {
        private SqlConnection _sqlConn;
        public SqlConnection sqlConn
        {
            set
            {
                _sqlConn = value;
            }
            get
            {
                return _sqlConn;
            }
        }


        //private SqlConnection sqlConnection = new SqlConnection("ConnectionString;");

        protected void OpenConnection()
        {
            //var conn = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString; //error usandola en sqlConn???
            string conn1 = "Server=localhost\\SqlExpress;Database=tp2_net;Integrated Security=true;"; 


            sqlConn = new SqlConnection(conn1);
            sqlConn.Open();

            //throw new Exception("Metodo no implementado");
            
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
            //throw new Exception("Metodo no implementado");
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
        //Clave por defecto a utlizar para la cadena de conexion
        const string consKeyDefaultCnnString = "ConnStringExpressLocal";
    }
}
