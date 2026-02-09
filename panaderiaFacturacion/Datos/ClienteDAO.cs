using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace panaderiaFacturacion.Datos
{
    public class ClienteDAO
    {
        public DataTable ObtenerClientes()
        {
            DataTable tabla = new DataTable();
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "SELECT IdCliente, Nombre, Telefono FROM Clientes";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.Fill(tabla);
            }
            return tabla;
        }

        public void InsertarCliente(string nombre, string telefono)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "INSERT INTO Clientes (Nombre, Telefono) VALUES (@nombre, @telefono)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarCliente(int idCliente, string nombre, string telefono)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Clientes SET Nombre=@nombre, Telefono=@telefono WHERE IdCliente=@idCliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@telefono", telefono);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(int idCliente)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "DELETE FROM Clientes WHERE IdCliente=@idCliente";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idCliente", idCliente);
                conn.Open();
                cmd.ExecuteNonQuery();

            }
        }

    }
}