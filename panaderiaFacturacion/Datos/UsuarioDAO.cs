using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace panaderiaFacturacion.Datos
{
    public class UsuarioDAO
    {
        public DataTable ObtenerUsuarios()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "SELECT IdUsuario, Usuario, Clave FROM Usuarios";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void AgregarUsuario(string usuario, string clave)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "INSERT INTO Usuarios (Usuario, Clave) VALUES (@usuario, @clave)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@clave", clave);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EditarUsuario(int idUsuario, string usuario, string clave)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Usuarios SET Usuario=@usuario, Clave=@clave WHERE IdUsuario=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@clave", clave);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "DELETE FROM Usuarios WHERE IdUsuario=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idUsuario);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }

}
