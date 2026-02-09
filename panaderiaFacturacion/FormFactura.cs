using panaderiaFacturacion.Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Linq;

namespace panaderiaFacturacion
{
    public partial class formFactura : Form
    {
        private decimal total = 0;

        public formFactura()
        {
            InitializeComponent();
            CargarClientes();
            CargarProductos();
            ConfigurarDetalleVenta();
        }

        private void CargarClientes()
        {
            ClienteDAO clienteDAO = new ClienteDAO();
            cmbClientes.DataSource = clienteDAO.ObtenerClientes();
            cmbClientes.DisplayMember = "Nombre";
            cmbClientes.ValueMember = "IdCliente";

            cmbClientes.SelectedValue = 2;
        }

        private void CargarProductos()
        {
            ProductoDAO productoDAO = new ProductoDAO();
            
            cmbProductos.DataSource = productoDAO.ObtenerProductos();
            cmbProductos.DisplayMember = "Nombre";
            cmbProductos.ValueMember = "IdProducto";

            
        }

        private void ConfigurarDetalleVenta()
        {
            dvgDetalleVenta.AutoGenerateColumns = false;
            dvgDetalleVenta.Columns.Clear();

            dvgDetalleVenta.Columns.Add("IdProducto", "IdProducto");
            dvgDetalleVenta.Columns.Add("Producto", "Producto");
            dvgDetalleVenta.Columns.Add("Precio", "Precio");
            dvgDetalleVenta.Columns.Add("Cantidad", "Cantidad");
            dvgDetalleVenta.Columns.Add("Subtotal", "Subtotal");
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            if (cmbProductos.SelectedValue == null || string.IsNullOrWhiteSpace(txtCantidad.Text))
            {
                MessageBox.Show("Selecciona un producto y escribe la cantidad");
                return;
            }

            int idProducto = Convert.ToInt32(cmbProductos.SelectedValue);
            string nombreProducto = cmbProductos.Text;
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            DataRowView producto = (DataRowView)cmbProductos.SelectedItem;
            decimal precio = Convert.ToDecimal(producto["Precio"]);
            decimal subtotal = precio * cantidad;

            dvgDetalleVenta.Rows.Add(idProducto, nombreProducto, precio, cantidad, subtotal);

            total += subtotal;
            lblTotal.Text = $"Total: {total:C}";
        }

        private void btnConfirmarVenta_Click(object sender, EventArgs e)
        {
            if (dvgDetalleVenta.Rows.Count == 0)
            {
                MessageBox.Show("Agrega al menos un producto a la factura");
                return;
            }

            List<(int IdProducto, int Cantidad, decimal PrecioUnitario)> detalle = new List<(int, int, decimal)>();

            foreach (DataGridViewRow row in dvgDetalleVenta.Rows)
            {
                if (row.IsNewRow) continue;

                int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);

                detalle.Add((idProducto, cantidad, precio));
            }

            FacturaDAO facturaDAO = new FacturaDAO();
            int idCliente = Convert.ToInt32(cmbClientes.SelectedValue);
            int idFactura = facturaDAO.RegistrarFactura(idCliente, total, detalle);

            MessageBox.Show($"Factura registrada con ID: {idFactura}");

            
            GenerarFacturaPDF(idFactura);

            dvgDetalleVenta.Rows.Clear();
            total = 0;
            lblTotal.Text = "Total: $0.00";
        }


        public void GenerarFacturaPDF(int idFactura)
        {
            FacturaDAO facturaDAO = new FacturaDAO();
            DataTable factura = facturaDAO.ObtenerFacturas(new DateTime(1753, 1, 1), DateTime.Now);
            DataTable detalle = facturaDAO.ObtenerDetalleFactura(idFactura);

            // Crear documento
            Document doc = new Document(PageSize.A4);
            string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"Factura_{idFactura}.pdf");
            PdfWriter.GetInstance(doc, new FileStream(ruta, FileMode.Create));
            doc.Open();

            // Encabezado
            doc.Add(new Paragraph("Factura de Panadería"));
            doc.Add(new Paragraph($"Número: {idFactura}"));
            doc.Add(new Paragraph($"Fecha: {DateTime.Now}"));
            doc.Add(new Paragraph("Cliente: Consumidor Final"));
            doc.Add(new Paragraph(" "));

            // Tabla detalle
            PdfPTable table = new PdfPTable(4);
            table.AddCell("Producto");
            table.AddCell("Cantidad");
            table.AddCell("Precio Unitario");
            table.AddCell("Subtotal");

            foreach (DataRow row in detalle.Rows)
            {
                table.AddCell(row["Producto"].ToString());  
                table.AddCell(row["Cantidad"].ToString());
                table.AddCell(row["PrecioUnitario"].ToString());
                table.AddCell(row["Subtotal"].ToString());
            }


            doc.Add(table);

            // Total
            decimal total = detalle.AsEnumerable().Sum(r => r.Field<decimal>("Subtotal"));
            doc.Add(new Paragraph($"Total: {total:C}"));

            doc.Close();

            MessageBox.Show($"Factura PDF generada en: {ruta}");
        }

    }
}