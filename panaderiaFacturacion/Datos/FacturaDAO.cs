using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace panaderiaFacturacion.Datos
{
    public class FacturaDAO
    {
        public int RegistrarFactura(int idCliente, decimal total, List<(int IdProducto, int Cantidad, decimal PrecioUnitario)> detalle)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                conn.Open();
                SqlTransaction tran = conn.BeginTransaction();

                try
                {
                    string queryFactura = "INSERT INTO Facturas (IdCliente, Fecha, Total) OUTPUT INSERTED.IdFactura VALUES (@idCliente, @fecha, @total)";
                    SqlCommand cmdFactura = new SqlCommand(queryFactura, conn, tran);
                    cmdFactura.Parameters.AddWithValue("@idCliente", idCliente);
                    cmdFactura.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmdFactura.Parameters.AddWithValue("@total", total);

                    int idFactura = (int)cmdFactura.ExecuteScalar();

                    foreach (var item in detalle)
                    {
                        string queryDetalle = "INSERT INTO DetalleFactura (IdFactura, IdProducto, Cantidad, PrecioUnitario, Subtotal) " +
                                              "VALUES (@idFactura, @idProd, @cant, @precio, @subtotal)";
                        SqlCommand cmdDetalle = new SqlCommand(queryDetalle, conn, tran);
                        cmdDetalle.Parameters.AddWithValue("@idFactura", idFactura);
                        cmdDetalle.Parameters.AddWithValue("@idProd", item.IdProducto);
                        cmdDetalle.Parameters.AddWithValue("@cant", item.Cantidad);
                        cmdDetalle.Parameters.AddWithValue("@precio", item.PrecioUnitario);
                        cmdDetalle.Parameters.AddWithValue("@subtotal", item.PrecioUnitario * item.Cantidad);

                        cmdDetalle.ExecuteNonQuery();
                    }

                    tran.Commit();
                    return idFactura;
                }
                catch
                {
                    tran.Rollback();
                    throw;
                }
            }
        }

        // obtener facturas por rango de fechas
        public DataTable ObtenerFacturas(DateTime fechaInicio, DateTime fechaFin)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = "SELECT IdFactura, IdCliente, Fecha, Total FROM Facturas WHERE Fecha BETWEEN @inicio AND @fin";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@inicio", fechaInicio);
                da.SelectCommand.Parameters.AddWithValue("@fin", fechaFin);

                DataTable dt = new DataTable();
                try
                {
                    da.Fill(dt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener facturas: " + ex.Message);
                }

                return dt;
            }
        }

        // obtener detalle de una factura
        public DataTable ObtenerDetalleFactura(int idFactura)
        {
            using (SqlConnection conn = Conexion.ObtenerConexion())
            {
                string query = @"SELECT d.IdProducto, p.Nombre AS Producto, d.Cantidad, d.PrecioUnitario, d.Subtotal
                         FROM DetalleFactura d
                         INNER JOIN Productos p ON d.IdProducto = p.IdProducto
                         WHERE d.IdFactura = @idFactura";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@idFactura", idFactura);

                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

    }
}