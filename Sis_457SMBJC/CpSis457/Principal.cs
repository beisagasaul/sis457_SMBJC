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
        public Principal()
        {
            InitializeComponent();
        }

        private void ribbonButton9_Click(object sender, EventArgs e)
        {

        }

        private void rbProducto_Click(object sender, EventArgs e)
        {
            new FrmProducto().ShowDialog();       
                
        }

        private void rbVenta_Click(object sender, EventArgs e)
        {
            new FrmVenta().ShowDialog();
        }

        private void rbDetalleVenta_Click(object sender, EventArgs e)
        {
            new FrmVentaDetalle().ShowDialog();
        }
    }
}
