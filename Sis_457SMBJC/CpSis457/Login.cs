using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CpSis457
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            new Principal().ShowDialog();

        }
        //agrandar letras
        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            txtUsuario.Focus();
            //agranda la letra
            txtUsuario.Font = new Font(txtUsuario.Font.FontFamily, 12, FontStyle.Regular);
        }
        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            txtClave.Font = new Font(txtClave.Font.FontFamily, 12, FontStyle.Regular);
        }


        //salir
        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        //minimizar
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

      
        private void ojoClave_CheckedChanged(object sender, EventArgs e)
        {
            //mostrar contraseña
            if (ojoClave.Checked ) 
            {
                txtClave.UseSystemPasswordChar = true;

            }
            else
            {
                txtClave.UseSystemPasswordChar = false;
            }
        }
        
        //Autenticacion

    }
}
