using panaderiaFacturacion.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace panaderiaFacturacion
{
    public partial class formReportes : Form
    {
        public formReportes()
        {
            InitializeComponent();
            

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FacturaDAO facturaDAO = new FacturaDAO();
            DataTable facturas = facturaDAO.ObtenerFacturas(dtpInicio.Value, dtpFin.Value);

            dgvFacturas.DataSource = facturas;

            // Calcular total de ventas en el rango
            decimal totalVentas = 0;
            foreach (DataRow row in facturas.Rows)
            {
                totalVentas += Convert.ToDecimal(row["Total"]);
            }
            lblTotalVentas.Text = $"Total ventas: {totalVentas:C}";
        }

        private void dgvFacturas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idFactura = Convert.ToInt32(dgvFacturas.Rows[e.RowIndex].Cells["IdFactura"].Value);

                FacturaDAO facturaDAO = new FacturaDAO();
                DataTable detalle = facturaDAO.ObtenerDetalleFactura(idFactura);

                dgvDetalle.DataSource = detalle;
            }
        }
    }
}