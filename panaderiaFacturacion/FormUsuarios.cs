using panaderiaFacturacion.Datos;
using System;
using System.Data;
using System.Windows.Forms;

namespace panaderiaFacturacion
{
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            dgvUsuarios.DataSource = usuarioDAO.ObtenerUsuarios();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtClave.Text))
            {
                MessageBox.Show("Completa todos los campos");
                return;
            }

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.AgregarUsuario(txtUsuario.Text, txtClave.Text);

            MessageBox.Show("Usuario agregado correctamente");
            CargarUsuarios();
            LimpiarCampos();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario para editar");
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);
            string usuario = txtUsuario.Text;
            string clave = txtClave.Text;

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.EditarUsuario(idUsuario, usuario, clave);

            MessageBox.Show("Usuario editado correctamente");
            CargarUsuarios();
            LimpiarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecciona un usuario para eliminar");
                return;
            }

            int idUsuario = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["IdUsuario"].Value);

            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.EliminarUsuario(idUsuario);

            MessageBox.Show("Usuario eliminado correctamente");
            CargarUsuarios();
            LimpiarCampos();
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtUsuario.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Usuario"].Value.ToString();
                txtClave.Text = dgvUsuarios.Rows[e.RowIndex].Cells["Clave"].Value.ToString();
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            throw new NotImplementedException();
        }
    }
}
