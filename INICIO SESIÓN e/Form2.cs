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
    public partial class FRMantencion : Form
    {
        public FRMantencion()
        {
            InitializeComponent();
        }

        private void Salir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bttVolver_Click(object sender, EventArgs e)
        {
            FRInicio inicio = new FRInicio();
            inicio.Show();
            this.Hide();
            
        }
    }
}
