using CadSis457;
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
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
            dgvLista.DataSource = VentaCln.listarPa("");
        }
      

       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
           
        }
    }
}
