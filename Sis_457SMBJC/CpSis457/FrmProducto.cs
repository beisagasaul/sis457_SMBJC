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
    public partial class FrmProducto : Form
    {
        bool esNuevo = false;
        public FrmProducto()
        {
            InitializeComponent();


        }
        //crar funcion listar
        private void listar()
        {
             var productos= ProductoCl.listarPa(txtBuscar.Text.Trim());
            dgvLista.DataSource = productos;
            //Oculta la columna id
            dgvLista.Columns["id"].Visible = false;
            dgvLista.Columns["estado"].Visible = false;
            dgvLista.Columns["saldo"].Visible = false;
            //Poner mayusculas 
            dgvLista.Columns["codigo"].HeaderText = "Código";
            dgvLista.Columns["descripcion"].HeaderText = "Descripción";
            dgvLista.Columns["unidadMedida"].HeaderText = "Cantidad";
            dgvLista.Columns["precioVenta"].HeaderText = "Precio de Venta Bs";
            dgvLista.Columns["usuarioRegistro"].HeaderText = "Usuarios";
            dgvLista.Columns["fechaRegistro"].HeaderText = "Fecha y Hora";
            //habilitar edicion y eliminar y desabilitar
            btnEditar.Enabled = productos.Count > 0;
            btnEliminar.Enabled = productos.Count > 0;
            //Si  hay registro que el primer elemento este selccionado
            if(productos.Count>0) dgvLista.Rows[0].Cells["codigo"].Selected = true;


        }
        //ocultar el formulario de nuevo
        private void FrmProducto_Load(object sender, EventArgs e)
        {
            Size=new Size( 1021, 441);
            listar();
        }
        //muestra el formulario para crear nuevos
        private void btnNuevo_Click(object sender, EventArgs e)

        {
            //parpadea en nuevo
            esNuevo= true;
            txtCodigo.Focus();
            Size = new Size(1021, 588);
        }
        //editar 
        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(1021, 588);
        }
        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(1021, 441);
            limpiar();
        }
        //cerrar salir de todo
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }
        //buscar
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            listar();
        }
        //buscar  presionando enter
        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) listar();
        }
        //guardar nuevos nuevos registros
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var producto = new Producto();
            producto.codigo = txtCodigo.Text.Trim();
            producto.descripcion = txtDescripcion.Text.Trim();
            producto.unidadMedida = cbxUnidad.Text;
            producto.saldo = numSaldo.Value;
            producto.precioVenta = numPrecioVenta.Value;
            producto.usuarioRegistro="sis257";
            if(esNuevo)
            {
                producto.fechaRegistro = DateTime.Now;
                producto.estado = 1;
                ProductoCl.insertar(producto);
            }
            else
            {
                int index = dgvLista.CurrentCell.RowIndex;
                producto.id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
                ProductoCl.actualizar(producto);
            }
            listar();
            btnCancelar.PerformClick();
            MessageBox.Show("Producto guardado correctamente","sis257",
                MessageBoxButtons.OK,MessageBoxIcon.Information);
        }
        //limpiar 
        private void limpiar()
        {
            txtCodigo.Text=string.Empty;
            txtDescripcion.Text=string.Empty;
            cbxUnidad.SelectedIndex=-1;
            numSaldo.Value =0;
    }
    }
}
