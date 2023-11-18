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
    public partial class Principal : Form
    {
        Login  login;
        public Principal(Login login)
        {
            InitializeComponent();
            this.login=login;
        }
        //se dirige hacia Productos
        private void rbProducto_Click(object sender, EventArgs e)
        {
            new FrmProducto().ShowDialog();

        }
        //Se drige hacia Venta
        private void rbVenta_Click(object sender, EventArgs e)
        {
            new FrmVenta().ShowDialog();
        }
        //Se drige hacia VentaDetalle 
        private void rbDetalleVenta_Click(object sender, EventArgs e)
        {
            new FrmVentaDetalle().ShowDialog();
        }

        private void Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            login.Visible = true;
        }

        private void ribbonButton9_Click(object sender, EventArgs e)
        {

        }

        

       
    }
}
