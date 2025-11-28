using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace INICIO_SESIÓN_e
{
    public partial class FRMenu : Form
    {
        private string nombreUsuario;
        private string rolUsuario;
        public FRMenu(string usuario,string rol)
        {
            InitializeComponent();
            nombreUsuario = usuario;
            rolUsuario = rol;
        }

        private void FRMenu_Load(object sender, EventArgs e)
        {
            lblBienvenido.Text = $"Bienvenido: {nombreUsuario}";
            lblID.Text = $"ID: {rolUsuario}";
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FRInicio inicio = new FRInicio();
            inicio.Show();
            this.Hide();
        }
    }
}
