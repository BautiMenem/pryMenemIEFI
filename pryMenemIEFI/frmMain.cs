using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;


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
            ClsConexion cls = new ClsConexion();
            cls.CargarPaises(cmbLugar);

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            //booleano para determinar el tipo de sexo utilizando el boton de opcion
            bool sexo = true;
            if (rbMasculino.Checked == true)
            {
                sexo = true;
            }
            else
            {
                if (rbFemenino.Checked == true)
                {
                    sexo = false;
                }
            }

            //llamo el objeto de la clase conexion para escribir un nuevo socio en la base de datos
            ClsConexion obj = new ClsConexion();
            obj.RegistrarSocio(txtNombre.Text, txtApellido.Text, cmbLugar.Text, Convert.ToInt32(txtEdad.Text), sexo, Convert.ToDecimal(txtIngreso.Text), Convert.ToInt32(txtPuntaje.Text));
            Limpiar();


        }

        private void txtEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtPuntaje_TextChanged(object sender, EventArgs e)
        {
            if (txtPuntaje.Text != "" && txtPuntaje.Text != "")
            {
                btnRegistrar.Enabled = true;
            }
        }

        private void txtPuntaje_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rbMasculino_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMasculino.Checked == true)
            {
                txtIngreso.Text = "1000";
                txtPuntaje.Enabled = true;
            }
        }

        private void rbFemenino_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemenino.Checked == true)
            {
                txtIngreso.Text = "1000";
                txtPuntaje.Enabled = true;
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text != "" && txtNombre.Text != null)
            {
                txtApellido.Enabled = true;
                btnLimpiar.Enabled = true;
            }

           
        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {
            if (txtApellido.Text != "" && txtApellido.Text != null)
            {
                cmbLugar.Enabled = true;
            }
        }

        private void cmbLugar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLugar.SelectedIndex != -1)
            {
                txtEdad.Enabled = true;
            }
        }

        private void txtEdad_TextChanged(object sender, EventArgs e)
        {
            if (txtEdad.Text != "" && txtEdad.Text != null)
            {
                mrcSexo.Enabled = true;
            }
        }

        private void btnLugar_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLugar frm = new frmLugar();
            frm.ShowDialog();
        }

        private void btnSugerencia_Click(object sender, EventArgs e)
        {
            MessageBox.Show( " Si Su Pais No Aparece En La Lista, Por Favor Agreguelo En El Apartado ``Agregar Lugar´´.", "Sugerencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtApellido.Enabled = false;
            cmbLugar.SelectedIndex = -1;
            cmbLugar.Enabled = false;
            txtEdad.Clear();
            txtEdad.Enabled = false;           
            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
            mrcSexo.Enabled = false;
            txtIngreso.Enabled = false;
            txtIngreso.Clear();
            txtPuntaje.Enabled = false;
            txtPuntaje.Clear();
            btnRegistrar.Enabled = false;
        }
    }
}
