using panaderiaFacturacion.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace panaderiaFacturacion
{
    public partial class FormClientes : Form
    {
        ClienteDAO clienteDAO = new ClienteDAO();

        public FormClientes()
        {
            InitializeComponent();
            CargarClientes();
        }

        private void CargarClientes()
        {
            dgvClientes.DataSource = clienteDAO.ObtenerClientes();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            clienteDAO.InsertarCliente(txtNombre.Text, txtTelefono.Text);
            CargarClientes();
            Limpiar();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);
            clienteDAO.ActualizarCliente(idCliente, txtNombre.Text, txtTelefono.Text);
            CargarClientes();
            Limpiar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null) return;

            int idCliente = Convert.ToInt32(dgvClientes.CurrentRow.Cells["IdCliente"].Value);
            clienteDAO.EliminarCliente(idCliente);
            CargarClientes();
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtTelefono.Clear();
        }
    }


}
