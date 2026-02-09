using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace panaderiaFacturacion
{
    public class Conexion
    {
        private static string cadena = ConfigurationManager.ConnectionStrings["conexion"].ConnectionString;


        public static SqlConnection ObtenerConexion()
        {
            return new SqlConnection(cadena);
        }
    }
}
