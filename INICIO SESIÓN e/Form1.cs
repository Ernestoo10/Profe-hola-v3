using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace INICIO_SESIÓN_e
{
    public partial class FRInicio : Form
    {
        public FRInicio()
        {
            InitializeComponent();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMantencion Manten = new FRMantencion();
            Manten.Show();
            this.Hide();
        }

        private void bttIngresar_Click(object sender, EventArgs e)
        {
            string usuario, contraseña;
            usuario = txtUsuario.Text;
            contraseña = txtContraseña.Text;
            string connectionstring = "server = DESKTOP-9N0UA3G\\SQLEXPRESS;Database = LOGINDBS; integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                String query = "SELECT NombreRol FROM Usuarios U JOIN Roles R ON U.IDR = R.IDR WHERE U.Usuario = @usuario AND U.Contraseña = @contrasena";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contrasena", contraseña);

                var rol = cmd.ExecuteScalar();

                if (rol != null)
                {
                    String rolUsuario = rol.ToString();

                    FRMenu menu = new FRMenu(usuario, rolUsuario);
                    menu.Show();

                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Usuario o Contraseña Incorrecto", "Erorr de Datos");
                }
            }
        }

        private void bttSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRMantencion Manten = new FRMantencion();
            Manten.Show();
            this.Hide();
        }


        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void FRInicio_Load(object sender, EventArgs e)
        {

        }
    }
}
