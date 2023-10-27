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
           
            //Poner mayusculas 
            dgvLista.Columns["codigo"].HeaderText = "Código";
            dgvLista.Columns["descripcion"].HeaderText = "Nombre del Producto";
            dgvLista.Columns["unidadMedida"].HeaderText = "Cantidad";
            dgvLista.Columns["saldo"].HeaderText = "Precio de Compra";
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
            dgvLista.DefaultCellStyle.ForeColor = Color.Black;
            Size=new Size(687, 548);
            listar();
        }
        //muestra el formulario para crear nuevos
        private void btnNuevo_Click(object sender, EventArgs e)

        {
            //parpadea en nuevo
            esNuevo= true;
            txtCodigo.Focus();
            Size = new Size(1005, 548);
        }
        //editar 
        private void btnEditar_Click(object sender, EventArgs e)
        {
            esNuevo = true;
            Size = new Size(1005, 548);
            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            var producto =ProductoCl.get(id);
            txtCodigo.Text = producto.codigo;
            txtDescripcion.Text = producto.descripcion;
            cbxUnidad.Text = producto.unidadMedida;
            numSaldo.Value = producto.saldo;
            numPrecioVenta.Value = producto.precioVenta;
        }
        //Cancelar
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Size = new Size(687, 548);
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
        //VALIDAR PARA ESCRIBIR
        private bool  validar()
        {
            bool esValido = true;
            erpCodigo.SetError(txtCodigo, "");
            erpDescripcion.SetError(txtDescripcion, "");
            erpUnidad.SetError(cbxUnidad, "");
            erpSaldo.SetError(numSaldo, "");
            erpPrecio.SetError(numPrecioVenta, "");
            //validacion para codigo
            if (string .IsNullOrEmpty(txtCodigo.Text))
            {
                esValido = false;
                erpCodigo.SetError(txtCodigo, "El campo Código es obligatorio");
                
            }
            //validacion para descripcion
            if (string.IsNullOrEmpty(txtDescripcion.Text))
            {
                esValido = false;
                erpDescripcion.SetError(txtDescripcion, "El campo Nombre del Producto es obligatorio");

            }
            //validacion para unidad
            if (string.IsNullOrEmpty(cbxUnidad.Text))
            {
                esValido = false;
                erpUnidad.SetError(cbxUnidad, "El Cantidad  es obligatorio");

            }
            //validacion para saldo
            if (numSaldo.Value < 1)
            {
                esValido = false;
                erpUnidad.SetError(numSaldo, "El campo Saldo tiene que ser mayor a cero");

            }
            //validacion para precio
            if (numPrecioVenta.Value < 1)
            {
                esValido = false;
                erpUnidad.SetError(numPrecioVenta, "El campo Precio tiene que ser mayor a cero");

            }

            return esValido;
        }



        //guardar nuevos nuevos registros
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validar())
            {


                var producto = new Producto();
                producto.codigo = txtCodigo.Text.Trim();
                producto.descripcion = txtDescripcion.Text.Trim();
                producto.unidadMedida = cbxUnidad.Text;
                producto.saldo = numSaldo.Value;
                producto.precioVenta = numPrecioVenta.Value;
                producto.usuarioRegistro = "sis257";
                if (esNuevo)
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
                MessageBox.Show("Producto guardado correctamente", "sis257",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //limpiar 
        private void limpiar()
        {
            txtCodigo.Text=string.Empty;
            txtDescripcion.Text=string.Empty;
            cbxUnidad.SelectedIndex=-1;
            numSaldo.Value =0;
    }
        //eliminar 
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int index = dgvLista.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dgvLista.Rows[index].Cells["id"].Value);
            string codigo = dgvLista.Rows[index].Cells["codigo"].Value.ToString();
            DialogResult dialog = MessageBox.Show($"¿Esta seguro de que desea eliminar{codigo}?", "sis257", MessageBoxButtons.OK,
                MessageBoxIcon.Question);
           
            if (dialog==DialogResult.OK)
            {
                ProductoCl.eliminar(id,"sis457");
                listar();
                MessageBox.Show("Producto eliminado correctamente", "sis257",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        //volver a la lista actual despues de buscar
        private void btnSalirB_Click(object sender, EventArgs e)
        {
           Close();
        }
    }
}
