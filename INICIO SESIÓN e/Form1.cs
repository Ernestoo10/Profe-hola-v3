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
            string usuario = txtUsuario.Text.Trim();
            string contraseña = txtContraseña.Text.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Debe ingresar usuario y contraseña.", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = @"server=DESKTOP-9N0UA3G\SQLEXPRESS;Database=LOGINDBS;Integrated Security=true;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"SELECT NombreRol FROM Usuarios U JOIN Roles R ON U.IDR = R.IDR WHERE U.Usuario = @usuario AND U.Contraseña = @contrasena";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", usuario);
                        cmd.Parameters.AddWithValue("@contrasena", contraseña);

                        var rol = cmd.ExecuteScalar();

                        if (rol != null)
                        {
                            string rolUsuario = rol.ToString();

                            FRMenu menu = new FRMenu(usuario, rolUsuario);
                            menu.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Usuario/Contraseña incorrecto.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            txtUsuario.Clear();
                            txtContraseña.Clear();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al conectar con la base de datos:\n" + ex.Message, "Error de conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
