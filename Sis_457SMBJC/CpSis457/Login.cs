using ClnSis457;
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
            //se ejecuta cuando cumple la validacion
            // new Principal().ShowDialog();
            if (validar())
            {
                var usuario = Usuariocl.validar(txtUsuario.Text, txtClave.Text);
                if (usuario != null)
                {
                    //Si el usuario es autenticado correctamente
                    Util.usuario = usuario;
                    //Limpia el contenido del campo de contraseña
                    txtClave.Text = string.Empty;
                    // Selecciona todo el texto en el campo de usuario
                    txtUsuario.SelectAll();
                    //Oculta el formulario actual 
                    Visible = false;

                    new Principal(this).ShowDialog();
                }
                else
                {
                    MessageBox.Show("Usuario y/o contraseña incorrectos",
                        "::: Licoreria - Mensaje :::", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

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

        //validacion de campos usuario y contraseña
        private bool validar()
        {
            bool esValido = true;
            erpUsuario.SetError(txtUsuario, "");
            erpClave.SetError(txtClave, "");
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                erpUsuario.SetError(txtUsuario, "El campo usuario es obligatorio");
                esValido = false;
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                erpClave.SetError(txtClave, "El campo contraseña es obligatorio");
                esValido = false;
            }
            return esValido;
        }
        //autenticarse con enter
        private void txtClave_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnIngresar.PerformClick();
        }




    }
}
