using System.Data;
using System.Data.SqlClient;

namespace panaderiaFacturacion.Datos
{
    public class ProductoDAO
    {
        public void InsertarProducto(string nombre, decimal precio, int stock)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "INSERT INTO Productos (Nombre, Precio, Stock) VALUES (@n, @p, @s)";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@p", precio);
                cmd.Parameters.AddWithValue("@s", stock);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public DataTable ObtenerProductos()
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "SELECT IdProducto, Nombre, Precio FROM Productos";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        public void ActualizarProducto(int id, string nombre, decimal precio, int stock)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "UPDATE Productos SET Nombre=@n, Precio=@p, Stock=@s WHERE IdProducto=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@n", nombre);
                cmd.Parameters.AddWithValue("@p", precio);
                cmd.Parameters.AddWithValue("@s", stock);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarProducto(int id)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "DELETE FROM Productos WHERE IdProducto=@id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
