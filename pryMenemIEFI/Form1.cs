using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryMenemIEFI
{
    public partial class frmMain : Form
    {
        

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            ClsConexion objConexion = new ClsConexion();
            objConexion.ConexionABase();

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            bool Sexo1 = true;
            if (rbMasculino.Checked == true )
            {
                Sexo1 = true;
            }
            else if (rbMasculino.Checked == false)
            {
                Sexo1 = false;
            }
            ClsConexion objClase = new ClsConexion();
            objClase.RegistrarSocio(txtNombre.Text, txtApellido.Text, txtLugar.Text, Convert.ToInt32(txtEdad.Text), Sexo1, Convert.ToDecimal(txtIngreso.Text), Convert.ToInt32(txtPuntaje.Text));
            

            
        }
    }
}
