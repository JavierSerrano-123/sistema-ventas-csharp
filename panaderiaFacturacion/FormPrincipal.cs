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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            formReportes frm = new formReportes();
            frm.ShowDialog();
        }

       
            private void btnProductos_Click(object sender, EventArgs e)
            {
                FormProductos frm = new FormProductos();
                frm.ShowDialog();
            }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            formFactura frm = new formFactura(); 
            frm.ShowDialog(); 
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            FormClientes frm = new FormClientes();
            frm.ShowDialog();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            FormUsuarios frm = new FormUsuarios();
            frm.ShowDialog();
        }
    }
}
