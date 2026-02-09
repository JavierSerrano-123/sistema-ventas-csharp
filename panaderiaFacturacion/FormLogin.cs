using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace panaderiaFacturacion
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
            


         private void btnIngresar_Click(object sender, EventArgs e)
            {
                using (SqlConnection conn = Conexion.ObtenerConexion())
                {
                    string query = "SELECT COUNT(*) FROM Usuarios WHERE Usuario=@u AND Clave=@c";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@u", txtUsuario.Text);
                    cmd.Parameters.AddWithValue("@c", txtClave.Text);


                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();


                    if (count > 0)
                    {
                        MessageBox.Show("Bienvenido al sistema", "Login correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        FormPrincipal frm = new FormPrincipal();
                        frm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }
    }
    }

