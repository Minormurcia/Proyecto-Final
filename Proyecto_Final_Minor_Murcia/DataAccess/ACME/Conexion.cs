using Microsoft.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace DataAccess.ACME
{
    public class Conexion
    {


        private readonly string? _cadenaConexion;


        public Conexion()
        {
            string? cadenaConexion;

            //obtener la cadena de conexion desde variable de entrono
            cadenaConexion = Environment.GetEnvironmentVariable("SQLServerXE");

            _cadenaConexion = cadenaConexion;


        }

        public SqlConnection Conectar()
        { 

          SqlConnection sqlconn;


        // Instanciar la conexion utilizando la cadena de conexion obtenida
           sqlconn = new SqlConnection(_cadenaConexion);

          return sqlconn;

        }



    }
}
