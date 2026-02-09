using System;
using System.Windows.Forms;
using panaderiaFacturacion.Datos;

namespace panaderiaFacturacion
{
    public partial class FormProductos : Form
    {
        ProductoDAO dao = new ProductoDAO();

        public FormProductos()
        {
            InitializeComponent();
            CargarProductos();
        }

        private void CargarProductos()
        {
            dgvProductos.DataSource = dao.ObtenerProductos();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtNombre.Focus();
        }

       
            private void btnAgregar_Click(object sender, EventArgs e)
            {
                if (txtNombre.Text == "" || txtPrecio.Text == "" || txtStock.Text == "")
                {
                    MessageBox.Show("Completa todos los campos");
                    return;
                }

                decimal precio;
                int stock;

                if (!decimal.TryParse(txtPrecio.Text, out precio) ||
                    !int.TryParse(txtStock.Text, out stock))
                {
                    MessageBox.Show("Precio o stock inválidos");
                    return;
                }

                dao.InsertarProducto(txtNombre.Text, precio, stock);

                CargarProductos();
                Limpiar();
            }



        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            // Validar campos vacíos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtPrecio.Text) ||
                string.IsNullOrWhiteSpace(txtStock.Text))
            {
                MessageBox.Show("Completa todos los campos antes de editar");
                return;
            }

            // Validar conversiones
            decimal precio;
            int stock;
            if (!decimal.TryParse(txtPrecio.Text, out precio) ||
                !int.TryParse(txtStock.Text, out stock))
            {
                MessageBox.Show("Precio o stock inválidos");
                return;
            }

            int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IdProducto"].Value);

            dao.ActualizarProducto(id, txtNombre.Text, precio, stock);

            CargarProductos();
            Limpiar();
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            DialogResult result = MessageBox.Show(
                "¿Estás seguro de que deseas eliminar este producto?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (result == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvProductos.CurrentRow.Cells["IdProducto"].Value);

                dao.EliminarProducto(id);

                CargarProductos();
                Limpiar();
            }
        }
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvProductos.CurrentRow == null) return;

            txtNombre.Text = dgvProductos.CurrentRow.Cells["Nombre"].Value.ToString();
            txtPrecio.Text = dgvProductos.CurrentRow.Cells["Precio"].Value.ToString();
            txtStock.Text = dgvProductos.CurrentRow.Cells["Stock"].Value.ToString();
        }

        private void FormProductos_Load(object sender, EventArgs e)
        {
            CargarProductos();

        }
    }
}
